using PlatformService.Dtos;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataServices.Http;

public class HttpCommandDataClient(HttpClient _httpClient
    ,IConfiguration _configuration) : ICommandDataClient
{

    public async Task SendPlatformToCommand(PlatformReadDto platform)
    {
        var response = await _httpClient
            .PostAsJsonAsync($"{_configuration["CommandService"]}", platform);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("--> Sync POST to CommandService was OK!");
        }
        else
        {
            Console.WriteLine("--> Sync POST to CommandService was NOT OK!");
        }
    }
}