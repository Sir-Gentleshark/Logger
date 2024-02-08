using Logger.Consumer;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("Appsettings.json", optional: false).Build();

Consumer.Init(config);