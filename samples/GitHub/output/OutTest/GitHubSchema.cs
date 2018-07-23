using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// Query start 

namespace Generated
{
    public interface IQuery
    {
        string GetQueryText();
        object GetParsedObject(string jsonText);
    }

    public interface IQuery<T> : IQuery
    {
        new T GetParsedObject(string jsonText);
    }
}


namespace Generated.MyQuery 
{

    /// <summary>Operation Type</sumary>
    public class Query : IQuery<Data>
    { 
        private readonly string _login;
        private readonly string _repo;

        public Query(string  login,string  repo)
        {
            _login = login;
            _repo = repo;
        }

    public string GetQueryText()
    {
        return JsonConvert.SerializeObject(new
        {
            query = @"
query MyQuery($login: String = rails, $repo: String = rails) {
  organization(login: $login) {
    name
    url
    repository(name: $repo) {
      name
      pullRequests(last: 10, states: [OPEN]) {
        edges {
          node {
            title
            comments(last: 10) {
              edges {
                node {
                  author {
                    login
                  }
                }
              }
            }
          }
        }
      }
    }
  }
}",
            variables = new {
                    login = _login,repo = _repo,
                }
            });
        }  

        public Data GetParsedObject(string jsonText)
        {
            return JsonConvert.DeserializeObject<Result>(jsonText).Data;
        }

        string IQuery.GetQueryText()
        {
            return GetQueryText();
        }

        Data IQuery<Data>.GetParsedObject(string jsonText)
        {
            return GetParsedObject(jsonText);
        }

        object IQuery.GetParsedObject(string jsonText)
        {
            return GetParsedObject(jsonText);
        }
    }

    public class Result
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        
        [JsonProperty("organization")]
        public Organization Organization { get; set; }
    }

    /// <summary>Inner Model</sumary> 
    public class Organization 
    {
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("url")]
        public Uri Url { get; set; }
        
        [JsonProperty("repository")]
        public Repository Repository { get; set; }
    }
    /// <summary>Inner Model</sumary> 
    public class Repository 
    {
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("pullRequests")]
        public PullRequests PullRequests { get; set; }
    }
    /// <summary>Inner Model</sumary> 
    public class PullRequests 
    {
        
        [JsonProperty("edges")]
        public List<Edges> Edges { get; set; }
    }
    /// <summary>Inner Model</sumary> 
    public class Edges 
    {
        
        [JsonProperty("node")]
        public Node Node { get; set; }
    }
    /// <summary>Inner Model</sumary> 
    public class Node 
    {
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("comments")]
        public Comments Comments { get; set; }
    }
    /// <summary>Inner Model</sumary> 
    public class Comments 
    {
        
        [JsonProperty("edges")]
        public List<_Edges> Edges { get; set; }
    }
    /// <summary>Inner Model</sumary> 
    public class _Edges 
    {
        
        [JsonProperty("node")]
        public _Node Node { get; set; }
    }
    /// <summary>Inner Model</sumary> 
    public class _Node 
    {
        
        [JsonProperty("author")]
        public Author Author { get; set; }
    }
    /// <summary>Inner Model</sumary> 
    public class Author 
    {
        
        [JsonProperty("login")]
        public string Login { get; set; }
    }
}


// Query end