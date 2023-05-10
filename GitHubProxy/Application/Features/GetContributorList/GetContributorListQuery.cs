using System;
using MediatR;

namespace GitHubProxy.Application.Features.GetContributorList
{
    public class GetContributorListQuery : IRequest<GetContributorListResponse>
    {

        public string Owner { get; set; } = string.Empty;
        public string Repo { get; set; } = string.Empty;
    }
}

