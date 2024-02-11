namespace Core.Utilities.Helpers.GuidHelper
{
    public class GuidHelper_
    {
        public static string Create()
        {
            return Guid.NewGuid().ToString();
        }
    }
}