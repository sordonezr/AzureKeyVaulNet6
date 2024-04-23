using Microsoft.AspNetCore.Mvc;

namespace AzureKeyVaultNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SecretsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{secretName}")]
        public IActionResult GetSecret(string secretName)
        {
            var secretValue = _configuration[secretName];
            if (string.IsNullOrEmpty(secretValue))
            {
                return NotFound($"Secret {secretName} not found.");
            }
            return Ok(secretValue);
        }
    }
}
