using System;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;


namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager brandManager = new BrandManager(new UnitOfWork());

            var data = brandManager.GetAll().Data;
        
           
            foreach (var brand in data)
            {
                Console.WriteLine(brand.Name);
            }
        }
    }
}
