using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        //Attribute lara tipleri bu şekilde Type ile atıyoruz.
        private Type _validatorType;
        public ValidationAspect(Type validatorType) 
        {
            //Gönderilen validatorType bir IValidator değilse
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) 
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil!");
            }
            _validatorType = validatorType;
        }

        //Core->Interceptors içerisindeki MethodInterception abstract classında virtual ile boş tanımlanan metodu aşağıda override ettik.
        protected override void OnBefore(IInvocation invocation)
        {
            //Reflection çalışma anında bir şeyleri çalıştırmamızı sağlıyor. Newleme işini çalışma anında yapmamızı sağlar.
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
