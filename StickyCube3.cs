using UnityEngine;
using System.Collections;

public class StickyCube3 : MonoBehaviour
{

    bool rightHandCollision = false;
    bool leftHandCollision = false;
    bool RTouchAndClosed = false;
    bool LTouchAndClosed = false;

    bool Lholding = false;
    bool Rholding = false;

    //GameObject rightHand;
    //GameObject leftHand;
    GameObject hand;
    GameObject objectOrgParent;




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(string.Format("R Collision: {0}", rightHandCollision));
        //Debug.Log(string.Format("R CLosed: {0}", RUISSkeletonController.rightHandClosed));

        if (rightHandCollision == true && RUISSkeletonController.rightHandClosed == true)
        {
            Debug.Log("RColliding + Closed");
            RTouchAndClosed = true;
            PickUpObject(hand);
            Debug.Log("RPicking up object!");


        }
        else {
            RTouchAndClosed = false;
            if (Rholding)
            {
                DropObject();
            }
            
            //Debug.Log("RDropping object!");

        }

        //if (leftHandCollision == true && RUISSkeletonController.leftHandClosed == true)
        //{
        //    Debug.Log("LColliding + Closed");
        //    LTouchAndClosed = true;
        //    PickUpObject(hand);
        //    Debug.Log("LPicking up object!");


        //}
        //else {
        //    LTouchAndClosed = false;
        //    DropObject();
        //    //.Log("LDropping object!");
        //    if (Lholding)
        //    {
        //        DropObject();
        //    }

        //}


    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(this.name + "Collided with " + col.gameObject.name);
        if (col.gameObject.name == "Bip001 R Hand")
        {
            Debug.Log(this.name + "Collided with " + col.gameObject.name);
            rightHandCollision = true;
            hand = col.gameObject;
        }

        if (col.gameObject.name == "Bip001 L Hand")
        {
            Debug.Log(this.name + "Collided with " + col.gameObject.name);
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

            leftHandCollision = true;
            hand = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.name == "Bip001 R Hand")
        {
            //Debug.Log(this.name + " Stopped Collided with " + col.gameObject.name);
            rightHandCollision = false;
            


        }

        if (col.gameObject.name == "Bip001 L Hand")
        {
            //Debug.Log(this.name + "Stopped Collided with " + col.gameObject.name);

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
        if(hand.name == "Bip001 L Hand")
        {
            Lholding = true;
        }
        else if(hand.name == "Bip001 R Hand")
        {
            Rholding = true;
        }
    }

    void DropObject()
    {
        Debug.Log("DropObject Method!");
        GetComponent<Rigidbody>().isKinematic = false; // start physics
        transform.parent = null; //unparent it
    }

}

