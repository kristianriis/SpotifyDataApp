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
        return Ok(result);    
    }
    
    [HttpGet("top-artists")]
    public async Task<IActionResult> GetTopArtists([FromHeader(Name = "Authorization")] string authHeader)
    {
        if (!authHeader?.StartsWith("Bearer ") ?? true)
            return Unauthorized();

        var token = authHeader["Bearer ".Length..];
        var result = await _spotifyService.GetTopArtistsAsync(token);
        return Ok(result);
    }

    [HttpGet("top-tracks")]
    public async Task<IActionResult> GetTopTracks([FromHeader(Name = "Authorization")] string authHeader)
    {
        if (!authHeader?.StartsWith("Bearer ") ?? true)
            return Unauthorized();

        var token = authHeader["Bearer ".Length..];
        var result = await _spotifyService.GetTopTracksAsync(token);
        return Ok(result);
    }

    [HttpGet("playlists")]
    public async Task<IActionResult> GetPlaylists([FromHeader(Name = "Authorization")] string authHeader)
    {
        if (!authHeader?.StartsWith("Bearer ") ?? true)
            return Unauthorized();

        var token = authHeader["Bearer ".Length..];
        var result = await _spotifyService.GetUserPlaylistsAsync(token);
        return Ok(result);
    }

}