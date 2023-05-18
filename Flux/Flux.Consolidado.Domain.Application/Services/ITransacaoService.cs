namespace Flux.Consolidado.Domain.Application.Services
{
    public interface ITransacaoService : IDisposable
    {
        void Iniciar();
        void Comitar();
        void Reverter();
    }
}
