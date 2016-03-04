using UnityEngine;
using System.Collections;

public class AreaTrigger : MonoBehaviour {

    public bool HandInRegion = false;
    private bool toggle = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Bip001 R Hand")
        {
            HandInRegion = !HandInRegion;
            Debug.Log("HAND IN HAMMER REGION");
        }
    }

    
}
