using Microsoft.Extensions.DependencyInjection;
using TwitterPublicStream.Repositories;
using TwitterPublicStream.Services;

namespace TwitterPublicStream
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<ConsoleApplication>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IUrlsRepository, UrlsRepository>();
            services.AddSingleton<IHashTagRepository, HashTagRepository>();
            services.AddSingleton<IEmojiRepository, EmojiRepository>();
            services.AddSingleton<ITweetRepository, TweetRepository>();
            services.AddSingleton<IMediaService, MediaService>();
            services.AddSingleton<IUrlsService, UrlsService>();
            services.AddSingleton<IHashTagService, HashTagService>();
            services.AddSingleton<IEmojiService, EmojiService>();
            services.AddSingleton<ITweetService, TweetService>();
            services.AddSingleton<ITwitterStreamService, TwitterStreamService>();
            services.AddSingleton<ConsoleApplication>();
            return services;
        }

    }
}
