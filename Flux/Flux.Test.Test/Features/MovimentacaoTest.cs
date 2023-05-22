using Flux.Lancamento.Domain.Application.Features.Movimentacao.Commands.Criar;
using Flux.Lancamento.Domain.Application.Features.Shared.Responses.Consolidado;
using Flux.Lancamento.Domain.Application.Repositories;
using Flux.Lancamento.Domain.Application.Repositories.Consolidado;
using Flux.Lancamento.Domain.Application.Services;
using Flux.Lancamento.Domain.Entity.Entities;
using Flux.Lancamento.Domain.Entity.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flux.Lancamento.Test.Features
{
    public class MovimentacaoTest
    {
        [Fact]
        public async void Is_Criar_Movimentacao_Return_True()
        {
            // Arrange
            var transacaoService = new Mock<ITransacaoService>();
            var consolidadoRepository = new Mock<IConsolidadoRepository>();
            var movimentacaoRepository = new Mock<IMovimentacaoRepository>();

            consolidadoRepository.Setup(x => x.CriarConsolidado(It.IsAny<CriarConsolidadoDto>())).ReturnsAsync(new Refit.ApiResponse<bool>(new HttpResponseMessage(System.Net.HttpStatusCode.OK), true, new Refit.RefitSettings()));

            var request = new CriarMovimentacaoRequest(TipoMovimentacao.RECEITA, "Teste de descrição", 100);

            var command = new CriarMovimentacaoCommand(transacaoService.Object, consolidadoRepository.Object, movimentacaoRepository.Object);

            // Act
            var result = await command.Handle(request, new CancellationToken());

            // Assert
            Assert.True(result);
        }
    }
}
