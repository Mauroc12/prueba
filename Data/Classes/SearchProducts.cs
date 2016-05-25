using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes
{
    public class SearchProducts
    {
        public List<ProductItem> ReturnProducts()
        {
            List<ProductItem> LProduct = new List<ProductItem>();
            try
            {
                using (NorthwindEntities context = new NorthwindEntities())
                {
                    var query = from p in context.Products
                                join c in context.Categories on p.CategoryID equals c.CategoryID
                                select new ProductItem
                                {
                                    ProductID = p.ProductID,
                                    ProductName = p.ProductName,
                                    UnitPrice = (Decimal)p.UnitPrice,
                                    CategoryName = c.CategoryName
                                };

                    LProduct = query.ToList();
                }
            }
            catch (EntityException e) { Console.WriteLine(e.ToString()); };
            return LProduct;

        }

    }
}