using UnityEngine;
using System.Collections;


// This script currently detects collision with an object for testing hand collision
public class StickyCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision col)
    {
        Debug.Log(this.name + "Collided with " + col.gameObject.name);

        if (col.gameObject.tag == "Player")
        {
            Debug.Log(this.name + "Collided with " + col.gameObject.name);
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit
        }

        if (col.gameObject.tag == "RightHand")
        {
            Debug.Log(this.name + "Collided with " + col.gameObject.name);
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit
        }
    }
}
