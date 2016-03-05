using UnityEngine;
using System.Collections;

public class AreaTrigger : MonoBehaviour {

    public bool HandInRegion = false;

    bool fingerCollision = false;
    bool handCollision = false;
    bool bothColliding = false;
    bool updated = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(handCollision && fingerCollision)
        {
            bothColliding = true;
        }
        else
        {
            bothColliding = false;
            updated = false;
        }
        if (bothColliding && !updated)
        {
            HandInRegion = !HandInRegion;
            updated = true;
        }
        
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Bip001 R Hand")
        {
            //HandInRegion = !HandInRegion;
            //Debug.Log("HandInRegion = "+ HandInRegion);
            handCollision = true;
            Debug.Log("handCOllision = " + handCollision);
        }
        if(col.gameObject.name == "Bip001 R Finger12")
        {
            fingerCollision = true;
            Debug.Log("fingerCOllision = " + fingerCollision);
        }
    }


    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Bip001 R Hand")
        {
            //HandInRegion = !HandInRegion;
            //Debug.Log("HandInRegion = "+ HandInRegion);
            handCollision = false;
            Debug.Log("handCOllision = " + handCollision);
        }
        if (col.gameObject.name == "Bip001 R Finger12")
        {
            fingerCollision = false;
            Debug.Log("fingerCOllision = " + fingerCollision);
        }
    }


}
