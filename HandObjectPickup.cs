using UnityEngine;
using System.Collections;


// This script develops the picking up of an object that collides with the hand
public class HandObjectPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(this.name + "Collided with " + col.gameObject.name);

        if (col.gameObject.tag == "EnemyCube")
        {
            Debug.Log(this.name + "Collided with " + col.gameObject.name);
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit
        }
    }


    //void OnTriggerEnter(Collider col)
    //{
    //    Debug.Log(this.name + "Collided with " + col.gameObject.name);

    //    if (col.gameObject.tag == "EnemyCube")
    //    {
    //        Debug.Log(this.name + "Collided with " + col.gameObject.name);
    //        //GetComponent<Rigidbody>().isKinematic = true; // stop physics
    //        //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit
    //    }
    //}
}
