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
    //Agregue 1
    //Agregue 2
    //Agregue 2
    //Le quite a este marica el comentario
    public class GreeterUseCase
    {
        /// <summary>
        /// The greeter adapter
        /// </summary>
        private readonly IGreeterAdapter greeterAdapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="GreeterUseCase"/> class.
        /// </summary>
        /// <param name="greeterAdapter">The greeter adapter.</param>
        public GreeterUseCase(IGreeterAdapter greeterAdapter)
        {
            this.greeterAdapter = greeterAdapter;
        }

        /// <summary>
        /// response with a greet
        /// </summary>
        /// <param name="greeterDto">The greeter dto.</param>
        /// <returns></returns>
        /// <exception cref="back_technicalTest.Core.Exceptions.NotExistIdiomException">No existe el idioma</exception>
        public async Task<GreeterResponse> Greet(GreeterDto greeterDto)
        {
            //Selecting the idiom received in enum
            object idiom = null;
            if (!Enum.TryParse(typeof(IdiomType), greeterDto.Idiom, true, out idiom))
                throw new NotExistIdiomException("No existe el idioma");
            
            GreeterRequest greeterRequest = new GreeterRequest() { IdiomType = (IdiomType)idiom, ResponsesType = greeterDto.ResponseType };
            var greeterResponse = await greeterAdapter.GetGreet(greeterRequest);

            //concatenate name with response
            greeterResponse.Response += " " + greeterDto.Name;

            return greeterResponse;
        }
    }
}
