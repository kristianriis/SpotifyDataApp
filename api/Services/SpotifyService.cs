using System.Net.Http.Headers;
namespace api.Services;

public class SpotifyService(HttpClient httpClient)
{
    public async Task<string> GetUserProfileAsync(string accessToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.spotify.com/v1/me");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        
        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
    
    public async Task<string> GetTopArtistsAsync(string accessToken, string timeRange = "medium_term", int limit = 10)
    {
        var url = $"https://api.spotify.com/v1/me/top/artists?time_range={timeRange}&limit={limit}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetTopTracksAsync(string accessToken, string timeRange = "medium_term", int limit = 10)
    {
        var url = $"https://api.spotify.com/v1/me/top/tracks?time_range={timeRange}&limit={limit}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetUserPlaylistsAsync(string accessToken, int limit = 10)
    {
        var url = $"https://api.spotify.com/v1/me/playlists?limit={limit}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}