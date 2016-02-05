using UnityEngine;
using System.Collections;

public class HandController1 : MonoBehaviour
{

    //public GameObject rightHandFinger0;
    //public GameObject rightHandFinger1;




    public GameObject rightHand;
    //private fingers[] fingersOfRHand = new fingers[4]; //initialisize class
    //private fingers fingersOfRHand = new fingers();
    //public Transform[] fingers;
    public FingerManager handFingers;
    //fingerTransforms.getFingerSubs(rightHand.transform.GetChild(0));
    // Use this for initialization
    void Start()
    {
        //rightHandFinger0_1 = rightHandFinger0.transform.GetChild(0).GetChild(0);
        //meeple = this.gameObject.transform.GetChild(0);

        //for(int i=0; i<5; i++)
        //{
        //    fingers[i] = rightHand.transform.GetChild(i);
        //    Debug.Log(fingers[i].transform.name);
        //}





        //for (int i=0; i<5; i++)
        //{
        //    Debug.Log("Getting fingers");
        //    fingersOfRHand[i].finger = rightHand.transform.GetChild(i); //assign fingers to array
        //    fingersOfRHand[i].getFingerSubs();
        //}

        //fingers fingers = new global::fingers(rightHand.transform.GetChild(0));

        //fingerTransforms.assignFingerSubs(rightHand.transform.GetChild(0));

    }

    // Update is called once per frame
    void Update()
    {
        //rightHandFinger0.transform.Translate(transform.up * Time.deltaTime * 1);
        //rightHandFinger0_1.transform.Rotate(Vector3.up * Time.deltaTime * 10f);
        //rightHandFinger0.transform.Translate(Vector3.up * Time.deltaTime * 0.1f); 
        //rightHandFinger1.transform.position = rightHandFinger1.transform.position + new Vector3(1, 1, 1)*Time.deltaTime*0.1f;

        //fingersOfRHand[0].finger.transform.Rotate(Vector3.up * Time.deltaTime * 10f);
        //fingersOfRHand[0].fingerSubs[0].Rotate(Vector3.up * Time.deltaTime * 10f);
        //fingersOfRHand[1].fingerSubs[1].transform.Rotate(Vector3.up * Time.deltaTime * 10f);
        //Debug.Log(fingers[1].name);
        //rightHand.transform.GetChild(1).Rotate(Vector3.up * Time.deltaTime * 10f);
        //fingerTransforms.fingerSubs[1].Rotate(Vector3.up * Time.deltaTime * 10f);

        for (int i = 0; i < 5; i++)
        {
            handFingers.finger[i][0].transform.Rotate(Vector3.up * Time.deltaTime * 10f);
        }
    }
}


