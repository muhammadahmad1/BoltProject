using UnityEngine;
using System.Collections;

//This allows Bolt to automatically attach this script to an object in game.
[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener 
{
    public override void SceneLoadLocalDone(string map)
    {
        //Randomise the position of the cube
        var pos = new Vector3(Random.Range(-16, 16), 0, Random.Range(-16, 16));

        //Instantiate the Cube in the network
        BoltNetwork.Instantiate(BoltPrefabs.Cube, pos, Quaternion.identity);
    }
}
