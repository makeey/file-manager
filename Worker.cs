using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace FileManager
{
    public class Worker : BackgroundService
    {
        private readonly string[] targetDirectories;
        private readonly FileCleanUpService cleanUpService;
        public Worker(HostBuilderContext targetPath)
        {
            targetDirectories = targetPath.Configuration.GetSection("Application:TargetDir").Get<string[]>();
            cleanUpService = new FileCleanUpService(
            new IRule[]
            {
                new DocumentRule(targetPath.Configuration.GetSection("Application:DocumentsDir").Value),
                new ImageRule(targetPath.Configuration.GetSection("Application:ImagesDir").Value),
                new LinkRule(),
            });
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                cleanUpService.CleanUp(targetDirectories);
                await Task.Delay(3600, stoppingToken);
            }
        }
    }
}