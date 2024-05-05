using System;
using MyAuto.Controllers;


namespace MyAuto.Models
{
    public enum TypeCar
    {
        //Be careful!!!
        Sedan,
        SUV,
        Coupe,
        Hatchback,
        Convertible,
        Truck,
        Van
    }

    public class Car
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Model { get; set; }
        public int Speed { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public TypeCar Type { get; set; }

        // Имя файла изображения машины
        public string ImagePath { get; set; } 
    }

}
