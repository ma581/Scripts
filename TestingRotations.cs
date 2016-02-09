using UnityEngine;
using System.Collections;

public class TestingRotations : MonoBehaviour {

    public GameObject Target;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            ////Face a postion
            //Vector3 TargetLocation = Target.transform.position - this.transform.position;
            //Quaternion TargetRotation = Quaternion.FromToRotation(transform.forward, TargetLocation);
            //this.transform.rotation = TargetRotation;

            //Face a direction
            transform.rotation = Quaternion.FromToRotation(transform.forward, Target.transform.forward);
        }

        

    }
}
