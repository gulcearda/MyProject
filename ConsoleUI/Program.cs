using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    //SOLID
    //Open Closed Principle

    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();


            Console.WriteLine("Gulo");

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {

            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));

            var result = productManager.GetProductDetailDtos();
            if (result.Success == true)
            {
                foreach (var product in productManager.GetProductDetailDtos().Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }

            }

            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
