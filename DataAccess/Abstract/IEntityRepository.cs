using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Generic constraint -- Generic kısıt
    //class : referans tip
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne
    //new() : new'lenebilir olmalı.
    public interface IEntityRepository<T> where T : class, IEntity, new() //T : Referance type olabilir ve T: IEntity ya da IEntity den implemente olan bir şey olabilir. Aynı zamanda IEntity interface olduğundan newlenemez. Newlenebilme şartı koyduğumuz için IEntity gönderememekteyiz.Burada bunun önüne de geçmiş olduk.
    {
        //Expression, en temelinde delege dediğimiz bir yapıdır.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//Burası linq sorgularda yaptığımız filtreleme işlemlerini burada yapmamızı sağlar. Örneğin; p=>p.CategoryId==2 gibi sorgular. Burada başlangıçta null olması bu özelliği kullanmayabiliriz, yani filtreleme istediğimiz zaman ilgili kodu yazarız.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
