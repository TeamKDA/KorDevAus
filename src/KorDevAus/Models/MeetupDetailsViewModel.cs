using System;
using Microsoft.AspNetCore.Mvc;

namespace KorDevAus.Models
{
    public class MeetupDetailsViewModel
    {
        public int CountRegisteredAttendees { get; set; }
        public bool RsvpRegistered { get; set; }

        [HiddenInput]
        public string CampaignId { get; set; }

        [HiddenInput]
        public string EmailId { get; set; }
        
    }
}