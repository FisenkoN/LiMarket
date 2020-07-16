using LiMarket_V1._0._0.Models.Repository;
using System.Web.Mvc;

namespace LiMarket_V1._0._0.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult List()
        {
            ViewBag.Message = "List";

            return View();
        }
    }
}