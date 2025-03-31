using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;


[ApiController]
[Route("[controller]")]
public class SpotifyController : ControllerBase
{
    private readonly SpotifyService _spotifyService;

    public SpotifyController(SpotifyService spotifyService)
    {
        _spotifyService = spotifyService;
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetUserProfileAsync([FromHeader(Name = "Authorization")] string authHeader)
    {
        if (string.IsNullOrWhiteSpace(authHeader) || !authHeader.StartsWith("Bearer "))
            return Unauthorized("Missing or invalid Authorization header");

        var token = authHeader["Bearer ".Length..]; // Slice off 'Bearer '

        var result = await _spotifyService.GetUserProfileAsync(token);
        return Ok(result);    }

}