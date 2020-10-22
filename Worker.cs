using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace FileManager
{
    public class Worker : BackgroundService
    {
        private readonly string[] softDirectories;
        private readonly string[] hardDirectories;
        private readonly FileCleanUpService cleanUpService;
        public Worker(HostBuilderContext targetPath)
        {
            softDirectories = targetPath.Configuration.GetSection("Application:SoftDirs").Get<string[]>();
            hardDirectories = targetPath.Configuration.GetSection("Application:HardDirs").Get<string[]>();
            cleanUpService = new FileCleanUpService(
            new ISoftRule[]
            {
                new DocumentRule(targetPath.Configuration.GetSection("Application:DocumentsDir").Value),
                new ImageRule(targetPath.Configuration.GetSection("Application:ImagesDir").Value),
                new LinkRule(),
            },
            new IHardRule[]
            {
                new DeleteUntouchedFilesFromDownloadFolderRule()
            }
            );
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                cleanUpService.SoftCleanUp(softDirectories);
                cleanUpService.HardCleanUp(hardDirectories);
                await Task.Delay(3600, stoppingToken);
            }
        }
    }
}