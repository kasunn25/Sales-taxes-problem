using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesTax.Domain.Billing;
using SalesTax.Domain.Shopping;
using SalesTaxes.App;
using SalesTaxes.App.Interface;
using SalesTaxes.App.Models;
using SalesTaxes.Infrastrutucture.Interfaces;
using SalesTaxes.Infrastrutucture.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace SalesTaxes
{
    public class Program
    {
        static void Main(string[] args)
        {
            // TEMPoRARY SOLUTION
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("App/Data/input.json", optional: false);

            IConfiguration config = builder.Build();

            var inputProducts = new List<JsonProduct>();
            config.Bind("input_3", inputProducts);
            // TEMPoRARY SOLUTION

            var host = CreateHostBuilder(args).Build();

            var store = host.Services.GetService<ISalesTaxesStore>();
            if (store != null)
            {
                store.GetSalesOrder(inputProducts);
                store.CheckOut();
                Console.ReadLine();
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration((context, builder) =>
                    {
                        builder.SetBasePath(Directory.GetCurrentDirectory());
                    })
                    .ConfigureServices((context, services) =>
                    {
                        services.AddSingleton<ISalesTaxesStore, SalesTaxesStore>();
                        services.AddSingleton<IShoppingCart, ShoppingCart>();
                        services.AddSingleton<IPaymentCounter, PaymentCounter>();
                        services.AddSingleton<IStoreShelf, StoreShelf>();
                        services.AddSingleton<ITaxRepository, TaxRepository>();
                    });

            return hostBuilder;
        }
    }
}
