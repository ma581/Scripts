using UnityEngine;
using System.Collections;

public class EnableComponent : MonoBehaviour {

    private RUISSkeletonController skelController;
    public GameObject MechBlendChar; //Do  nothing 

    void Start()
    {
        skelController = MechBlendChar.GetComponent<RUISSkeletonController>();
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            skelController.enabled = !skelController.enabled;
            Debug.Log(skelController.enabled);
        }
    }
}
