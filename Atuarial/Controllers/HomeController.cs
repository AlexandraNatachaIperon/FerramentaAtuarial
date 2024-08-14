using Atuarial.Interface;
using Atuarial.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Atuarial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAtuarialService _atuarialService;

        public HomeController(ILogger<HomeController> logger, IAtuarialService atuarialService)
        {
            _logger = logger;
            _atuarialService = atuarialService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CompararListas(string linkAtuarial, string linkReferencia)
        {
            var listaDeServidoresAtuarial = await _atuarialService.ObterListaDeServidoresAsync(linkAtuarial);
            var listaDeServidoresReferencia = await _atuarialService.ObterListaDeServidoresAsync(linkReferencia);

            var ServidoresComum = await _atuarialService.ObterServidoresComum(listaDeServidoresAtuarial, listaDeServidoresReferencia);
            var ServidoresAtuarial = await _atuarialService.ObterServidoresDiferentes(listaDeServidoresAtuarial, listaDeServidoresReferencia);
            var ServidoresReferencia = await _atuarialService.ObterServidoresDiferentes(listaDeServidoresReferencia, listaDeServidoresAtuarial);

            ViewBag.ServidoresComum = ServidoresComum;
            ViewBag.ServidoresAtuarial = ServidoresAtuarial;
            ViewBag.ServidoresReferencia = ServidoresReferencia;

            return View();
        }

        public IActionResult PassoAPasso()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
