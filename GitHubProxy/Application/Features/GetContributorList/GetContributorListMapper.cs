using System;
using GitHubProxy.Models;

namespace GitHubProxy.Application.Features.GetContributorList;
public  static class GetContributorListMapper
{
    public static GetContributorListResponse Map(this IList<GitHubContributor> gh)
    {
        var contributorListResponse = new GetContributorListResponse();
        if ( gh != null )
        {
            foreach(GitHubContributor c in gh)
            {
                var contributor = c.Map();
                contributorListResponse.Contributors.Add(contributor);
            }
        }
        return contributorListResponse;
    }

    private static Contributor Map(this GitHubContributor gh)
    {
        var contributor = new Contributor
        {
            Name = gh.login
        };
        return contributor;
    }
        
}


