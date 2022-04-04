using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Application.DTOs;

namespace Twilio.Application.Interfaces.Repositories
{
    public interface ILogRepository
    {
        Task<List<AuditLogResponse>> GetAuditLogsAsync(string userId);

        Task AddLogAsync(string action, string userId);
    }
}