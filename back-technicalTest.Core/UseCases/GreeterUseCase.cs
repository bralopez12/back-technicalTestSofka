using back_technicalTest.Core.Entities;
using back_technicalTest.Core.Entities.Interfaces;
using back_technicalTest.Core.Exceptions;
using back_technicalTest.Entites;
using back_technicalTest.Entities.Commons;
using back_technicalTest.Entities.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_technicalTest.Core.UseCases
{
    public class GreeterUseCase
    {
        private readonly IGreeterAdapter greeterAdapter;

        public GreeterUseCase(IGreeterAdapter greeterAdapter)
        {
            this.greeterAdapter = greeterAdapter;
        }

        public async Task<GreeterResponse> Greet(GreeterDto greeterDto)
        {
            object idiom = null;
            if (!Enum.TryParse(typeof(IdiomType), greeterDto.Idiom, true, out idiom))
                throw new NotExistIdiomException("No existe el idioma");

            GreeterRequest greeterRequest = new GreeterRequest() { IdiomType = (IdiomType)idiom, ResponsesType = greeterDto.ResponseType };
            var greeterResponse = await greeterAdapter.GetGreet(greeterRequest);
            greeterResponse.Response += " " + greeterDto.Name;
            return greeterResponse;
        }
    }
}
