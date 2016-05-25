using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Classes
{
    public class CrudOperations
    {
        private NorthwindEntities context = new NorthwindEntities();

        public Boolean RemoveProduct(int id)
        {
            Boolean Response = true;

            try
            {
                Products product = context.Products.Find(id);
                if (product == null)
                {
                    Response = false;
                }
                else
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
            catch (EntityCommandCompilationException) { Response = false; }
            catch (EntitySqlException) { Response = false; }
            catch (EntityException) { Response = false; }

            return Response;
        }




        public Boolean CreateProduct(Products product)
        {
            Boolean Response = true;
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (EntityCommandCompilationException) { Response = false; }
            catch (EntitySqlException) { Response = false; }
            catch (EntityException) { Response = false; }

            return Response;
        }




        public Boolean EditProduct(Products product)
        {
            Boolean Response = true;
            try
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (EntityCommandCompilationException) { Response = false; }
            catch (EntitySqlException) { Response = false; }
            catch (EntityException) { Response = false; }

            return Response;
        }


        public List<Products> getProduct()
        { 
            List<Products> lp = new List<Products>();
            try
            {
                var query = from p in context.Products select p;
               lp = query.ToList();
               
            }
            catch (EntityException e) { Console.WriteLine(e.ToString()); };
            return lp;
        }

        
    }

}