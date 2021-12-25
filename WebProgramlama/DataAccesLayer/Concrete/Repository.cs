using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using DataAccesLayer.Abstract;

namespace DataAccesLayer.Concrete
{

    public class Repository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;
        public Repository()
        {
            _object = c.Set<T>();
        }

        public int Delete(T p)
        {
            _object.Remove(p);
            return c.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public int Insert(T p)
        {
            _object.Add(p);
            return c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _object.Where(where).ToList();
        }

        public int Update(T p)
        {
            return c.SaveChanges();
        }

//        public List<CategoryListeleme> KategorileriTekGetir()
//        {
//            var sql = @"select c.CategoryID,c.CategoryName,
//(select top(1) b.BlogTitle from Blogs b where b.CategoryID=c.CategoryID order by b.BlogID desc) as BlogTitle,
//(select top(1) b.BlogImage from Blogs b where b.CategoryID=c.CategoryID order by b.BlogID desc) as BlogImage,
//(select top(1) b.BlogContent from Blogs b where b.CategoryID=c.CategoryID order by b.BlogID desc) as BlogContent,
//(select top(1) b.BlogID from Blogs b where b.CategoryID=c.CategoryID order by b.BlogID desc) as BlogID
//from Categories c";


//            var sorgu = c.Database.SqlQuery<CategoryListeleme>(sql).ToList();

//            return sorgu;
//        }
        //public List<Dondur> TerstenBlogList()
        //{
        //    var sql1 = @"select BlogID From Blogs order by BlogID desc";

        //    var dondur = c.Database.SqlQuery<Dondur>(sql1).ToList();
        //    return dondur;


        //}
    }
}

