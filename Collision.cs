using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onCollisionEnter(Collision c)
    {
        //Called when there is a collision

        Debug.Log(this.name + "Collided with " + c.gameObject.name);

        if (c.gameObject.tag == "Player")
        {

        }

        //var joint = gameobject.addcomponent<fixedjoint>();
        //joint.connectedbody = c.rigidbody;
    }
}
