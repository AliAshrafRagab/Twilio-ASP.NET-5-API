using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Twilio.Application.DTOs.Identity;
using Twilio.Application.Interfaces;
using Twilio.Application.Interfaces.Shared;
using Twilio.Infrastructure.Identity.Models;
using Twilio.Rest.Verify.V2.Service;
using static Twilio.Api.Startup;

namespace Twilio.Api.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IAuthenticatedUserService _AuthenticatedUserService;
        private readonly TwilioVerifySettings _settings;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityController(IOptions<TwilioVerifySettings> settings,
            UserManager<ApplicationUser> userManager,
            IIdentityService identityService,
            IAuthenticatedUserService iAuthenticatedUserService
            )
        {
            this._identityService = identityService;
            _settings = settings.Value; 
            _userManager = userManager;
            _AuthenticatedUserService=iAuthenticatedUserService;
        }





        public async Task<bool> CodeVerification(string Code)
        {
            try
            {
                ApplicationUser user =await _userManager.FindByIdAsync(_AuthenticatedUserService.UserId);
                string PhoneNumber = user?.PhoneNumber;
                if (user != null && PhoneNumber != "" && user.PhoneNumberConfirmed == false)
                {
                    var verification = await VerificationCheckResource.CreateAsync(
                        to: PhoneNumber,
                        code: Code,
                        pathServiceSid: _settings.VerificationServiceSID
                    );
                    if (verification.Status == "approved")
                    {
                        user.PhoneNumberConfirmed = true;
                        var updateResult = await _userManager.UpdateAsync(user);

                        if (updateResult.Succeeded)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }


        public async Task<bool> SendCode()
        {
            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(_AuthenticatedUserService.UserId);
                string Phonenumber = user?.PhoneNumber;

                Console.WriteLine(Phonenumber);
                var verification = await VerificationResource.CreateAsync(
                    to: Phonenumber,
                    channel: "sms",
                   pathServiceSid: _settings.VerificationServiceSID
                );

                if (verification.Status == "pending")
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }









        /// <summary>
        /// Generates a JSON Web Token for a valid combination of emailId and password.
        /// </summary>
        /// <param name="tokenRequest"></param>
        /// <returns></returns>
        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTokenAsync(TokenRequest tokenRequest)
        {
            var ipAddress = GenerateIPAddress();
            var token = await _identityService.GetTokenAsync(tokenRequest, ipAddress);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _identityService.RegisterAsync(request, origin));
        }

        [HttpGet("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string userId, [FromQuery] string code)
        {
            return Ok(await _identityService.ConfirmEmailAsync(userId, code));
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {
            await _identityService.ForgotPassword(model, Request.Headers["origin"]);
            return Ok();
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {
            return Ok(await _identityService.ResetPassword(model));
        }

        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}