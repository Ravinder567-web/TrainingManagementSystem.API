using ConsumeWebAPI.Models;
using System.Net.Http.Json;

public class CourseService
{
    private readonly HttpClient _httpClient;

    public CourseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Course>>("https://localhost:44391/api/courses");
    }

    public async Task<Course> GetCourseByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Course>($"https://localhost:44391/api/courses/{id}");
    }

    public async Task<bool> CreateCourseAsync(Course course)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:44391/api/courses", course);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateCourseAsync(Course course)
    {
        var response = await _httpClient.PutAsJsonAsync($"https://localhost:44391/api/courses/{course.Id}", course);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCourseAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"https://localhost:44391/api/courses/{id}");
        return response.IsSuccessStatusCode;
    }
}
