using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>()
            { new Category {CategoryID=1, CategoryName="Bilgisayar"},
              new Category {CategoryID=2, CategoryName="Telefon"}
            };
            List<Product> products = new List<Product>()
            {
                new Product { ProductID=1,CategoryID=1,ProductName="Acer laptop",QuantityPerUnit="32GB RAM",UnitPrice=100000,UnitsInStok=5},
                new Product { ProductID=2,CategoryID=1,ProductName="Asus laptop",QuantityPerUnit="16GB RAM",UnitPrice=8000,UnitsInStok=3},
                new Product { ProductID=3,CategoryID=1,ProductName="HP laptop",QuantityPerUnit="8GB RAM",UnitPrice=6000,UnitsInStok=2},
                new Product { ProductID=4,CategoryID=2,ProductName="Samsung Telephone",QuantityPerUnit="4GB RAM",UnitPrice=3000,UnitsInStok=15},
                new Product { ProductID=5,CategoryID=2,ProductName="Apple Telephone",QuantityPerUnit="4GB RAM",UnitPrice=8000,UnitsInStok=0},
                new Product { ProductID=6,CategoryID=2,ProductName="Huawei Telephone",QuantityPerUnit ="12GB RAM", UnitPrice=7000,UnitsInStok=0}

            };


            var result = from p in products  // productsı p aliası ile dolaş
                         join c in categories // categoriesı c aliası ile olaş 
                         on p.CategoryID == 1 equals c.CategoryID == 1 // p aliasında CategoryID  1 e c aliasında  CategoryID  1 e eşit olanı al 
                         select new ProductDto { ProductID = p.ProductID, ProductName = p.ProductName, CategoryName = c.CategoryName };
      
            foreach (var ProductDto in result)
            {
                Console.WriteLine("{0}------{1}", ProductDto.ProductName, ProductDto.CategoryName);

            }
            Console.ReadLine();





        }

        class ProductDto //data transfer object
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string CategoryName { get; set; }
            public int UnitPrice { get; set; }
        }
        class Product
        {
            public int ProductID { get; set; }
            public int CategoryID { get; set; }
            public string ProductName { get; set; }
            public string QuantityPerUnit { get; set; } //Ürün açıklaması
            public decimal UnitPrice { get; set; } // birim fiyatı
            public int UnitsInStok { get; set; } // ürünün stok adedi

        }
        class Category
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
        }


    }
}

