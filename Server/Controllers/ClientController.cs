using System;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{

    [ApiController]
    [Route("/")]
    public class ClientController : Controller
	{
        IWebHostEnvironment _webHostEnvironment;
		public ClientController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult GetSpa()
        {
            string contentRootPath = _webHostEnvironment.ContentRootPath;

            string spaIndex = Path.Combine(contentRootPath, "Client", "dist", "index.html");

            return PhysicalFile(spaIndex, "text/html");
        }

    }
}

