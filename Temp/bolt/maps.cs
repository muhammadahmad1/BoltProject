using System.Collections.Generic;
public static class BoltScenes {
  static internal readonly Dictionary<string, int> nameLookup = new Dictionary<string, int>();
  static internal readonly Dictionary<int, string> indexLookup = new Dictionary<int, string>();
  public static void AddScene(short prefix, short id, string name) {
    int index = (prefix << 16) | (int)id;
    nameLookup.Add(name, index);
    indexLookup.Add(index, name);
  }
  static public IEnumerable<string> AllScenes { get { return nameLookup.Keys; } }
  static BoltScenes() {
    AddScene(0, 0, "Tutorial1_Menu");
    AddScene(0, 1, "Tutorial1");
  }
  public const string Tutorial1_Menu = "Tutorial1_Menu";
  public const string Tutorial1 = "Tutorial1";
}
namespace BoltInternal {
  public static class BoltScenes_Internal {
    static public int GetSceneIndex(string name) { return BoltScenes.nameLookup[name]; }
    static public string GetSceneName(int index) { return BoltScenes.indexLookup[index]; }
  }
}
