using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoLotDAL.EF;
using AutoLotDAL.Models;
using static System.Console;


namespace ProjectEFDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*****Fun with ADO.NET EF * ****\n");
            Database.SetInitializer(new MyDataInitializer());
            Console.WriteLine("*****Fun with ADO.NET EF Code First * ****\n");
            using (var context = new AutoLotEntities())
            {
                foreach (inventory c in context.inventory)
                {
                    Console.WriteLine(c);
                }
            }
            Console.ReadLine();
            ReadLine();
        }

        //private static int AddNewRecord()
        //{
        //    // Добавить запись в таблицу Inventory базы данных AutoLot.
        //    using (var context = new AutoLotEntities())
        //    {
        //        try
        //        {
        //            // В целях тестирования жестко закодировать данные для новой записи,
        //            var car = new Car()
        //            {
        //                Make = "Yugo",
        //                Color = "Brown",
        //                CarNickName = "Brownie"
        //            };
        //            context.Cars.Add(car);
        //            context.SaveChanges();
        //            // В случае успешного сохранения EF заполняет поле идентификатора
        //            // значением, сгенерированным базой данных,
        //            return car.CarId;
        //        }
        //        catch (Exception ex)
        //        {
        //            WriteLine(ex.InnerException?.Message);
        //            return 0;
        //        }
        //    }
        //}

        //private static void AddNewRecords(IEnumerable<Car> carsToAdd)
        //{
        //    using (var context = new AutoLotEntities())
        //    {
        //        context.Cars.AddRange(carsToAdd);
        //        context.SaveChanges();
        //    }
        //}

        //private static void PrintAllInventory()
        //{
        //    // Выбрать все элементы из таблицы Inventory базы данных AutoLot
        //    // и вывести данные с применением специального метода ToString()
        //    // сущностного класса Саг.
        //    using (var context = new AutoLotEntities())
        //    {
        //        foreach (Car c in context.Cars)
        //        {
        //            WriteLine(c);
        //        }
        //    }
        //}

        //private static void PrintAllInventory(Expression<Func<Car, Boolean>> predicate)
        //{
        //    //Параметризованный метод, более гибкий
        //    using (var context = new AutoLotEntities())
        //    {
        //        foreach (Car c in context.Cars.Where(predicate))
        //        {
        //            WriteLine(c);
        //        }
        //    }
        //}

        //private static void FunWithLinqQueries()
        //{
        //    using (var context = new AutoLotEntities())
        //    {
        //        // Получить проекцию новых данных
        //        var colorsMakes = from item in context.Cars
        //            select new {item.Color, item.Make};
        //        foreach (var item in colorsMakes)
        //        {
        //            WriteLine(item);
        //        }

        //        // Получить только элементы, в которых Color == "Black".
        //        var blackCars = from item in context.Cars
        //            where item.Color == "Black"
        //            select item;
        //        foreach (var item in blackCars)
        //        {
        //            WriteLine(item);
        //        }
        //    }
        //}

        //private static void IncludeQueries()
        //{
        //    using (var context = new AutoLotEntities())
        //    {
        //        foreach (Car c in context.Cars.Include(c => c.Orders))
        //        {
        //            foreach (Order o in c.Orders)
        //            {
        //                WriteLine(o.Orderld);
        //            }
        //        }
        //    }
        //}

        //private static void RemoveRecord(int carld)
        //{
        //    // Найти запись об автомобиле, подлежащую удалению, по первичному ключу,
        //    using (var context = new AutoLotEntities())
        //    {
        //        // Проверить наличие записи.
        //        Car carToDelete = context.Cars.Find(carld);
        //        if (carToDelete != null)
        //        {
        //            context.Cars.Remove(carToDelete);
        //            // Этот код предназначен чисто для демонстрации того,
        //            // что состояние сущности изменилось на Deleted,
        //            if (context.Entry(carToDelete).State != EntityState.Deleted)
        //            {
        //                throw new Exception("Unable to delete the record");
        //            }
        //        }

        //        context.SaveChanges();
        //    }
        //}
    }
}