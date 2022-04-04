using System;
using Twilio.Application.Interfaces.Shared;

namespace Twilio.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}