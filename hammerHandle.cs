using UnityEngine;
using System.Collections;

public class hammerHandle : MonoBehaviour {
    public GameObject rightForearm;
    GameObject rightHand, originalParent;
    bool rightHandCollision = false;
    bool collideAndFist = false;
    bool fist = false;
    bool readyToPickUP = false;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Alpha3))
        {
            readyToPickUP = true;
        }

        if (readyToPickUP)
        {
            if (rightHandCollision == true)
            {
                Debug.Log("Colliding and fist closed");
                collideAndFist = true;
                PickUpObject(rightForearm);
                Debug.Log("Picking up object!");


            }
            else
            {
                Debug.Log("Both Hands are not colliding");
                collideAndFist = false;
                //DropObject();
                Debug.Log("Dropping object!");

            }
        }
    }

    

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(this.name + "Collided with " + col.gameObject.name);
        if (col.gameObject.name == "Bip001 R Hand")
        {
            Debug.Log(this.name + "Collided with " + col.gameObject.name);
            rightHandCollision = true;
            rightHand = col.gameObject;
        }

        //if (col.gameObject.name == "Bip001 L Forearm")
        //{
        //    Debug.Log(this.name + "Collided with " + col.gameObject.name);
        //    //GetComponent<Rigidbody>().isKinematic = true; // stop physics
        //    //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

        //    leftHandCollision = true;
        //    leftHand = col.gameObject;
        //}
    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.name == "Bip001 R Hand")
        {
            Debug.Log(this.name + " Stopped Collided with " + col.gameObject.name);
            rightHandCollision = false;
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit


        }

        //if (col.gameObject.name == "Bip001 L Forearm")
        //{
        //    Debug.Log(this.name + "Stopped Collided with " + col.gameObject.name);
        //    //GetComponent<Rigidbody>().isKinematic = true; // stop physics
        //    //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

        //    //GetComponent<Rigidbody>().isKinematic = true; // stop physics
        //    //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit
        //    leftHandCollision = false;

        //}

    }


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
