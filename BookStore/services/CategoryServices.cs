using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class CategoryServices:ICategoryServices
    {
        BookContext BookContext;
        public CategoryServices(BookContext _BookContext)
        {

      BookContext = _BookContext;

        }
  

        public List<Category> insertcategories ()
        {
            List<Category> li = BookContext.Categorys.ToList();


            return li;
        }
        public void deletcategory(int dep_id)
        {
            Category category = BookContext.Categorys.Find(dep_id);
            BookContext.Categorys.Remove(category);
            BookContext.SaveChanges();

        }

        public void addCategore(Category cat)
        {
            BookContext.Categorys.Add(cat);
            BookContext.SaveChanges();

        }

        public Category load(int id)
        {

            Category category= BookContext.Categorys.Find(id);

            return category;
        }
        public void Ubdate(Category cat)
        {
            BookContext.Categorys.Attach(cat);
            BookContext.Entry(cat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            BookContext.SaveChanges();

        }
    }
}
