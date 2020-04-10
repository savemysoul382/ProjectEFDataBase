using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProjectEFDataBase.EF;
using static System.Console;

namespace ProjectEFDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*****Fun with ADO.NET EF * ****\n");
            PrintAllInventory();
            ReadLine();
        }

        private static int AddNewRecord()
        {
            // Добавить запись в таблицу Inventory базы данных AutoLot.
            using (var context = new AutoLotEntities())
            {
                try
                {
                    // В целях тестирования жестко закодировать данные для новой записи,
                    var car = new Car()
                    {
                        Make = "Yugo",
                        Color = "Brown",
                        CarNickName = "Brownie"
                    };
                    context.Cars.Add(car);
                    context.SaveChanges();
                    // В случае успешного сохранения EF заполняет поле идентификатора
                    // значением, сгенерированным базой данных,
                    return car.CarId;
                }
                catch (Exception ex)
                {
                    WriteLine(ex.InnerException?.Message);
                    return 0;
                }
            }
        }

        private static void AddNewRecords(IEnumerable<Car> carsToAdd)
        {
            using (var context = new AutoLotEntities())
            {
                context.Cars.AddRange(carsToAdd);
                context.SaveChanges();
            }
        }

        private static void PrintAllInventory()
        {
            // Выбрать все элементы из таблицы Inventory базы данных AutoLot
            // и вывести данные с применением специального метода ToString()
            // сущностного класса Саг.
            using (var context = new AutoLotEntities())
            {
                foreach (Car c in context.Cars)
                {
                    WriteLine(c);
                }
            }
        }

        private static void PrintAllInventory(Expression<Func<Car, Boolean>> predicate)
        {
            //Параметризованный метод, более гибкий
            using (var context = new AutoLotEntities())
            {
                foreach (Car c in context.Cars.Where(predicate))
                {
                    WriteLine(c);
                }
            }
        }

        private static void FunWithLinqQueries()
        {
            using (var context = new AutoLotEntities())
            {
                // Получить проекцию новых данных
                var colorsMakes = from item in context.Cars select new {item.Color, item.Make};
                foreach (var item in colorsMakes)
                {
                    WriteLine(item);
                }
                // Получить только элементы, в которых Color == "Black".
                var blackCars = from item in context.Cars where item.Color == "Black"
                    select item;
                foreach (var item in blackCars)
                {
                    WriteLine(item);
                }
            }
        }
    }
}