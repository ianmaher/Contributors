using System;
using MediatR;
using GitHubProxy.Application.Services.Interfaces;
namespace GitHubProxy.Application.Features.GetContributorList
{
    public class GetContributorListHandler : IRequestHandler<GetContributorListQuery, GetContributorListResponse>
    {
        private readonly IGitHubService _gitHub;
        public GetContributorListHandler(IGitHubService gitHub )
        {
            _gitHub = gitHub;
        }

        public async Task<GetContributorListResponse> Handle(GetContributorListQuery query, CancellationToken cancellationToken)
        {
            var contributorList = await _gitHub.GetContributors(query.Owner, query.Repo);
            return contributorList.Map();
        }
    }
}

