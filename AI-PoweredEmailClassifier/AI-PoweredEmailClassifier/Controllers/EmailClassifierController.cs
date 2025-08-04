using Microsoft.AspNetCore.Mvc;
using AI_PoweredEmailClassifier.Models;
using AI_PoweredEmailClassifier.Services;

namespace AI_PoweredEmailClassifier.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailClassifierController : ControllerBase
    {
        private readonly GeminiEmailClassifier _classifier;

        public EmailClassifierController(GeminiEmailClassifier classifier)
        {
            _classifier = classifier;
        }

        [HttpPost]
        public async Task<IActionResult> ClassifyEmail([FromBody] EmailRequest email)
        {
            var category = await _classifier.ClassifyEmailAsync(email);

            var result = new EmailClassificationResult
            {
                Category = category,
                Reasoning = $"The Gemini model classified this email based on subject and body context."
            };

            return Ok(result);
        }
    }
}
