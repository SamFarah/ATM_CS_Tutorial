using ATM.Controllers;
using ATM.Library.DataAccess;
using ATM.Library.Services;
using ATM.Services;
using ATM.Views;
using ATM.Views.Guest;
using ATM.Views.Member;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ATM;

public class Program
{

    public static void Main(string[] args)
    {

        var configurations = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();


        var hostBuilder = Host.CreateDefaultBuilder(args).ConfigureServices(services =>
        {
            var connectionString = configurations.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Could not load connection string");

            services.AddDbContext<Data.IAtmDbContext, Data.AtmDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddSingleton(
                 new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Data.Models.CardHolder, Library.Models.CardHolder>();
                        cfg.CreateMap<Data.Models.Transaction, Library.Models.Transaction>();
                    }).CreateMapper());

            services
                .AddTransient<IGuestController, GuestController>()
                .AddTransient<IMemberController, MemberController>()
                .AddTransient<IMasterView, MasterView>()
                .AddTransient<IGuestView, GuestView>()
                .AddTransient<IInvalidLoginView, InvalidLoginView>()
                .AddSingleton<IOperationSuccessfullView, OperationSuccessfullView>()
                .AddSingleton<IMemberView, MemberView>()
                .AddSingleton<IAmountView, AmountView>()
                .AddSingleton<IOperationFailedView, OperationFailedView>()
                .AddSingleton<ITransactionsView, TransactionsView>()
                .AddTransient<ICardHolderData, CardHolderData>()
                .AddTransient<ITransactionData, TransactionData>()
                .AddTransient<IAtmService, AtmService>()
                .AddHostedService<RefreshMainBackraoundService>();
        });
        var host = hostBuilder.Build();

        using (var scope = host.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<Data.IAtmDbContext>();
            dbContext.Database.Migrate();
        }
        host.Start();


        var guestController = host.Services.GetRequiredService<IGuestController>();
        while (true) guestController.GuestMenu();
    }


}