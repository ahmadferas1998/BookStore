using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public interface ICategoryServices
    {
        void deletcategory(int dep_id);
        List<Category> insertcategories();
        void addCategore(Category cat);
        Category load(int id);
        void Ubdate(Category cat);
    }
}
