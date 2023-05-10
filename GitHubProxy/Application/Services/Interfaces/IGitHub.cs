using GitHubProxy.Models;

namespace GitHubProxy.Application.Services.Interfaces;

public interface IGitHubService
{
    public Task<IList<GitHubContributor>> GetContributors(string owner, string repo);
}


