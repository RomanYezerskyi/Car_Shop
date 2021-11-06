using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category() {categoryName = "Electric cars", desc = "A new kind od cars"},
                    new Category() {categoryName = "Classic cars", desc = "Cars with an internal combustion engine"}
                };
            }
        }
    }
}
