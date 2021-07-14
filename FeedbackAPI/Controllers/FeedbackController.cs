using FeedbackAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackAPI.Controllers
{
    [Route("api/school")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly ISubmitFeedback _submitFeedback;

        public FeedbackController(ISubmitFeedback submitFeedback)
        {
            _submitFeedback = submitFeedback;
        }

        [HttpPost]
        public ActionResult AddFeedback()
        {
            var feedback = "Happy";
            _submitFeedback.PostFeedback("Faraz", feedback);
            return Ok();
        }
    }
}
