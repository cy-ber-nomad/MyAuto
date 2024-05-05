using Microsoft.EntityFrameworkCore;

namespace MyAuto.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }


        internal object GetCarById(int carId)
        {
            throw new NotImplementedException();
        }

        // Другие DbSet'ы для ваших сущностей, если они есть
    }
}
