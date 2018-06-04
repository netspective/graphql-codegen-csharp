/* tslint:disable */

public interface ICharacter {
  string id{ get; set; } 
  string name{ get; set; } 
  List<Character> friends{ get; set; } 
  List<Episode> appearsIn{ get; set; } 
}

public class Query {
  public Character Hero; 
  public Human Human; 
  public Droid Droid; 
}

public class Human : ICharacter {
  public string Id; 
  public string Name; 
  public List<Character> Friends; 
  public List<Episode> AppearsIn; 
  public string HomePlanet; 
}

public class Droid : ICharacter {
  public string Id; 
  public string Name; 
  public List<Character> Friends; 
  public List<Episode> AppearsIn; 
  public string PrimaryFunction; 
}
public interface HeroQueryArgs {
  public Episode episode; 
}
public interface HumanQueryArgs {
  public string id; 
}
public interface DroidQueryArgs {
  public string id; 
}

public enum Episode {
  NEWHOPE, 
  EMPIRE, 
  JEDI
}
