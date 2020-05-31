using System.Collections.Generic;
using System.Linq;
using Team4CAProject.DB;
using Team4CAProject.Models;

namespace Team4CAProject.Services
{
    public class BrowseService
    {
        protected CADb dbcontext;
        public BrowseService(CADb db)
        {
            this.dbcontext = db;
        }
      public List<Product> GetProducts(string query)
        {
            List<Product> products = dbcontext.Products.ToList();
            {
                if (query == "" || query == null)
                {
                    return dbcontext.Products.ToList();
                }

                return dbcontext.Products.Where(p =>
                        p.Name.ToLower().Contains(query.ToLower()) ||
                        p.Desc.ToLower().Contains(query.ToLower()))
                    .ToList();
            }
        }

    }
    
}
