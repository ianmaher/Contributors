using System;
using System.Text.Json;
using GitHubProxy.Application.Services.Interfaces;
using GitHubProxy.Application.Constants;
using GitHubProxy.Models;

namespace GitHubProxy.Application.Services;

public class GitHubService : IGitHubService
{
    private readonly HttpClient _httpClient;
    public GitHubService(HttpClient httpClient)
    {
        _httpClient = httpClient; 
        _httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
        // TODO: Check for a better way to set user-agent
        _httpClient.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (Windows NT 10; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0");
    }

    public async Task<IList<GitHubContributor>> GetContributors(string owner, string repo)
    {
        // Comment:
        // Github api returns uptp 30 contributors by default.
        // If pagination is required see https://docs.github.com/en/rest/guides/using-pagination-in-the-rest-api?apiVersion=2022-11-28

        var uri = $"{Urls.GitHub}/repos/{owner}/{repo}/contributors";
        var responseFromGitHub = await _httpClient.GetAsync(uri);

        var responseString = await responseFromGitHub.Content.ReadAsStringAsync();

        if (!responseFromGitHub.IsSuccessStatusCode)
        {
            if (string.IsNullOrEmpty(responseString)) { responseString = "Unknown"; }
            throw new ApplicationException($"The response from GitHub was not successful. StatusCode:'{responseFromGitHub.StatusCode}'. responseString:'{responseString}'.");
        }

        var result = JsonSerializer.Deserialize<IList<GitHubContributor>>(
            responseString,
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
        if (result == null)
        {
            throw new ApplicationException($"Error deserializing result from GitHub.");
        }
    return result;
    }

}

