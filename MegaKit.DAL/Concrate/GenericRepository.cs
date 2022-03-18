using MegaKit.DAL.Abstract;
using MegaKit.DAL.Contexts;
using MegaKit.EL;
using MegaKit.EL.DBMegaKit.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MegaKit.DAL.Concrate
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Base, new()
    {
        protected readonly ContextMegaKit _context;

        public GenericRepository(ContextMegaKit context)
        {
            _context = context;
        }

        public async Task<ReturnValue<T>> Add(T entity)
        {
            using (ReturnValue<T> rv = new ReturnValue<T>())
            {
                await _context.Set<T>().AddAsync(entity);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    rv.Title = "Bir hata meydana geldi";
                    rv.Text = "Lütfen daha sonra tekrar deneyiniz";
                    rv.Data = null;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.StatusCode = 500;
                    rv.Exception = ex;
                    rv.ErrorCode = "GR1000";

                    return rv;
                }

                rv.Data = entity;
                rv.Title = "İşlem başarılı";
                rv.StatusCode = 201;
                return rv;
            }
        }

        public async Task<ReturnValue<T>> AnyAsync(Expression<Func<T, bool>> filter)
        {
            using (ReturnValue<T> rv = new ReturnValue<T>())
            {
                try
                {
                    rv.AnyData = await _context.Set<T>().AnyAsync(filter);
                }
                catch (Exception ex)
                {
                    rv.Title = "Bir hata meydana geldi";
                    rv.Text = "Lütfen daha sonra tekrar deneyiniz";
                    rv.Data = null;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.StatusCode = 500;
                    rv.Exception = ex;
                    rv.ErrorCode = "GR1001";

                    return rv;
                }

                rv.Title = "İşlem başarılı";
                rv.StatusCode = 200;

                return rv;
            }
        }

        public async Task<ReturnValue<T>> CountAsync(Expression<Func<T, bool>> filter)
        {
            using (ReturnValue<T> rv = new ReturnValue<T>())
            {
                try
                {
                    rv.DataCount = await _context.Set<T>().CountAsync(filter);
                }
                catch (Exception ex)
                {
                    rv.Title = "Bir hata meydana geldi";
                    rv.Text = "Lütfen daha sonra tekrar deneyiniz";
                    rv.Data = null;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.StatusCode = 500;
                    rv.Exception = ex;
                    rv.ErrorCode = "GR1003";

                    return rv;
                }

                rv.AnyData = rv.DataCount == 0 ? false : true;
                rv.Title = "İşlem başarılı";
                rv.StatusCode = 200;

                return rv;
            }
        }

        public async Task<ReturnValue<T>> Delete(int id)
        {
            using (ReturnValue<T> rv = new ReturnValue<T>())
            {
                T entity = GetById(id).Result.Data;

                if (entity == null)
                {
                    rv.Title = "Kayıt bulunamadı!";
                    rv.StatusCode = 404;
                    rv.ErrorCode = "GR1004";

                    return rv;
                }

                _context.Set<T>().Remove(entity);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    rv.Title = "Bir hata meydana geldi";
                    rv.Text = "Lütfen daha sonra tekrar deneyiniz";
                    rv.Data = null;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.StatusCode = 500;
                    rv.Exception = ex;
                    rv.ErrorCode = "GR1005";

                    return rv;
                }

                rv.Data = entity;
                rv.DataCount = 1;
                rv.AnyData = true;
                rv.Title = "İşlem başarılı";
                rv.StatusCode = 200;
                return rv;
            }
        }

        public async Task<ReturnValue<IQueryable<T>>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            using (ReturnValue<IQueryable<T>> rv = new ReturnValue<IQueryable<T>>())
            {
                IQueryable<T> query = _context.Set<T>();

                if (filter != null)
                    query = query.Where(filter);

                try
                {
                    rv.Data = query.AsNoTracking();
                }
                catch (Exception ex)
                {
                    rv.Title = "Bir hata meydana geldi";
                    rv.Text = "Lütfen daha sonra tekrar deneyiniz";
                    rv.Data = null;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.StatusCode = 500;
                    rv.Exception = ex;
                    rv.ErrorCode = "GR1006";

                    return rv;
                }

                if (rv.Data.CountAsync().Result <= 0)
                {
                    rv.Title = "Kayıt bulunamadı!";
                    rv.StatusCode = 404;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.ErrorCode = "GR1007";

                    return rv;
                }

                rv.Title = "İşlem başarılı";
                rv.StatusCode = 200;
                rv.DataCount = await rv.Data.CountAsync();
                rv.AnyData = true;

                return rv;
            }
        }

        public async Task<ReturnValue<T>> GetBy(Expression<Func<T, bool>> filter)
        {
            using (ReturnValue<T> rv = new ReturnValue<T>())
            {
                IQueryable<T> query = _context.Set<T>();

                try
                {
                    rv.Data = await query.Where(filter).SingleOrDefaultAsync();
                }
                catch (Exception ex)
                {
                    rv.Title = "Bir hata meydana geldi";
                    rv.Text = "Lütfen daha sonra tekrar deneyiniz";
                    rv.Data = null;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.StatusCode = 500;
                    rv.Exception = ex;
                    rv.ErrorCode = "GR1008";

                    return rv;
                }

                if (rv.Data == null)
                {
                    rv.Title = "Kayıt bulunamadı!";
                    rv.StatusCode = 404;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.ErrorCode = "GR1009";

                    return rv;
                }

                rv.Title = "İşlem başarılı";
                rv.StatusCode = 200;
                rv.DataCount = 1;
                rv.AnyData = true;

                return rv;
            }
        }

        public async Task<ReturnValue<T>> GetById(int id)
        {
            using (ReturnValue<T> rv = new ReturnValue<T>())
            {
                try
                {
                    rv.Data = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                }
                catch (Exception ex)
                {
                    rv.Title = "Bir hata meydana geldi";
                    rv.Text = "Lütfen daha sonra tekrar deneyiniz";
                    rv.Data = null;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.StatusCode = 500;
                    rv.Exception = ex;
                    rv.ErrorCode = "GR1010";

                    return rv;
                }

                if (rv.Data == null)
                {
                    rv.Title = "Kayıt bulunamadı!";
                    rv.StatusCode = 404;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.ErrorCode = "GR1011";

                    return rv;
                }

                rv.AnyData = true;
                rv.DataCount = 1;
                rv.Title = "İşlem başarılı";
                rv.StatusCode = 200;

                return rv;
            }
        }

        public ReturnValue<IEnumerable<T>> GetSql(string sql)
        {
            using (ReturnValue<IEnumerable<T>> rv = new ReturnValue<IEnumerable<T>>())
            {
                try
                {
                    rv.Data = _context.Set<T>().FromSqlRaw(sql).AsNoTracking();
                }
                catch (Exception ex)
                {
                    rv.Title = "Bir hata meydana geldi";
                    rv.Text = "Lütfen daha sonra tekrar deneyiniz";
                    rv.Data = null;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.StatusCode = 500;
                    rv.Exception = ex;
                    rv.ErrorCode = "GR1012";

                    return rv;
                }

                if (rv.Data == null)
                {
                    rv.Title = "Kayıt bulunamadı!";
                    rv.StatusCode = 404;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.ErrorCode = "GR1013";

                    return rv;
                }

                rv.DataCount = rv.Data.Count();
                rv.AnyData = true;
                rv.Title = "İşlem başarılı";
                rv.StatusCode = 200;

                return rv;
            }
        }

        public async Task<ReturnValue<T>> Update(T entity)
        {
            using (ReturnValue<T> rv = new ReturnValue<T>())
            {
                bool AnyData = AnyAsync(x => x.Id == entity.Id).Result.AnyData;
                if (!AnyData)
                {
                    rv.Title = "Kayıt bulunamadı!";
                    rv.StatusCode = 404;
                    rv.ErrorCode = "GR1014";
                    rv.DataCount = 0;
                    rv.AnyData = false;

                    return rv;
                }

                _context.Set<T>().Update(entity);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    rv.Title = "Bir hata meydana geldi";
                    rv.Text = "Lütfen daha sonra tekrar deneyiniz";
                    rv.Data = null;
                    rv.DataCount = 0;
                    rv.AnyData = false;
                    rv.StatusCode = 500;
                    rv.Exception = ex;
                    rv.ErrorCode = "GR1015";

                    return rv;
                }

                rv.Data = entity;
                rv.DataCount = 1;
                rv.AnyData = true;
                rv.Title = "İşlem başarılı";
                rv.StatusCode = 201;
                return rv;
            }
        }
    }
}
