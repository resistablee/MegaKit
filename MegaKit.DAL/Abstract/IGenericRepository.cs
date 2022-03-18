using MegaKit.EL;
using MegaKit.EL.DBMegaKit.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MegaKit.DAL.Abstract
{
    public interface IGenericRepository<T> where T: Base, new()
    {
        //Eğer ben GetAsync ve GetAllAsync metodlarımı kullanırken parametre olarak bir linq sorgusu yazarsam bu sorguyu çalıştıracak.
        //Eğer yazmazsam da filter = null dediğim için where koşulsuz bir şekilde çalışacak.

        Task<ReturnValue<IQueryable<T>>> GetAllAsync(Expression<Func<T, bool>> filter = null);

        public Task<ReturnValue<T>> GetBy(Expression<Func<T, bool>> filter);

        public Task<ReturnValue<T>> GetById(int id);

        //Parametre olarak gönderdiğim linq'da koşulunu sağlayan veri varsa true yoksa false döndürecek
        Task<ReturnValue<T>> AnyAsync(Expression<Func<T, bool>> filter);

        //Parametre olarak gönderdiğim linq'da koşulunu sağlayan kaç adet veri varsa onun sayısını döndürecek
        Task<ReturnValue<T>> CountAsync(Expression<Func<T, bool>> filter);

        //Insert operasyonu
        Task<ReturnValue<T>> Add(T entity);

        //Update operasyonu
        Task<ReturnValue<T>> Update(T entity);

        //Delete operasyonu
        Task<ReturnValue<T>> Delete(int id);

        //Custom sql sorgusu yazabilmek için
        ReturnValue<IEnumerable<T>> GetSql(string sql);
    }
}
