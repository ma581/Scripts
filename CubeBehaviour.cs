using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CubeBehaviour : MonoBehaviour {

	// Use this for initialization
    //void Start () {
	
    //}
	
	// Update is called once per frame
	void Update () {
        ////Read the input
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log("Input: " + moveHorizontal);

        //var movement = new Vector3(0f, 0f, moveHorizontal * 10);
        //transform.GetComponent<Rigidbody>().velocity = movement;


        //float moveVertical = Input.GetAxis("Vertical");
        //Debug.Log("Input: " + moveVertical);

        //var movement_vertical = new Vector3(0f, moveVertical * 10, 0f);
        //transform.GetComponent<Rigidbody>().velocity = movement_vertical;
	
	}

    void OnCollisionEnter(Collision col)
    {
        //Called when there is a collision
        //Debug.Log(this.name + "Collided with " + col.gameObject.name);

        //if (col.gameObject.tag == "Player")
        //{
        //    //Destroy(c.gameObject);
        //}

        //if (col.gameObject.tag == "EnemyCube")
        //{
        //    Destroy(col.gameObject);
        //    Debug.Log("Destroyed!");

        //}
        Destroy(col.gameObject);

        //var joint = gameobject.addcomponent<fixedjoint>();
        //joint.connectedbody = c.rigidbody;
    }
}
