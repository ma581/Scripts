using UnityEngine;
using System.Collections;

public class fistGesture : MonoBehaviour
{

    //public GameObject FistScript;
    //private RUISSkeletonController fistGestureRec;



    //private RUISSkeletonManager.Skeleton.handState leftHandStatus, lastLeftHandStatus;
    //private RUISSkeletonManager.Skeleton.handState rightHandStatus, lastRightHandStatus;
    //public RUISSkeletonManager skeletonManager;
    //bool l_state, r_state;

    // Use this for initialization
    void Start()
    {
        //fistGestureRec = FistScript.GetComponent<RUISSkeletonController>();
    }

    // Update is called once per frame
    void Update()

    {


        if (RUISSkeletonController.leftHandClosed)
        {
            Debug.Log("LHand is Closed!");
        }
        else
        {
            Debug.Log("LHand is Open!");
        }
        if (RUISSkeletonController.rightHandClosed)
        {
            Debug.Log("RHand is Closed!");
        }
        {
            Debug.Log("RHand is Open!");
        }
    }
}
