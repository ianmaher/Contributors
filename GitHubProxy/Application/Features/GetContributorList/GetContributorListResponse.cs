using System;
using MediatR;
using GitHubProxy.Models;

namespace GitHubProxy.Application.Features.GetContributorList
{
    public class GetContributorListResponse
    {
        public GetContributorListResponse()
        {
            Contributors = new List<Contributor>();
        }

        public IList<Contributor> Contributors { get; set; }
    }
}

