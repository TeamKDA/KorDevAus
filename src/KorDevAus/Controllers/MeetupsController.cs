using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KorDevAus.Models;
using KorDevAus.Services;

namespace KorDevAus.Controllers
{
    public class MeetupsController : Controller
    {
        private readonly IRsvpService _rsvpService;

        public MeetupsController(IRsvpService rsvpService)
        {
            _rsvpService = rsvpService;
        }

        [Route("meetups")]
        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]string campaignId, [FromForm]string emailId)
        {
            var success = await _rsvpService.Register(campaignId, emailId);
            if (success)
            {
                return RedirectToAction("RegisterSuccess");
            }
            return View("RegisterFail");
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cancel([FromForm]string campaignId, [FromForm]string emailId)
        {
            var success = await _rsvpService.Cancel(campaignId, emailId);
            if (success)
            {
                return RedirectToAction("CancelSuccess");
            }
            return View("RegisterFail");
        }

        public IActionResult CancelSuccess()
        {
            return View();
        }

        private async Task<MeetupDetailsViewModel> GetMeetupDetailsViewModel(string cid, string eid) 
        {
            var rsvps = await _rsvpService.GetRsvpByCampaignId(cid);
            var rsvp = rsvps.Find((r) => r.EmailUid == eid);

            return new MeetupDetailsViewModel() 
            {
                CountRegisteredAttendees = rsvps.Count(r => r.RsvpYn == true),
                RsvpRegistered = rsvp?.RsvpYn ?? false,
                CampaignId = cid,
                EmailId = eid
            };
        }

        [Route("meetups/2019-07-15")]
        public async Task<IActionResult> Details20190715([FromQuery]string cid, [FromQuery]string eid) 
        {
            MeetupDetailsViewModel viewModel = await GetMeetupDetailsViewModel(cid, eid);
            return View(viewModel);
        }

        [Route("meetups/2019-06-17")]
        public async Task<IActionResult> Details20190617([FromQuery]string cid, [FromQuery]string eid) 
        {
            MeetupDetailsViewModel viewModel = await GetMeetupDetailsViewModel(cid, eid);
            return View(viewModel);
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

        [Route("meetups/2019-02-18")]
        public IActionResult Details20190218()
        {
            return View();
        }

        [Route("meetups/2019-03-18")]
        public IActionResult Details20190318()
        {
            return View();
        }

        [Route("meetups/2019-04-15")]
        public IActionResult Details20190415()
        {
            return View();
        }
    }
}
