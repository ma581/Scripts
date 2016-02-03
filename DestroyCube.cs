using UnityEngine;
using System.Collections;

public class DestroyCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    // Called when there is a collision
    void OnCollisionEnter(Collision col)
    {

        Debug.Log(this.name + "Collided with " + col.gameObject.name);

        if (col.gameObject.tag == "EnemyCube")
        {
            Destroy(col.gameObject);

        } 
    }
}
