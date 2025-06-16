using ConsumeWebAPI.Models;
using System.Net.Http.Json;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<User>>("https://localhost:44391/api/users");
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<User>($"https://localhost:44391/api/users/{id}");
    }

    public async Task<bool> CreateUserAsync(User user)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:44391/api/users", user);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
        var response = await _httpClient.PutAsJsonAsync($"https://localhost:44391/api/users/{user.Id}", user);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"https://localhost:44391/api/users/{id}");
        return response.IsSuccessStatusCode;
    }
}
