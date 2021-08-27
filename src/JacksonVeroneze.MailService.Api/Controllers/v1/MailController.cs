using System.Net.Mime;
using Hangfire;
using JacksonVeroneze.MailService.Api.Models;
using JacksonVeroneze.MailService.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JacksonVeroneze.MailService.Api.Controllers.v1
{
    /// <summary>
    /// Class responsible for controller
    /// </summary>
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MailController : ControllerBase
    {
        private readonly ILogger<MailController> _logger;

        /// <summary>
        /// Method responsible for initialize controller.
        /// </summary>
        /// <param name="logger"></param>
        public MailController(ILogger<MailController> logger)
            => _logger = logger;

        /// <summary>
        /// Method responsible for action: Send.
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<MailResponse> Send([FromBody] MailRequest mailRequest)
        {
            BackgroundJob.Enqueue<IEmailService>(x => x.SendAsync(mailRequest));

            _logger.LogInformation("Send mail");

            return Ok(new MailResponse());
        }
    }
}
