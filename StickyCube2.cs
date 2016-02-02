using UnityEngine;
using System.Collections;

public class StickyCube2 : MonoBehaviour {

    bool rightHandCollision = false;
    bool leftHandCollision = false;
    bool bothHandsColliding = false;

    public GameObject rightHand;
    public GameObject leftHand; 
    public GameObject objectOrgParent;
    //private GameObject grabbedObject = this; 
    //private Transform objectOrgParent = null;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (rightHandCollision == true && leftHandCollision == true)
        {
            Debug.Log("Both Hands are colliding");
            bothHandsColliding = true;
            PickUpObject(rightHand);
            Debug.Log("Picking up object!");


        }
        else {
            Debug.Log("Both Hands are not colliding");
            bothHandsColliding = false;
            DropObject();
            Debug.Log("Dropping object!");

        }


	
	}

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(this.name + "Collided with " + col.gameObject.name);
        if (col.gameObject.name == "Bip001 R Forearm")
        {
            Debug.Log(this.name + "Collided with " + col.gameObject.name);
            rightHandCollision = true;
            rightHand = col.gameObject;
        }

        if (col.gameObject.name == "Bip001 L Forearm")
        {
            Debug.Log(this.name + "Collided with " + col.gameObject.name);
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

            leftHandCollision = true;
            leftHand = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col){

          if (col.gameObject.name == "Bip001 R Forearm")
        {
            Debug.Log(this.name + " Stopped Collided with " + col.gameObject.name);
            rightHandCollision = false;
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit


        }

        if (col.gameObject.name == "Bip001 L Forearm")
        {
            Debug.Log(this.name + "Stopped Collided with " + col.gameObject.name);
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit
            leftHandCollision = false;

        }

    }




    //    void OnTriggerStay(Collider col)
    //{
    //    //Debug.Log(this.name + "Collided with " + col.gameObject.name);
    //    if (col.gameObject.name == "Bip001 R Forearm")
    //    {
    //        Debug.Log("TriggerStay"+ this.name + "Collided with " + col.gameObject.name);
    //        //GetComponent<Rigidbody>().isKinematic = true; // stop physics
    //        //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

    //        //GetComponent<Rigidbody>().isKinematic = true; // stop physics
    //        //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit


    //    }

    //    if (col.gameObject.name == "Bip001 L Forearm")
    //    {
    //        Debug.Log("TriggerStay" + this.name + "Collided with " + col.gameObject.name);
    //        //GetComponent<Rigidbody>().isKinematic = true; // stop physics
    //        //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

    //        //GetComponent<Rigidbody>().isKinematic = true; // stop physics
    //        //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit


    //    }
    //}

    void PickUpObject(GameObject hand)
    {
        Debug.Log("Pickup Method!");
        //Debug.Log(gameObject.name);
        GetComponent<Rigidbody>().isKinematic = true; // stop physics
        //objectOrgParent = gameObject.transform.parent;
        //Debug.Log(gameObject.name + "Original parent is " + objectOrgParent.name);

        transform.parent = hand.transform; // doesn't move yet, but will move w/what it hit
       // Debug.Log(gameObject.name + "parent is " + transform.parent.name);

    }

    void DropObject()
    {
        Debug.Log("DropObject Method!");
        GetComponent<Rigidbody>().isKinematic = false; // start physics
        transform.parent = null; //unparent it
    }

    }

