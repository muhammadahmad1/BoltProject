using UnityEngine;
using System.Collections;

public class Menu : Bolt.GlobalEventListener
{
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, Screen.width - 20, Screen.height - 20));

        if(GUILayout.Button("Start Server", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true)))
        {
            BoltLauncher.StartServer(UdpKit.UdpEndPoint.Parse(System.IO.File.ReadAllText("server-ip.txt")));
        }

        if (GUILayout.Button("Start Client", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true)))
        {
            BoltLauncher.StartClient();
        }

        GUILayout.EndArea();
    }

    public override void BoltStartDone()
    {
        if (BoltNetwork.isServer)
            BoltNetwork.LoadScene("Tutorial1");
        else 
            BoltNetwork.Connect(UdpKit.UdpEndPoint.Parse("185.12.7.211:44"));
    }
}
