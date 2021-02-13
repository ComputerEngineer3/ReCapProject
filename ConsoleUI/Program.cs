using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("");
            Console.WriteLine(" Fiat Cars");
            Console.WriteLine("--------------");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("");
            Console.WriteLine(" White Cars");
            Console.WriteLine("--------------");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("---------------------------------------------------");


            
            Car newCar = new Car { BrandId=9, ColorId=5, ModelYear=2019, DailyPrice=220, Description= "Audi Q3" };

            //carManager.Add(newCar);

            /*Console.WriteLine("");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }*/

        }
    }
}
