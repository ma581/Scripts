using UnityEngine;
using System.Collections;

public class StickyCube0 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Called when there is a collision

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Background")
        {

        }
        else
        {
            Debug.Log(this.name + "Collided with " + c.gameObject.name);
            var joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = c.rigidbody;
        }

    }
}
