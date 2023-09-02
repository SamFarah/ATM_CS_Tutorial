using ATM.Views;
using Microsoft.Extensions.Hosting;

namespace ATM.Services;
public class RefreshMainBackraoundService : BackgroundService
{
    private readonly IMasterView _masterView;

    public RefreshMainBackraoundService(IMasterView masterView)
    {
        _masterView = masterView;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
        while (
            !stoppingToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(stoppingToken))
        {
            _masterView.DisplayDateTime();
        }
    }
}
