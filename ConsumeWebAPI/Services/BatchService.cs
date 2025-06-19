using ConsumeWebAPI.Models;
using System.Net.Http.Json;

public class BatchService
{
    private readonly HttpClient _httpClient;

    public BatchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Batch>> GetBatchesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Batch>>("https://localhost:44391/api/batches");
    }

    public async Task<Batch> GetBatchByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"https://localhost:44391/api/batches/{id}");
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<Batch>();
        return null;
    }

    public async Task<bool> AddBatchAsync(Batch batch)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:44391/api/batches", batch);
        return response.IsSuccessStatusCode;
    }
    public async Task<bool> CreateBatchAsync(Batch batch)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:44391/api/batches", batch);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateBatchAsync(Batch batch)
    {
        var response = await _httpClient.PutAsJsonAsync($"https://localhost:44391/api/batches/{batch.Id}", batch);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteBatchAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"https://localhost:44391/api/batches/{id}");
        return response.IsSuccessStatusCode;
    }

    
}
