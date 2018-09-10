using System.Web.Mvc;

namespace Wave28Application.Controllers
{
    public class LayoutController : Controller
    {
        //[Authorize(Roles = "BusinessAdmin")]
        public ActionResult _BusinessAdminLayout()
        {
            return View();
        }
       // [Authorize(Roles = "Customer")]
        public ActionResult _CustomerLayout()
        {
            return View();
        }
    }
}