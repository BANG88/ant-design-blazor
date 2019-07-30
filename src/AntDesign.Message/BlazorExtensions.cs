using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Ant Message Service
    /// </summary>
    public static class BlazorExtensions
    {
        public static IServiceCollection AddAntMessage(this IServiceCollection services)
        {
            services.TryAddScoped<AntDesign.AntMessageService>();
            return services;
        }
    }
}
