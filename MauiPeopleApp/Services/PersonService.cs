using System.Net.Http.Json;
using System.Text.Json.Serialization;
using MauiPeopleApp.Models;

namespace MauiPeopleApp.Services;

public class PersonService
{
    private readonly HttpClient _httpClient;

    public PersonService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        var page1 = await _httpClient.GetFromJsonAsync<ApiResponse>("https://reqres.in/api/users?page=1&api_key=reqres-free-v1");
        var page2 = await _httpClient.GetFromJsonAsync<ApiResponse>("https://reqres.in/api/users?page=2&api_key=reqres-free-v1");

        var list = new List<Person>();
        if (page1?.Data != null) list.AddRange(page1.Data);
        if (page2?.Data != null) list.AddRange(page2.Data);
        return list;
    }

    private class ApiResponse
    {
        [JsonPropertyName("data")]
        public List<Person>? Data { get; set; }
    }
}
