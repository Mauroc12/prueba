using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{

    public class Product
    {
        
        private string categoryName; 
        private int productID;       
        private string productName;
        private decimal unitPrice;       
        private int productQuantity;    
        private decimal totalPrice;



        [Required( ErrorMessage = "Este Campo es Obligatorio")]
        [DisplayName("Categoria")]
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }


        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        [DisplayName("ID")]
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }


        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        [DisplayName("Producto")]
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }


        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        [DisplayName("Precio")]
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }


        [Range(1,int.MaxValue, ErrorMessage = "Ingrese un numero valido")]
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        [DisplayName("Cantidad")]
        public int ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; }
        }


        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        [DisplayName("Total")]
        public decimal TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }


        public static decimal CalculateAmount (List<Product> lp)
        {
            decimal total=0;
            foreach (Product p in lp)
            {
                total += p.totalPrice;
            }
            return total;
        }

  

    }
}
