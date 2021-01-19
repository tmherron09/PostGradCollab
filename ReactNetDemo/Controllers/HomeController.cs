using Microsoft.AspNetCore.Mvc;
using ReactNetDemo.Models;
using System.Collections.Generic;

namespace ReactNetDemo.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }


}
