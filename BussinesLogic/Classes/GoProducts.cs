using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Classes;
using Data;


namespace BussinesLogic.Classes
{

    public class GoProducts
    {
        public static List<ProductItem> LosProducts()
        {
            SearchProducts sp = new SearchProducts();
            List<ProductItem> LProducts = sp.ReturnProducts();
            return LProducts;
        }
    }
     public class GoProducts123
    {
        public static List<ProductItem> LosProducts()
        {
            SearchProducts sp = new SearchProducts();
            List<ProductItem> LProducts = sp.ReturnProducts();
            return LProducts;
        }
    }
}
