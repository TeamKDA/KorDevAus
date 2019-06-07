using System;
using Microsoft.AspNetCore.Mvc;

namespace KorDevAus.Models.Api
{
    public class Rsvp
    {
        public int Id { get; set; }
        public string CampaignUid { get; set; }
        public string EmailUid { get; set; }
        public DateTime Updated { get; set; }
        public bool RsvpYn { get; set; }
    }
}