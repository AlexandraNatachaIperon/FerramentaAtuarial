using Atuarial.Models;

namespace Atuarial.Interface
{
    public interface IAtuarialService
    {
        Task<List<AtuarialLista>> ObterListaDeServidoresAsync(string link);
        Task<List<AtuarialLista>> ObterServidoresComum(List<AtuarialLista> lista1, List<AtuarialLista> lista2);
        Task<List<AtuarialLista>> ObterServidoresDiferentes(List<AtuarialLista> lista1, List<AtuarialLista> lista2);
    }
}
