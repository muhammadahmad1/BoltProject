using UnityEngine;
using System.Collections;

public class CubeBehaviour : Bolt.EntityBehaviour<ICubeState>
{
    public override void  Attached()
    {
        //update the network property of state ICubeState with the transform of the object 
        //this script is attached to.
        state.CubeTransform.SetTransforms(transform);

        if (entity.isOwner)
        {
            state.CubeColor = new Color(Random.value, Random.value, Random.value);
        }

        state.AddCallback("CubeColor", ColorChanged);
    }

    //like void Update() but will only run on the computer that instantiated the prefab.
    public override void SimulateOwner()
    {
        var speed = 4f;
        var movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) { movement.z += 1; }
        if (Input.GetKey(KeyCode.S)) { movement.z -= 1; }
        if (Input.GetKey(KeyCode.A)) { movement.x -= 1; }
        if (Input.GetKey(KeyCode.D)) { movement.x += 1; }
        
        if (movement != Vector3.zero)
        {
            transform.position = transform.position + (movement.normalized * speed * BoltNetwork.frameDeltaTime);
        }
    }

    void ColorChanged()
    {
        GetComponent<Renderer>().material.color = state.CubeColor;
    }

    void OnGUI()
    {
        if (entity.isOwner)
        {
            GUI.color = state.CubeColor;
            GUILayout.Label("@@@");
            GUI.color = Color.white;
        }
    }
}
