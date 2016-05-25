using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    public class ProductItem
    {
        private string categoryName;
        private int productID;
        private string productName;
        private decimal unitPrice;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }



    }
}