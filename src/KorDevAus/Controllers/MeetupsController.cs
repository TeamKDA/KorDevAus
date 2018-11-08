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

        [Route("meetups/2018-10-15")]
        public IActionResult Details20181015()
        {
            return View();
        }

        [Route("meetups/2018-11-19")]
        public IActionResult Details20181119()
        {
            return View();
        }
    }
}
