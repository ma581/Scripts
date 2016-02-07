using UnityEngine;
using System.Collections;

public class HandController1 : MonoBehaviour
{
    public GameObject rightHand; //Do  nothing 
    private FingerManager handFingers; // Need to attach the gameObject with the FingerManager script component 

    public GameObject Pipe;
    private Client client; 


    //    % matrix_A =
    //% 
    //%     0.0013   -0.0009   -0.0000  270.4534
    //%    -0.0006   -0.0004    0.0000    1.2637
    //%    -0.0023   -0.0030    0.0000  285.0540
    //%     0         0         0       1
    // Transformation matrix

    void Start()
{
        handFingers = rightHand.GetComponent<FingerManager>();
        client = Pipe.GetComponent<Client>();
    }

    // Update is called once per frame
    void Update()
    {

        if (client.HandTracking)
        {
            
            handFingers.finger[0][1].transform.position = new Vector3(client.handCooArray[63], client.handCooArray[64], client.handCooArray[65]);
        }

        //for (int i = 0; i < 5; i++)
        //{
        //    handFingers.finger[i][0].transform.Rotate(Vector3.up * Time.deltaTime * 10f);
        //}



        //if (client.HandTracking)
        //{
        //    Debug.Log("HandCOArray = " + client.handCooArray[1]);
        //    Debug.Log(client.handCooArray.Length);
        //}
    }

   
}


