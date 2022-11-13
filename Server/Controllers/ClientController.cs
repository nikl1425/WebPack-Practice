using System;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{

    [ApiController]
    [Route("/s")]
    public class ClientController : ControllerBase
	{
		public ClientController()
		{
			
		}

        [HttpGet]
        public IActionResult HomePage()
        {

            
            return PhysicalFile("index.html", "text/html");

        }
    }
}

