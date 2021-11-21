using lab7.Services;
using lab7.Services.Emp;
using lab7.Services.Int;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab7
{
    public static class Di
    {
        public static void IoC(this IServiceCollection services)
        {
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<IClientService, ClientService>();
        }
    }
}