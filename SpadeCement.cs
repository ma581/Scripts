using UnityEngine;
using System.Collections;

public class SpadeCement : MonoBehaviour {

    private TrailRenderer trailRenderer;
    
	// Use this for initialization
	void Start () {

        trailRenderer = gameObject.GetComponent<TrailRenderer>();
        trailRenderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(gameObject.tag == "Brick")
        {
            trailRenderer.enabled = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        trailRenderer.enabled = false;
    }
}
