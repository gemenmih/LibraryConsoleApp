




using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.user.json", false)
                    .Build();

string connectionString = config.GetSection("ConnectionString").Value;
/* Call SqlServerClient and create an instance and implement 
its CRUD operation with a Dummy Table e.g User(FirstName, LastName) */