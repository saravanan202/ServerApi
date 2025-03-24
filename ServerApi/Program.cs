using Microsoft.AspNetCore;
using ServerApi;
 WebHost.CreateDefaultBuilder(args)
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseIISIntegration()
        .UseStartup<Startup>()
        .UseUrls("https://localhost:44377/").Build().Run();
