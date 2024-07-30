using ScreenSound.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services;

public class AuthAPI(IHttpClientFactory factory)
{
    private readonly HttpClient _httpClient = factory.CreateClient("API");

    public async Task<AuthResponse> LoginAsync(string email, string senha)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/login?useCookies=true", new
        {
            email,
            password = senha
        });

        if (response.IsSuccessStatusCode)
            return new AuthResponse { Success = true };
        else
            return new AuthResponse { Success = false, Errors = ["Login ou senha inválidos."] };
    }
}
