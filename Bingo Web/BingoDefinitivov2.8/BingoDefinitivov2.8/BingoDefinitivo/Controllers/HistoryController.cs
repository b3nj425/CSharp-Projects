using Microsoft.AspNetCore.Mvc;
using BingoDefinitivo.Data;
using BingoDefinitivo.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BingoDefinitivo.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        
        public HistoryController(ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public IActionResult Index()
        {

            var Bolillas = _dbContext.Bolilla.ToList();
            var model = new List<BolilleroViewModel>();
           
                foreach (var Bolilla in Bolillas)
                {
                    var B = new BolilleroViewModel()
                    {
                        Id = Bolilla.Id,
                        fecha = Bolilla.fecha,
                        NumeroDeBolilla = Bolilla.NumeroDeBolilla

                    };
                    model.Add(B);
                }
            
            return View(model);
        }
         public IActionResult Historial2()
         {
            var Cartones = _dbContext.BingoTable.ToList();
            var model = new List<BingoCViewModel>();
            foreach (var carton in Cartones)
            {
                var c = new BingoCViewModel()
                {
                    Id = carton.Id,
                    fecha = carton.fecha,
                    Carton1 = carton.Carton1,
                    Carton2 = carton.Carton2,
                    Carton3 = carton.Carton3,
                    Carton4 = carton.Carton4

                };
                model.Add(c);
            }
            return View(model);
        }  
            
        
    }
}
