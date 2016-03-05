using UnityEngine;
using System.Collections;

public class PickUpJoint : MonoBehaviour
{

    //public GameObject hand;
    //Rigidbody rigidHand;
    public GameObject HammerRegion; //Do  nothing 
    private AreaTrigger hammerAreaTrig;


    bool f = false;


    public GameObject heldHammer;
    public GameObject tableHammer;

    void Start()
    {
        heldHammer.SetActive(false);
        hammerAreaTrig = HammerRegion.GetComponent<AreaTrigger>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            f = !f;
            heldHammer.SetActive(f);
            tableHammer.SetActive(!f);
        }

        
            heldHammer.SetActive(hammerAreaTrig.HandInRegion);
            tableHammer.SetActive(!hammerAreaTrig.HandInRegion);
       

        

    }


}