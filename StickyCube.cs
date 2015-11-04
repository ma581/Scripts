using UnityEngine;
using System.Collections;

public class StickyCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log(this.name + "Collided with " + col.gameObject.name);
            GetComponent<Rigidbody>().isKinematic = true; // stop physics
            transform.parent = col.transform; // doesn't move yet, but will move w/what it hit
        }
    }
}
