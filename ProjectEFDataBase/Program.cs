using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoLotDAL.EF;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;
using static System.Console;


namespace ProjectEFDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Using a Repository *****\n");
            using (var repo = new inventoryRepo())
            {
                foreach (inventory c in repo.GetAll())
                {
                    Console.WriteLine(c);
                }
            }

            ReadLine();
        }

        private static void AddNewRecord(inventory car)
        {
            // Добавить запись в таблицу Inventory базы данных AutoLot.
            using (var repo = new inventoryRepo())
            {
                repo.Add(car);
            }
        }


        private static void UpdateRecord(int carld)
        {
            using (var repo = new inventoryRepo())
            {
                // Извлечь запись об автомобиле, изменить ее и сохранить.
                var carToUpdate = repo.GetOne(carld);
                if (carToUpdate == null) return;
                carToUpdate.Color = "Blue";
                repo.Save(carToUpdate);
            }
        }

        private static void RemoveRecordByCar(inventory carToDelete)
        {
            using (var repo = new inventoryRepo())
            {
                repo.Delete(carToDelete);
            }
        }

        private static void RemoveRecordByld(int carld, byte[] timestamp)
        {
            using (var repo = new inventoryRepo())
            {
                repo.Delete(carld, timestamp);
            }
        }
    }
}