using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using BingoDefinitivo.Models;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using BingoDefinitivo.Data;
using Humanizer;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
namespace BingoDefinitivo.Controllers
{
    public class BingoController : Controller
    {
        //DB CONTEXT PARA COMUNICACION CON BASE DE DATOS
        private readonly ApplicationDbContext _dbContext;
        public BingoController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
     
        MFBingo Bingo = new MFBingo();
        MFBolillero Bolillero = new MFBolillero();
        List<int> NumerosDados = new();
        public IActionResult Index()
        {
    
            if (ExtensionDeSesion.Get<BingoComprimed>(HttpContext.Session, "BINGODATA") == null)
            {
             
                ExtensionDeSesion.Set(HttpContext.Session, "BINGODATA", Bingo.COMPRIMIR());
            }
            else
            {
                var bingoprueba = ExtensionDeSesion.Get<BingoComprimed>(HttpContext.Session, "BINGODATA");
                Bingo = new(bingoprueba);
            }
            if (ExtensionDeSesion.Get<List<int>>(HttpContext.Session, "BOLERODATA") == null)
            {

                ExtensionDeSesion.Set(HttpContext.Session, "BOLERODATA", NumerosDados);
            }
            else
            {
                var Bolero = ExtensionDeSesion.Get<List<int>>(HttpContext.Session, "BOLERODATA");
                NumerosDados = Bolero;
            }
            if (Bingo.HayGanador())
            {
                _dbContext.Add(Bingo.BingoDatos);
                _dbContext.SaveChanges();
                NumerosDados.Clear();
                ExtensionDeSesion.Set(HttpContext.Session, "BOLERODATA", NumerosDados);
                ViewData["Winner"] = $"Cartón {Bingo.BingoDatos.Carton1}";
                if (Bingo.BingoDatos.Carton2 != null)
                {
                    ViewData["Winner2"] = $",cartón {Bingo.BingoDatos.Carton2}";
                }
                if (Bingo.BingoDatos.Carton3 != null)
                {
                    ViewData["Winner3"] = $"Cartón {Bingo.BingoDatos.Carton3}";
                }
                if (Bingo.BingoDatos.Carton4 != null)
                {
                    ViewData["Winner4"] = $"Cartón  {Bingo.BingoDatos.Carton4}";
                }

            }
            else { ViewData["Winner"] = null; }
            return View(Bingo);
        }
        
        public IActionResult Roll()
        {
            if (ExtensionDeSesion.Get<List<int>>(HttpContext.Session, "BOLERODATA") == null)
            {

                ExtensionDeSesion.Set(HttpContext.Session, "BOLERODATA", NumerosDados);
            }
            else
            {
                var Bolero = ExtensionDeSesion.Get<List<int>>(HttpContext.Session, "BOLERODATA");
                NumerosDados = Bolero;
            }
            var bingoprueba = ExtensionDeSesion.Get<BingoComprimed>(HttpContext.Session, "BINGODATA");
            Bingo = new(bingoprueba);
            int Numero= Bolillero.Dar(NumerosDados);
            Bingo.Jugar(Numero);
            NumerosDados.Add(Numero);
            ExtensionDeSesion.Set(HttpContext.Session, "BOLERODATA", NumerosDados);
            Upload(Numero);
            ExtensionDeSesion.Set(HttpContext.Session, "BINGODATA", Bingo.COMPRIMIR());
            ViewData["Number"]=Numero;
            if (Bingo.HayGanador())
            {
                NumerosDados.Clear();
                ExtensionDeSesion.Set(HttpContext.Session, "BOLERODATA", NumerosDados);
                _dbContext.Add(Bingo.BingoDatos);
                _dbContext.SaveChanges();
                ViewData["Winner"] = $"Cartón {Bingo.BingoDatos.Carton1}";
                if (Bingo.BingoDatos.Carton2 != null)
                {
                    ViewData["Winner2"] = $",cartón {Bingo.BingoDatos.Carton2}";
                }
                if (Bingo.BingoDatos.Carton3 != null)
                {
                    ViewData["Winner3"] = $"Cartón {Bingo.BingoDatos.Carton3}";
                }
                if (Bingo.BingoDatos.Carton4 != null)
                {
                    ViewData["Winner4"] = $"Cartón  {Bingo.BingoDatos.Carton4}";
                }
                Bingo = new();
                ExtensionDeSesion.Set(HttpContext.Session, "BINGODATA", Bingo.COMPRIMIR());
            }
            else { ViewData["Winner"] = null; }
            return View("Index",Bingo);

        }
        private void Upload(int NumeroDado)
        {
            Bolillero.BolillaDatos = new()
            {
                NumeroDeBolilla = NumeroDado,
                fecha = DateTime.Now
            };
            _dbContext.Add(Bolillero.BolillaDatos);
            _dbContext.SaveChanges();
        }
    }
}
