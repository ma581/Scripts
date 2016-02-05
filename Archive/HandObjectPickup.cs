using UnityEngine;
using System.Collections;


// This script develops the picking up of an object that collides with the hand
// http://serrarens.nl/passervr/grabbing-virtual-hands-in-unity/
public class HandObjectPickup : MonoBehaviour {

    public GameObject hand; //Need to look at the RUISSkeletonManager to find a hand gameobject where we have its co-ordinates
    //public RUISSkeletonManager.Joint rightHand = RUISSkeletonManager.Joint.RightHand;
    
    
    
    private GameObject grabbedObject = null;
    private Transform objectOrgParent = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) == true)
        {
            Debug.Log("Mouse pressed");
        }

	
	}

    //void OnCollisionEnter(Collision col)
    //{
    //    //Debug.Log(this.name + "Collided with " + col.gameObject.name);

    //    if (col.gameObject.tag == "EnemyCube")
    //    {
    //        Debug.Log(this.name + "Collided with " + col.gameObject.tag);
    //        // Currently this makes the hand fly off!
    //        //GetComponent<Rigidbody>().isKinematic = true; // stop physics
    //        //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit
    //    }
    //}


    void OnTriggerEnter(Collider col)
    {
        Debug.Log(this.name + "Collided with " + col.gameObject.name);

        if (col.gameObject.tag == "EnemyCube") //if its pickable
        {
            //Debug.Log(this.name + "Collided with " + col.gameObject.tag);
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

        }
    }






    void OnTriggerStay(Collider collision)
    {
        Debug.Log("Entered CollisionStay");

        if (collision.gameObject.tag == "EnemyCube")
        {
            Debug.Log("Entered CollisionStay with EnemyCube");

            if (Input.GetMouseButton(0) == true)
            { // Hand is closed

                // the object we grab
                grabbedObject = collision.gameObject;
                Debug.Log("Grabbed " + collision.gameObject.tag);

                // Make it kinematic as we are holding it now
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                Debug.Log(collision.gameObject.tag + " is Kinematic ");

                // Store the original parent to restore it when letting loose
                objectOrgParent = grabbedObject.transform.parent;
                Debug.Log(" Original parent stored ");


                //// And parent it to the hand
                grabbedObject.transform.parent = hand.transform;
                Debug.Log(collision.gameObject.tag + " is parented to ");

            }
        }
    }



    void FixedUpdate()
    {
        if (grabbedObject != null)
        { // are we holding an object?
            if (Input.GetMouseButton(0) == false)
            { // Hand is open
                Debug.Log("Hand is open");

                // unparent it from the thumb
                grabbedObject.transform.parent = objectOrgParent;
                // make it non-kinematic again
                grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                // and clear the grabbed object
                grabbedObject = null;
            }
        }
    }

}
