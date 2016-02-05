using UnityEngine;
using System.Collections;

public class FingerManager : MonoBehaviour {



    //int[] list1 = new int[4] { 1, 2, 3, 4 };
    //int[] list2 = new int[4] { 5, 6, 7, 8 };
    //int[] list3 = new int[4] { 1, 3, 2, 1 };
    //int[] list4 = new int[4] { 5, 4, 3, 2 };

    //int[][] lists = new int[][] { list1, list2, list3, list4 };


    public Transform[] fingerSubs1 = new Transform[2];
    public Transform[] fingerSubs2 = new Transform[2];
    public Transform[] fingerSubs3 = new Transform[2];
    public Transform[] fingerSubs4 = new Transform[2];
    public Transform[] fingerSubs0 = new Transform[2];
    public Transform[][] finger;

    //public Transform[] fingerSubs = new Transform[2]; //array to store finger sub units
    // Use this for initialization
    void Start() {
        finger = new Transform[][] {fingerSubs0, fingerSubs1, fingerSubs2, fingerSubs3, fingerSubs4};
    }

        //for (int i = 0; i < 1; i++) {
        //    finger[i] = fingerSubs;
        //}
       //Takes in all fingers   


// Update is called once per frame
void Update () {
	
	}

    //public void assignFingerSubs(Transform finger)
    //{
    //    theFinger = finger;
    //    fingerSubs[0] = theFinger.transform.GetChild(0);
    //    fingerSubs[1] = theFinger.transform.GetChild(0).GetChild(0);
    //    Debug.Log("Assigning Finger sub units");
        
    //}
}

