using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RManager
    {
       

            Repository<Author> repoau = new Repository<Author>();

            public List<Author> GetAll()
            {
                return repoau.List();
            }

            public List<Author> GetAuthorByID(int id)
            {
                return repoau.List(x => x.AuthorID == id);
            }
            
            public int AuthorAddBL(Author p)
            {
                
                return repoau.Insert(p);
            }
            //public int DeleteBlogBL(int p)
            //{
            //    Blog blog = repoblog.Find(x => x.BlogID == p);
            //    return repoblog.Delete(blog);

            //}
            //public List<Blog> BlogByStatusTrue(List<Blog> authorblogs)
            //{
            //    return repoblog.List(x => x.BlogStatus == true);
            //}
            //public List<Blog> BlogByStatusFalse()
            //{
            //    return repoblog.List(x => x.BlogStatus == false);
            //}
            //public int BlogStatusChangeToFalse(int id)
            //{
            //    Blog blog = repoblog.Find(x => x.BlogID == id);

            //    blog.BlogStatus = false;

            //    return repoblog.Update(blog);
            //}
            //public Blog FindBlog(int id)
            //{
            //    return repoblog.Find(x => x.BlogID == id);
            //}
            //public int UpdateBlog(Blog p)
            //{
            //    Blog blog = repoblog.Find(x => x.BlogID == p.BlogID);

            //    blog.BlogTitle = p.BlogTitle;
            //    blog.BlogContent = p.BlogContent;
            //    //blog.CategoryID = p.CategoryID;
            //    blog.BlogDate = p.BlogDate;
            //    blog.BlogImage = p.BlogImage;
            //    blog.AuthorID = p.AuthorID;
            //    // blog.ButtonOnOf = p.ButtonOnOf;
            //    // blog.ButtonTitle = p.ButtonTitle;
            //    // blog.ButtonUrl = p.ButtonUrl;
            //    return repoblog.Update(blog);
            //}

            //public List<CategoryListeleme> KategorileriTekGetir()
            //{
            //    return repoblog.KategorileriTekGetir();
            //}
            ////public List<Dondur> TerstenBlogList()
            ////{
            ////    return repoblog.TerstenBlogList();
            ////}

        

    }
}
