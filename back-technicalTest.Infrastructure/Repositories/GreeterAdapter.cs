using back_technicalTest.Core.Entities;
using back_technicalTest.Entites;
using back_technicalTest.Entities.Entities.Interfaces;
using back_technicalTest.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace back_technicalTest.Infrastructure.Repositories
{
    public class GreeterAdapter : IGreeterAdapter
    {
        private readonly GreeterDbContext greeterDbContext;


        public GreeterAdapter(GreeterDbContext greeterDbContext)
        {
            this.greeterDbContext = greeterDbContext;
        }

        public async Task<GreeterResponse> GetGreet(GreeterRequest greeterRequest)
        {
            var responsesGreeter = greeterDbContext.ResponsesGreeter.FirstOrDefault(r => r.Code == (int)greeterRequest.ResponsesType && r.Idiom == (int)greeterRequest.IdiomType);
            return new GreeterResponse() { Response = responsesGreeter.Response};
        }

    }
}
