using UnityEngine;
using System.Collections;

//use BoltNetworkModes.Host first
[BoltGlobalBehaviour(BoltNetworkModes.Host)]
public class ServerCallbacks : Bolt.GlobalEventListener 
{
    //This is called when a connection is made to the server
    public override void Connected(BoltConnection connection)
    {
        var log = LogEvent.Create();
        log.Message = string.Format("{0} connected!", connection.RemoteEndPoint);
        log.Send();
    }

    public override void Disconnected(BoltConnection connection)
    {
        var log = LogEvent.Create();
        log.Message = string.Format("{0} disconnected!", connection.RemoteEndPoint);
        log.Send();
    }
}
