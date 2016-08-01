﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This allows Bolt to automatically attach this script to an object in game.
[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener 
{
    List<string> logMessages = new List<string>();

    public override void SceneLoadLocalDone(string map)
    {
        //Randomise the position of the cube
        var pos = new Vector3(Random.Range(-16, 16), 0, Random.Range(-16, 16));

        //Instantiate the Cube in the network
        BoltNetwork.Instantiate(BoltPrefabs.Cube, pos, Quaternion.identity);
    }

    public override void OnEvent(LogEvent evnt)
    {
        logMessages.Insert(0, evnt.Message);
    }

    void OnGUI()
    {
        int maxMessages = Mathf.Min(5, logMessages.Count);

        GUILayout.BeginArea(new Rect(Screen.width / 2 - 200, Screen.height - 100, 400, 100), GUI.skin.box);

        for (int i = 0; i < maxMessages; ++i)
        {
            GUILayout.Label(logMessages[i]);
        }

        GUILayout.EndArea();
    }
}
