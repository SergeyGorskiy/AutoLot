using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.EF;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;

namespace AutoLotTestDrive
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory car = new Inventory()
            {
                Color = "Pink",
                Id = 4,
                Make = "Mercedes",
                PetName = "Pinky"
            };
            AddNewRecord(car);
            using (var repo = new InventoryRepo())
            {
                foreach (Inventory c in repo.GetAll())
                {
                    Console.WriteLine(c);
                }
            }
            Console.ReadLine();
        }
        private static void AddNewRecord(Inventory car)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Add(car);
            }
        }
        private static void UpdateRecord(int carId)
        {
            using (var repo = new InventoryRepo())
            {
                var carToUpdate = repo.GetOne(carId);
                if (carToUpdate == null) return;
                carToUpdate.Color = "Blue";
                repo.Save(carToUpdate);
            }
        }
        private static void RemoveRecordByCar(Inventory carToDelete)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Delete(carToDelete);
            }
        }
        private static void RemoveRecordById(int carId, byte[] timeStamp)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Delete(carId, timeStamp);
            }
        }
    }
}
