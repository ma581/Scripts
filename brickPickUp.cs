using UnityEngine;
using System.Collections;

public class brickPickUp : MonoBehaviour
{
    //Hand
    bool rightHandCollision = false;
    bool leftHandCollision = false;
    bool rightFinger1COllision = false;

    //Touching and closed
    bool RTouchAndClosed = false;
    bool LTouchAndClosed = false;

    //Holding
    bool Lholding = false;
    bool Rholding = false;

    //GameObject rightHand;
    //GameObject leftHand;
    public GameObject hand;
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

        if (rightHandCollision && rightFinger1COllision )
        {
            //Debug.Log("RColliding + Closed");
            RTouchAndClosed = true;
            PickUpObject(hand);
            //Debug.Log("RPicking up object!");


        }
        else {
            RTouchAndClosed = false;
            if (Rholding)
            {
                DropObject();
                rightFinger1COllision = false;
                rightHandCollision = false;
                //gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
            
            //Debug.Log("RDropping object!");

        }

        if (Input.GetKey(KeyCode.A))
        {
            //DropObject();
            rightFinger1COllision = false;
            rightHandCollision = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.name == "Bip001 R Finger12")
        {
            //Debug.Log(this.name + "Collided with " + col.gameObject.name);
            rightFinger1COllision = true;
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            //hand = col.gameObject;
        }



        ////Debug.Log(this.name + "Collided with " + col.gameObject.name);
        if (col.gameObject.name == "Bip001 R Hand")
        {
            //Debug.Log(this.name + "Collided with " + col.gameObject.name);
            rightHandCollision = true;
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            //hand = col.gameObject;
        }

        //if (col.gameObject.name == "Bip001 L Hand")
        //{
        //    Debug.Log(this.name + "Collided with " + col.gameObject.name);
        //    //GetComponent<Rigidbody>().isKinematic = true; // stop physics
        //    //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

        //    leftHandCollision = true;
        //    hand = col.gameObject;
        //}
    }

    void OnTriggerExit(Collider col)
    {


        if (col.gameObject.name == "Bip001 R Finger12")
        {
            //Debug.Log(this.name + " Stopped Collided with " + col.gameObject.name);
            rightFinger1COllision = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

        if (col.gameObject.name == "Bip001 R Hand")
        {
            //Debug.Log(this.name + " Stopped Collided with " + col.gameObject.name);
            rightHandCollision = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;

        }

        //if (col.gameObject.name == "Bip001 L Hand")
        //{
        //    //Debug.Log(this.name + "Stopped Collided with " + col.gameObject.name);

        //    leftHandCollision = false;

        //}

    }

    void PickUpObject(GameObject hand)
    {

        gameObject.GetComponent<Renderer>().material.color = Color.red;
        //Debug.Log("Pickup Method!");
        //Debug.Log(gameObject.name);

        //GetComponent<Rigidbody>().isKinematic = true; // stop physics

        transform.parent = hand.transform; // doesn't move yet, but will move w/what it hit
                                           // Debug.Log(gameObject.name + "parent is " + transform.parent.name);
        if(hand.name == "Bip001 L Hand")
        {
            Lholding = true;
        }
        else if(hand.name == "Bip001 R Hand")
        {
            Rholding = true;
            //Debug.Log("Rholding = " +  Rholding);
        }
    }

    void DropObject()
    {
        //gameObject.GetComponent<Renderer>().material.color = Color.green;
        //Debug.Log("DropObject Method!");
        GetComponent<Rigidbody>().isKinematic = false; // start physics
        transform.parent = null; //unparent it
    }

}

