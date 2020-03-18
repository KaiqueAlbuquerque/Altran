using Business.Interfaces;
using Business.Models;
using Data.Context;

namespace Data.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(MyDbContext context) : base(context) { }
    }
}
