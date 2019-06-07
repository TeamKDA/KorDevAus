using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KorDevAus.Models.Api;

namespace KorDevAus.Services
{
    public interface IRsvpService
    {
        Task<List<Rsvp>> GetRsvpByCampaignId(string campaignId);
        Task<Rsvp> GetRsvpByEmailId(string campaignId, string emailId);
        Task<bool> Register(string campaignId, string emailId);
        Task<bool> Cancel(string campaignId, string emailId);
    }
}
