using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lemon.BackgroundTask.Quartz
{
    public static class QuartzModule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            return services;
        }
    }
}
