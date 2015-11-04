using UnityEngine;
using System.Collections;

public class HorizontalMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Update () {

        //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log("Input: " + moveHorizontal);

        //var movement = new Vector3(0f, 0f, moveHorizontal * 10);
        //transform.GetComponent<Rigidbody>().velocity = movement;

        ////Lateral x
        //float moveLateral = Input.GetAxis("Vertical");
        //Debug.Log("Input: " + moveLateral);

        //var movement2 = new Vector3(moveLateral * 10, 0f, 0f );
        //transform.GetComponent<Rigidbody>().velocity = movement2;

        //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //moveDirection = transform.TransformDirection(moveDirection);
        ////moveDirection *= speed;
        //transform.GetComponent<Rigidbody>().velocity = moveDirection;
	}

    void FixedUpdate() {

            var movement = new Vector3( Input.GetAxis("Horizontal") * 10, 
                                        0,
                                        Input.GetAxis("Vertical") * 10);
            GetComponent<Rigidbody>().velocity = movement;
           

    }
}
