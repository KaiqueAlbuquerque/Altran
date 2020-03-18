using Business.Models;
using System.Threading.Tasks;

namespace Business.Interfaces.Service
{
    public interface ICarService : IService<Car>
    {
        string GetByPlaque(string plaque);
    }
}
