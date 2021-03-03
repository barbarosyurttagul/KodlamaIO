using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Car ID:{car.Id}, Brand ID: {car.BrandId}, Color ID: {car.ColorId}, Model Year: {car.ModelYear}, Daily Price: {car.DailyPrice}, Description: {car.Description}");
            }

            Console.WriteLine($"Id si 1 olan arabanın Model Yılı {carManager.GetById(1).ModelYear}, Günlük Fiyatı: {carManager.GetById(1).DailyPrice}");
            
            Console.WriteLine("Hello World!");
        }
    }
}
