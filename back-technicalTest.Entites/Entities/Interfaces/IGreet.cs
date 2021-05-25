using back_technicalTest.Entities.Commons;
using System.Threading.Tasks;

namespace back_technicalTest.Core.Entities.Interfaces
{
    public interface IGreet
    {
        public ResponseType ResponseType { get; }
        public IdiomType Idiom { get; }

        Task<GreeterResponse> Response(GreeterDto greeterDto);
    }
}
