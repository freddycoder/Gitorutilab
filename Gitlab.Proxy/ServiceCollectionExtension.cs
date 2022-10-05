using GitLabApiClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Gitlab.Proxy;
public static class ServiceCollectionExtension
{
    public static IServiceCollection AddGitlabClient(this IServiceCollection services)
    {
        return services.AddScoped<IGitLabClient>(sp =>
        {
            var option = sp.GetRequiredService<IOptions<GitlabClientOptions>>().Value;

            return new GitLabClient(option.HostUrl, option.AuthenticationToken);
        });
    }
}
