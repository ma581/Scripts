using UnityEngine;
using System.Collections;

public class StickyCube3 : MonoBehaviour
{

    bool rightHandCollision = false;
    bool leftHandCollision = false;
    bool RTouchAndClosed = false;
    bool LTouchAndClosed = false;

    GameObject rightHand;
    GameObject leftHand;
    GameObject objectOrgParent;




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (rightHandCollision == true && RUISSkeletonController.rightHandClosed == true)
        {
            Debug.Log("Both Hands are colliding");
            RTouchAndClosed = true;
            PickUpObject(rightHand);
            Debug.Log("Picking up object!");


        }
        else {
            Debug.Log("Both Hands are not colliding");
            RTouchAndClosed = false;
            DropObject();
            Debug.Log("Dropping object!");

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

        if (col.gameObject.name == "Bip001 L Hand")
        {
            Debug.Log(this.name + "Collided with " + col.gameObject.name);
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

            leftHandCollision = true;
            leftHand = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.name == "Bip001 R Hand")
        {
            Debug.Log(this.name + " Stopped Collided with " + col.gameObject.name);
            rightHandCollision = false;
            


        }

        if (col.gameObject.name == "Bip001 L Hand")
        {
            Debug.Log(this.name + "Stopped Collided with " + col.gameObject.name);

            leftHandCollision = false;

        }

    }




   

    void PickUpObject(GameObject hand)
    {
        Debug.Log("Pickup Method!");
        //Debug.Log(gameObject.name);
        GetComponent<Rigidbody>().isKinematic = true; // stop physics

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

