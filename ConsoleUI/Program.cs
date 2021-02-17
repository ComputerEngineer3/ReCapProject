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
            //TestAddNewCar(carManager);
            //TestCarsListing();

            //CrudOperationsTestForColors();
            //CrudOperationsTestForBrands();

            CrudOperationsTestForCars();

        }

        private static void CrudOperationsTestForCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }
            Console.WriteLine("-----");
            Console.WriteLine(carManager.GetById(1).Description);
            Car carNew = new Car { BrandId = 11, ColorId = 3, ModelYear = 2019, DailyPrice = 280, Description = "Kia Sorento" };
            carManager.Insert(carNew);
            Console.WriteLine("-----");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }
            Console.WriteLine("-----");
            carManager.Update(carNew);
            carManager.Delete(carNew);
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }
            Console.WriteLine("-----");
        }

        private static void CrudOperationsTestForBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine("-----");
            Console.WriteLine(brandManager.GetById(1).Name);
            Brand newBrand = new Brand() { Name = "Toyota" };
            brandManager.Insert(newBrand);
            Console.WriteLine("-----");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine("-----");
            brandManager.Update(newBrand);
            brandManager.Delete(newBrand);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine("-----");
        }

        private static void CrudOperationsTestForColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine("-----");
            Console.WriteLine(colorManager.GetById(1).Name);
            Color newColor = new Color() { Name = "Mavi" };
            colorManager.Insert(newColor);
            Console.WriteLine("-----");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine("-----");
            colorManager.Update(newColor);
            colorManager.Delete(newColor);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
            Console.WriteLine("-----");
        }

        private static void TestCarsListing()
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
        }

        private static void TestAddNewCar(CarManager carManager)
        {
            Car newCar = new Car { BrandId = 9, ColorId = 5, ModelYear = 2019, DailyPrice = 220, Description = "Audi Q3" };

            carManager.Insert(newCar);

            Console.WriteLine("");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
