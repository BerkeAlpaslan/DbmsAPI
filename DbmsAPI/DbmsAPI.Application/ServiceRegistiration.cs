using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbmsAPI.Application
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
        }
    }
}
