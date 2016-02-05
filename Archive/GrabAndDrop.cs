using UnityEngine;
using System.Collections;

public class GrabAndDrop : MonoBehaviour {

    GameObject grabbedObject;
    float grabbedObjecSize;

	// Use this for initialization
	void Start () {
	
	}

    // Getting object on the Mouse
    GameObject GetMouseHoverObject(float range) {

        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;

        if (Physics.Linecast(position, target, out raycastHit))
        {
            Debug.Log("Grabbed " + gameObject.name );
            return raycastHit.collider.gameObject;
            
        }
        return null;

    }


    void TryGrabObject(GameObject grabObject)
    {
        Debug.Log("Entered TryGrabObect");

        if (grabbedObject == null) { return; }
        grabbedObject = grabObject;
        grabbedObjecSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude;
    }

    void DropObject()
    {
        if (grabbedObject == null) 
        { 
            return; }
        grabbedObject = null;
    }

	// Update is called once per frame
	void Update () {
        //Check if GetMouseHoverObject is working
       // Debug.Log(GetMouseHoverObject(5));

        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("Mouse Clicked");
            if (grabbedObject == null)
            {
                TryGrabObject(GetMouseHoverObject(5));
                Debug.Log("Trying to grab object");

            }
            else
            {
                DropObject();
                Debug.Log("Dropping object");

            }


            if (grabbedObject != null)
            {
                // Move object with mouse
                Debug.Log("Moving object");
                Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * grabbedObjecSize;
                grabbedObject.transform.position = newPosition;
            }
        }
	}


    
}
