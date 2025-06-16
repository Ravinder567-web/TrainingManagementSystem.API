using ConsumeWebAPI.Models;
using System.Net.Http.Json;

public class EnrolmentService
{
    private readonly HttpClient _httpClient;

    public EnrolmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Enrolment>> GetEnrolmentsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Enrolment>>("https://localhost:44391/api/enrolments");
    }

    public async Task<Enrolment> GetEnrolmentByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Enrolment>($"https://localhost:44391/api/enrolments/{id}");
    }

    public async Task<bool> CreateEnrolmentAsync(Enrolment enrolment)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:44391/api/enrolments", enrolment);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateEnrolmentAsync(Enrolment enrolment)
    {
        var response = await _httpClient.PutAsJsonAsync($"https://localhost:44391/api/enrolments/{enrolment.Id}", enrolment);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteEnrolmentAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"https://localhost:44391/api/enrolments/{id}");
        return response.IsSuccessStatusCode;
    }

    internal async Task<string?> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    internal async Task UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}
