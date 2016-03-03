using UnityEngine;
using System.Collections;

public class StickyWorkTop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bricks")
        {
            //Debug.Log("BRICK HIT TABLE");
            //col.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
          
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics

            //col.transform.parent = gameObject.transform.parent;
            //col.rigidbody.constraints = RigidbodyConstraints.FreezePositionX & RigidbodyConstraints.FreezePositionZ;
            //col.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
