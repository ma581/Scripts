using UnityEngine;
using System.Collections;

public class SpadeCement : MonoBehaviour {

    //private TrailRenderer trailRenderer;
    public Material Brick;
    public Material Cement;

	// Use this for initialization
	void Start () {


        //gameObject.GetComponent<TrailRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag == "Cement")
        {
            //Debug.Log("BRICKS");
            //gameObject.GetComponent<TrailRenderer>().enabled = true;
            col.gameObject.GetComponent<Renderer>().material = Cement;
        }
    }

    void OnCollisionExit(Collision col)
    {
        //gameObject.GetComponent<TrailRenderer>().enabled = false;
        //col.gameObject.GetComponent<ParticleSystem>().enableEmission = false;

        //col.gameObject.GetComponent<Renderer>().material = Brick;


    }
}
