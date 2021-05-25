using back_technicalTest.Core.Entities;
using back_technicalTest.Core.Exceptions;
using back_technicalTest.Core.UseCases;
using back_technicalTest.Entites;
using back_technicalTest.Entities.Commons;
using back_technicalTest.Entities.Entities.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace back_technicalTest.Core.Test
{
    public class GreeterUseCaseTest
    {
        private readonly Mock<IGreeterAdapter> mockGreeterAdapter;
        private readonly GreeterUseCase greeterUseCase;
        public GreeterUseCaseTest()
        {
            this.mockGreeterAdapter = new Mock<IGreeterAdapter>();
            greeterUseCase = new GreeterUseCase(mockGreeterAdapter.Object);
        }

        /// <summary>
        /// Shoulds the response greet.
        /// </summary>
        [Fact]
        public async Task shouldResponseGreet()
        {
            //Arrange
            string greet = "Bienvenido";
            var greeterResponseDataTest = new GreeterResponse()
            {
                Response = greet
            };

            var greeterDtoDataTest = new GreeterDto() { Idiom = "spanish", ResponseType = ResponsesType.Greet, Name = "Arturo" };
            mockGreeterAdapter.Setup(m => m.GetGreet(It.IsAny<GreeterRequest>())).ReturnsAsync(greeterResponseDataTest);
            //Act
            var resp = await greeterUseCase.Greet(greeterDtoDataTest);
            //Assert
            Assert.Equal(greet.ToString() + " " + greeterDtoDataTest.Name, resp.Response);
        }

        /// <summary>
        /// Shoulds the exception by idiom not exist.
        /// </summary>
        [Fact]
        public async Task shouldExceptionByIdiomNotExist()
        {
            //Arrange
            string greet = "Bienvenido";
            var greeterResponseDataTest = new GreeterResponse()
            {
                Response = greet
            };

            var greeterDtoDataTest = new GreeterDto() { Idiom = "UnIdioma", ResponseType = ResponsesType.Greet, Name = "Arturo" };
            mockGreeterAdapter.Setup(m => m.GetGreet(It.IsAny<GreeterRequest>())).ReturnsAsync(greeterResponseDataTest);
            //Act
            var resp = await Assert.ThrowsAsync<NotExistIdiomException>(async () => { await greeterUseCase.Greet(greeterDtoDataTest); } );
            //Assert
            Assert.Equal("No existe el idioma",resp.Message);
        }
    }
}
