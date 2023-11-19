using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LeonardoPrac.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MplusController : ControllerBase
    {

        private readonly ILogger<MplusController> _logger;
        private readonly HttpClient _httpClient;

        public MplusController(ILogger<MplusController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        [HttpGet("{mplusRequested}")]
        public async Task<IActionResult> Get(string mplusRequested)
        {
            try
            {
                var uriGet = $"https://raider.io/api/v1/characters/profile?region=us&realm=illidan&name={mplusRequested}&fields=mythic_plus_scores_by_season%3Acurrent";
                var httpResponse = await _httpClient.GetAsync(uriGet);


                if (httpResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    _logger.LogError($"API failed with status code: {httpResponse.StatusCode}");
                    return StatusCode(404, "Unable to find Character!");
                }

                var responseJson = await httpResponse.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<dynamic>(responseJson);

                if (obj == null)
                {
                    _logger.LogError($"API failed with status code: {httpResponse.StatusCode}");
                    return StatusCode(404, "Unable to find Character");
                }

                var mplusInfo = new Mplus
                {
                    Name = obj.name,
                    Spec = obj.active_spec_name,
                    MplusRating = obj.mythic_plus_scores_by_season[0].scores.all,
                    Photo = obj.thumbnail_url,
                };

                return Ok(mplusInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured: {ex.Message}");
                return StatusCode(500, "Server Error");
            }
        }
    }
}