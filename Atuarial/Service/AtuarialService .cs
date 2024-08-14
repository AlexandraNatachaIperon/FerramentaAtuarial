using Atuarial.Interface;
using Atuarial.Models;

namespace Atuarial.Service
{
    public class AtuarialService : IAtuarialService
    {
        private readonly HttpClient _httpClient;

        public AtuarialService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AtuarialLista>> ObterListaDeServidoresAsync(string link)
        {
            var response = await _httpClient.GetAsync(link);
            var tsvContent = await response.Content.ReadAsStringAsync();
            var tsv = tsvContent.Replace("\r\n", "\t").Split('\t').Skip(3).ToList();

            var listaDeServidores = new List<AtuarialLista>();
            for (int i = 0; i < tsv.Count(); i += 3)
            {
                var atuarial = new AtuarialLista
                {
                    Nome = tsv[i],
                    Cpf = tsv[i + 1],
                    Matricula = tsv[i + 2]
                };
                listaDeServidores.Add(atuarial);
            }
            return listaDeServidores;
        }

        public Task<List<AtuarialLista>> ObterServidoresComum(List<AtuarialLista> lista1, List<AtuarialLista> lista2)
        {
            var servidoresComum = lista1.Where(a => lista2.Any(r => r.Cpf == a.Cpf && r.Matricula == a.Matricula)).ToList();
            return Task.FromResult(servidoresComum);
        }

        public Task<List<AtuarialLista>> ObterServidoresDiferentes(List<AtuarialLista> lista1, List<AtuarialLista> lista2)
        {
            var servidoresDiferentes = lista1.Where(a => !lista2.Any(r => r.Cpf == a.Cpf && r.Matricula == a.Matricula)).ToList();
            return Task.FromResult(servidoresDiferentes);
        }

    }
}
