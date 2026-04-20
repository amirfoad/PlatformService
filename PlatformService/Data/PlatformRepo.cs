using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo(AppDbContext context) : IPlatformRepo
{

    public void CreatePlatform(Platform platform)
    {
        ArgumentNullException.ThrowIfNull(platform, nameof(platform));

        context.Platforms.Add(platform);
    }
    public IEnumerable<Platform> GetAllPlatforms()=>
         context.Platforms.ToList();
    
    public Platform GetPlatformById(int id)=>
        context.Platforms.FirstOrDefault(p => p.Id == id);
    
    public bool SaveChanges()=>
        (context.SaveChanges() >= 0);
    
}
