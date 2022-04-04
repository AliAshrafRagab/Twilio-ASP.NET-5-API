using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio.Application.DTOs;
using Twilio.Application.Features.ActivityLog.Queries.GetUserLogs;
using Twilio.Application.Interfaces.Shared;
using Twilio.Web.Abstractions;

namespace Twilio.Web.Areas.Identity.Pages.Account
{
    public class AuditLogModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IAuthenticatedUserService _userService;
        public List<AuditLogResponse> AuditLogResponses;
        private IViewRenderService _viewRenderer;

        public AuditLogModel(IMediator mediator, IAuthenticatedUserService userService, IViewRenderService viewRenderer)
        {
            _mediator = mediator;
            _userService = userService;
            _viewRenderer = viewRenderer;
        }

        public async Task OnGet()
        {
            var response = await _mediator.Send(new GetAuditLogsQuery() { userId = _userService.UserId });
            AuditLogResponses = response.Data;
        }
    }
}