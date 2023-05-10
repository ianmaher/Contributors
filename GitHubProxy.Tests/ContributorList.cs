using System.Threading;
using GitHubProxy.Application.Features.GetContributorList;
using GitHubProxy.Application.Services.Interfaces;
using GitHubProxy.Models;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace GitHubProxy.Tests;

public class ContributorsList
{

    [Test]
    public async Task ContributorList_Given_Existing_Repro_Should_Return_Ok()
    {
        GetContributorListResponse resp = new GetContributorListResponse();
        resp.Contributors.Add(new Contributor() { Name = "Author" });

        var gitHib = new Mock<IGitHubService>();
        gitHib.Setup(x => x.GetContributors("Test1", "Repo1"))
            .ReturnsAsync(resp);

        GetContributorListHandler handler = new GetContributorListHandler(gitHib.Object);
        GetContributorListQuery query = new GetContributorListQuery() { Owner = "Test1", Repo = "Repo1" };
        CancellationToken cancellationToken = new CancellationToken();

        GetContributorListResponse response = await handler.Handle(query, cancellationToken);

        Assert.That(response.Contributors.Count, Is.EqualTo(1));
    }

    [Test]
    public async Task ContributorList_Given_NonExisting_Repro_Should_Return_Null_Object()
    {
        GetContributorListResponse resp = new GetContributorListResponse();
        resp.Contributors.Add(new Contributor() { Name = "Author" });

        var gitHib = new Mock<IGitHubService>();
        gitHib.Setup(x => x.GetContributors("Test1", "Repo1"))
            .ReturnsAsync(resp);

        GetContributorListHandler handler = new GetContributorListHandler(gitHib.Object);
        GetContributorListQuery query = new GetContributorListQuery() { Owner = "Unknown", Repo = "Repo" };
        CancellationToken cancellationToken = new CancellationToken();

        GetContributorListResponse response = await handler.Handle(query, cancellationToken);

        Assert.That(response, Is.EqualTo(null));
    }
}
