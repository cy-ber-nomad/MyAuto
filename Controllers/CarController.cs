using Microsoft.AspNetCore.Mvc;
using MyAuto.Models;
using System.Linq;

namespace MyAuto.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;



        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult UpdateImagePaths()
        {
            string[] imagePaths = new string[]
            {
            "/images/BMW X5.jpg",
            "/images/Mercedes-Benz E-Class.jpg",
            "/images/BMW 3 Series.jpg",
            "/images/Mercedes-Benz S-Class.jpg",
            "/images/BMW 7 Series.jpg",
            "/images/Mercedes-Benz C-Class.jpg",
            "/images/BMW Z3.jpg",
            "/images/BMW M3.jpg",
            "/images/Mercedes-Benz SLK-Class.jpg",
            "/images/Mercedes-Benz CLK-Class.jpg",
            "/images/Mercedes-Benz SLK-Class.jpg",
                // Добавьте остальные пути к изображениям для остальных машин
            };

            for (int i = 1; i <= 10; i++)
            {
                string imagePath = imagePaths[i - 1]; // Получаем путь к изображению для текущей машины

                var car = _context.Cars.Find(i); // Находим машину по идентификатору
                if (car != null)
                {
                    // Проверяем, что значение ImagePath не равно null перед установкой
                    if (car.ImagePath == null)
                    {
                        car.ImagePath = imagePath; // Устанавливаем путь к изображению
                    }
                }
            }

            _context.SaveChanges(); // Сохраняем все изменения в базе данных

            return RedirectToAction("Index", "Home"); // Перенаправляем на главную страницу 
        }

        /*public IActionResult GetCarInfo(int carId)
        {
            var car = _context.Cars.Find(carId);
            if (car == null)
            {
                return NotFound(); // Если машина не найдена, вернуть ошибку 404
            }

            var carInfo = new
            {
                description = car.Description,
                createDate = car.CreateDate.ToShortDateString(),
                speed = car.Speed,
                type = car.Type
            };

            return Json(carInfo); // Возвращаем информацию о машине в формате JSON
        }*/

        [HttpGet]
        public IActionResult GetCarInfo(int carId)
        {
            var car = _context.Cars.Find(carId);
            if (car == null)
            {
                return NotFound(); // Машина не найдена
            }

            return Ok(car); // Возвращаем данные машины в формате JSON
        }



        [HttpGet]
        public IActionResult Details(int id)
        {
            var car = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound(); // Вернуть HTTP 404 Not Found, если машина не найдена
            }

            return PartialView("_CarDetails", car);
        }


        public IActionResult Index()
        {
            // Извлечение всех машин из базы данных
            var cars = _context.Cars.ToList();

            // Передача списка машин в представление
            return View(cars);
        }
    }
}
