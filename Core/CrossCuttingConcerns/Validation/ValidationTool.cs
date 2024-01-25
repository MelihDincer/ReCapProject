using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    //Genellikle static olarak yapılır. Tek bir instance oluşturulur ve uygulama belleği sadece onu kullanır. Bir daha newlenmez.
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
