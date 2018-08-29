using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KorDevAus.Models;

namespace KorDevAus.Controllers
{
    public class MeetupsController : Controller
    {
        [Route("meetups")]
        public IActionResult List()
        {
            return View();
        }
    }
}
