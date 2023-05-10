namespace GitHubProxy.Models;

public class GitHubContributor
{
    public string login { get; set; } = string.Empty;
    public string avatar_url { get; set; } = string.Empty;
    public string url { get; set; } = string.Empty;
    public string type { get; set; } = string.Empty;
    public int contributions { get; set; }

}



