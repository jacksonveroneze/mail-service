using System.Net.Mime;
using System.Threading.Tasks;
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
        private readonly IEmailService _emailService;

        /// <summary>
        /// Method responsible for initialize controller.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="emailService"></param>
        public MailController(ILogger<MailController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        /// <summary>
        /// Method responsible for action: Send.
        /// </summary>
        /// <param name="mailRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<MailResponse>> Send([FromBody] MailRequest mailRequest)
        {
            MailResponse response = await _emailService.Send(mailRequest);

            _logger.LogInformation("Send mail");

            return Ok(response);
        }
    }
}
