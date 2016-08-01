using UnityEngine;
using System.Collections;

//Bolt.EntityEventListener inherits from EntityBehaviour which inherits from MonoBehaviour
public class CubeBehaviour : Bolt.EntityEventListener<ICubeState>
{
    float resetColorTime;
    Renderer renderer;

    public override void  Attached()
    {
        renderer = GetComponent<Renderer>();

        //update the network property of state ICubeState with the transform of the object 
        //this script is attached to.
        //state.CubeTransform.SetTransforms(transform);
        state.CubeTransform.ChangeTransforms(transform);

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

        if (Input.GetKeyDown(KeyCode.F))
        {
            //requires the entity to send the event to -> it will send the 
            //event to the instance of this *specific* cube to all clients.
            var flash = FlashColorEvent.Create(entity);
            flash.FlashColor = Color.red;
            flash.Send();
        }
    }

    void ColorChanged()
    {
        renderer.material.color = state.CubeColor;
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

    public override void OnEvent(FlashColorEvent evnt)
    {
        resetColorTime = Time.time + 0.25f;
        renderer.material.color = evnt.FlashColor;
    }

    void Update()
    {
        if (resetColorTime < Time.time)
        {
            renderer.material.color = state.CubeColor;
        }
    }
}
