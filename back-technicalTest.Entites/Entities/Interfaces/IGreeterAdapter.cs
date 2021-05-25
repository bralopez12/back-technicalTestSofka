using back_technicalTest.Core.Entities;
using back_technicalTest.Entites;
using System.Threading.Tasks;

namespace back_technicalTest.Entities.Entities.Interfaces
{
    public interface IGreeterAdapter
    {
        Task<GreeterResponse> GetGreet(GreeterRequest greeterRequest);
    }
}