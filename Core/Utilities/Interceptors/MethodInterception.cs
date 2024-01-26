using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    //Bütün Metotların Çatısı Burası
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //Metodun başında
        protected virtual void OnBefore(IInvocation invocation) { }
        //Metodun sonunda
        protected virtual void OnAfter(IInvocation invocation) { }
        //
        protected virtual void OnException(IInvocation invocation, Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        //IInvocation => Çalıştırmak istediğimiz metot
        //**Metot çalışmadan önce buradan geçecek**.
        //Genelde OnBefore ve OnException kullanılır fakat diğerleri de kullanılabilir.
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation); //Metodun başında çalıştır.
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e); //Hata aldığında çalıştır.
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation); //Metot başarılı olduğunda çalıştır.
                }
            }
            OnAfter(invocation); //Metottan sonra çalıştır.
        }
    }
}
