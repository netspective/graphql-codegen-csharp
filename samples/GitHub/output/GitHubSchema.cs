/* tslint:disable */

public class Query {
  public List<Entry> Feed; /** A feed of repository submissions */
  public Entry Entry; /** A single entry */
  public User CurrentUser; /** Return the currently logged in user, or null if nobody is logged in */
}
/** Information about a GitHub repository submitted to GitHunt */
public class Entry {
  public Repository Repository; /** Information about the repository from GitHub */
  public User PostedBy; /** The GitHub user who submitted this entry */
  public float CreatedAt; /** A timestamp of when the entry was submitted */
  public int Score; /** The score of this repository, upvotes - downvotes */
  public float HotScore; /** The hot score of this repository */
  public List<Comment> Comments; /** Comments posted about this repository */
  public int CommentCount; /** The number of comments posted about this repository */
  public int Id; /** The SQL ID of this entry */
  public Vote Vote; /** XXX to be changed */
}
/** A repository object from the GitHub API. This uses the exact field names returned by theGitHub API for simplicity, even though the convention for GraphQL is usually to camel case. */
public class Repository {
  public string Name; /** Just the name of the repository, e.g. GitHunt-API */
  public string FullName; /** The full name of the repository with the username, e.g. apollostack/GitHunt-API */
  public string Description; /** The description of the repository */
  public string HtmlUrl; /** The link to the repository on GitHub */
  public int StargazersCount; /** The number of people who have starred this repository on GitHub */
  public int OpenIssuesCount; /** The number of open issues on this repository on GitHub */
  public User Owner; /** The owner of this repository on GitHub, e.g. apollostack */
}
/** A user object from the GitHub API. This uses the exact field names returned from the GitHub API. */
public class User {
  public string Login; /** The name of the user, e.g. apollostack */
  public string AvatarUrl; /** The URL to a directly embeddable image for this user's avatar */
  public string HtmlUrl; /** The URL of this user's GitHub page */
}
/** A comment about an entry, submitted by a user */
public class Comment {
  public int Id; /** The SQL ID of this entry */
  public User PostedBy; /** The GitHub user who posted the comment */
  public float CreatedAt; /** A timestamp of when the comment was posted */
  public string Content; /** The text of the comment */
  public string RepoName; /** The repository which this comment is about */
}
/** XXX to be removed */
public class Vote {
  public int VoteValue; 
}

public class Mutation {
  public Entry SubmitRepository; /** Submit a new repository, returns the new submission */
  public Entry Vote; /** Vote on a repository submission, returns the submission that was voted on */
  public Comment SubmitComment; /** Comment on a repository, returns the new comment */
}

public class Subscription {
  public Comment CommentAdded; /** Subscription fires on every comment added */
}
public interface FeedQueryArgs {
  public FeedType type; /** The sort order for the feed */
  public int offset; /** The number of items to skip, for pagination */
  public int limit; /** The number of items to fetch starting from the offset, for pagination */
}
public interface EntryQueryArgs {
  public string repoFullName; /** The full repository name from GitHub, e.g. "apollostack/GitHunt-API" */
}
public interface CommentsEntryArgs {
  public int limit; 
  public int offset; 
}
public interface SubmitRepositoryMutationArgs {
  public string repoFullName; /** The full repository name from GitHub, e.g. "apollostack/GitHunt-API" */
}
public interface VoteMutationArgs {
  public string repoFullName; /** The full repository name from GitHub, e.g. "apollostack/GitHunt-API" */
  public VoteType type; /** The type of vote - UP, DOWN, or CANCEL */
}
public interface SubmitCommentMutationArgs {
  public string repoFullName; /** The full repository name from GitHub, e.g. "apollostack/GitHunt-API" */
  public string commentContent; /** The text content for the new comment */
}
public interface CommentAddedSubscriptionArgs {
  public string repoFullName; 
}
/** A list of options for the sort order of the feed */
public enum FeedType {
  HOT, 
  NEW, 
  TOP
}
/** The type of vote to record, when submitting a vote */
public enum VoteType {
  UP, 
  DOWN, 
  CANCEL
}
