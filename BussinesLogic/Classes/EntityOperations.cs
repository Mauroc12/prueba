using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Classes;

namespace BussinesLogic.Classes
{
    public class EntityOperations
    {
        public static Boolean DoEntityOperation(int id)
        {
            Boolean response;
            CrudOperations Operation = new CrudOperations();
            response = Operation.RemoveProduct(id);
            return response;
        }



        public static Boolean DoEntityOperation(Products product, Boolean modify)
        {
            Boolean response;
            CrudOperations Operation = new CrudOperations();
            if (modify) 
            {
              response = Operation.EditProduct(product);
            }
            else
            {
              response = Operation.CreateProduct(product);
            }
            return response;

        }

    

        public static List<Products> getProducts(){
            CrudOperations Operation = new CrudOperations();

            List<Products> lp = Operation.getProduct();
              return lp;
    
    }

    }
}
