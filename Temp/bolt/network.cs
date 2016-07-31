namespace BoltInternal {
  public static class BoltNetworkInternal_User {
    public static void EnvironmentSetup() {
      Bolt.Factory.Register(CubeState_Meta.Instance);
    }
    public static void EnvironmentReset() {
    }
  }
}
