using System;
using GitHubProxy.Application.Features.GetContributorList;

namespace GitHubProxy.Application.Services.Interfaces;

public interface IGitHubService
{
    public Task<GetContributorListResponse> GetContributors(string owner, string repo);
}


