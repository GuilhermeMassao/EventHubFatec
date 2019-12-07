using EventHub.Domain.Entities;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Interfaces.Repository
{
    public interface IGoogleCalendarSocialMarketingRepository
    {
        Task<int?> CreateGoogleCalendarSocialMarketing(GoogleCalendarSocialMarketing entity);
    }
}
