using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Testes
{
    public class HttpClientPetTest
    {
        [Fact]
        public async Task ListaPetsDeveRetornarUmaListaNaoVazia()
        {
            var clientPet = new HttpClientPet();

            var lista = await clientPet.ListaPetsAsync();

            Assert.NotNull(lista);
            Assert.IsNotEmpty(lista);

        }

        [Fact]
        public async Task QuandoAPIForaDeveRetornarExcecao()
        {
            var clientPet = new HttpClientPet();

            await Assert.ThrowsAsync<Exception>(() => clientPet.ListPetsAsync());

        }
    }
}