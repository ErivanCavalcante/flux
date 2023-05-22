using Flux.Consolidado.Domain.Application.Features.Consolidado.Commands.Criar;
using Flux.Consolidado.Domain.Application.Repositories;
using Flux.Consolidado.Domain.Application.Services;
using Moq;

namespace Flux.Consolidado.Test.Features
{
    public class ConsolidadoTest
    {
        [Fact]
        public async void Is_Criar_Consolidado_Return_True()
        {
            // Arrange
            var transacaoService = new Mock<ITransacaoService>();
            var consolidadoRepository = new Mock<IConsolidadoRepository>();
            consolidadoRepository.Setup(x => x.PegarUltimo()).ReturnsAsync(new Domain.Entity.Entities.Consolidado 
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                DataCriacao = DateTime.Now,
                Saldo = 555,
            });

            var request = new CriarConsolidadoRequest(Domain.Entity.Enums.TipoMovimentacao.RECEITA, 100);

            var command = new CriarConsolidadoCommand(transacaoService.Object, consolidadoRepository.Object);

            // Act
            var result = await command.Handle(request, new CancellationToken());

            // Assert
            Assert.True(result);
        }
    }
}
