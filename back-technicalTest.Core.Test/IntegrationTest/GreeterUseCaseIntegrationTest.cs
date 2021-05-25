using back_technicalTest.Core.Entities;
using back_technicalTest.Core.Exceptions;
using back_technicalTest.Core.UseCases;
using back_technicalTest.Entites;
using back_technicalTest.Entities.Commons;
using back_technicalTest.Entities.Entities.Interfaces;
using back_technicalTest.Infrastructure.Data;
using back_technicalTest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace back_technicalTest.Core.Test.IntegrationTest
{
    public class GreeterUseCaseIntegrationTest
    {
        private readonly GreeterUseCase greeterUseCase;
        private readonly GreeterDbContext context;
        public GreeterUseCaseIntegrationTest()
        {
            var optionBuilder = new DbContextOptionsBuilder<GreeterDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            context = new GreeterDbContext(optionBuilder);
            greeterUseCase = new GreeterUseCase(new GreeterAdapter(context));
            InitDataDB();
        }

        private void InitDataDB()
        {
            List<ResponsesGreeter> responsesGreeters = new List<ResponsesGreeter>()
            {
                new ResponsesGreeter() { Response = "Saludos",Code = (int)ResponseType.Greet,Description = "Hola",Idiom = (int)IdiomType.spanish}, 
                new ResponsesGreeter() { Response = "Hello",Code = (int)ResponseType.Greet,Description = "Saludo en ingles",Idiom = (int)IdiomType.english} ,
                new ResponsesGreeter() { Response = "Adios",Code = (int)ResponseType.SayGoodBye,Description = "Despido en español",Idiom = (int)IdiomType.spanish},
                new ResponsesGreeter() { Response = "Bye",Code = (int)ResponseType.SayGoodBye,Description = "Despido en ingles",Idiom = (int)IdiomType.english}
            };
            context.AddRange(responsesGreeters);
            context.SaveChanges();
        }

        /// <summary>
        /// Shoulds the response greet.
        /// </summary>
        [Fact]
        public async Task shouldResponseGreet()
        {
            //Arrange
            ResponseType responseType = ResponseType.Greet;
            IdiomType idiomType = IdiomType.spanish;
            var greeterDtoDataTest = new GreeterDto() { Idiom = idiomType.ToString(), ResponseType = responseType, Name = "Arturo" };
            //Act
            var resp = await greeterUseCase.Greet(greeterDtoDataTest);
            //Assert
            Assert.Equal(context.ResponsesGreeter.FirstOrDefault(r => r.Code == (int)responseType && r.Idiom == (int)idiomType).Response + " " + greeterDtoDataTest.Name, resp.Response);
        }

        /// <summary>
        /// Shoulds the exception by idiom not exist.
        /// </summary>
        [Fact]
        public async Task shouldResponseSayGood()
        {
            //Arrange
            ResponseType responseType = ResponseType.SayGoodBye;
            IdiomType idiomType = IdiomType.english;
            var greeterDtoDataTest = new GreeterDto() { Idiom = idiomType.ToString(), ResponseType = responseType, Name = "Arturo" };
            //Act
            var resp = await greeterUseCase.Greet(greeterDtoDataTest);
            //Assert
            Assert.Equal(context.ResponsesGreeter.FirstOrDefault(r => r.Code == (int)responseType && r.Idiom == (int)idiomType).Response + " " + greeterDtoDataTest.Name, resp.Response);
        }
    }
}
