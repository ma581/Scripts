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
            //Base
            rightHand.transform.position = new Vector3(client.handCooArray[0], client.handCooArray[1], client.handCooArray[2]); //Hand centre 

            rightHand.transform.GetChild(0).position = new Vector3(client.handCooArray[57], client.handCooArray[58], client.handCooArray[59]); //Thumb base 
            rightHand.transform.GetChild(1).position = new Vector3(client.handCooArray[6], client.handCooArray[7], client.handCooArray[8]); //Pinky base
            rightHand.transform.GetChild(2).position = new Vector3(client.handCooArray[18], client.handCooArray[19], client.handCooArray[20]); //Ring base
            rightHand.transform.GetChild(3).position = new Vector3(client.handCooArray[30], client.handCooArray[31], client.handCooArray[32]); //Middle base
            rightHand.transform.GetChild(4).position = new Vector3(client.handCooArray[42], client.handCooArray[43], client.handCooArray[44]); //Index base

            //Middle
            handFingers.finger[0][0].transform.position = new Vector3(client.handCooArray[60], client.handCooArray[61], client.handCooArray[62]); //Thumb middle
            handFingers.finger[4][0].transform.position = new Vector3(client.handCooArray[9], client.handCooArray[10], client.handCooArray[11]); //Pinky middle
            handFingers.finger[3][0].transform.position = new Vector3(client.handCooArray[21], client.handCooArray[22], client.handCooArray[23]); //Ring middle
            handFingers.finger[2][0].transform.position = new Vector3(client.handCooArray[33], client.handCooArray[34], client.handCooArray[35]); //Middle middle
            handFingers.finger[1][0].transform.position = new Vector3(client.handCooArray[45], client.handCooArray[46], client.handCooArray[47]); //Index middle

            //Tips
            handFingers.finger[0][1].transform.position = new Vector3(client.handCooArray[63], client.handCooArray[64], client.handCooArray[65]); //Thumb tip
            handFingers.finger[4][1].transform.position = new Vector3(client.handCooArray[15], client.handCooArray[16], client.handCooArray[17]); //Pinky tip
            handFingers.finger[3][1].transform.position = new Vector3(client.handCooArray[27], client.handCooArray[28], client.handCooArray[29]); //Ring tip
            handFingers.finger[2][1].transform.position = new Vector3(client.handCooArray[39], client.handCooArray[40], client.handCooArray[41]); //Middle tip
            handFingers.finger[1][1].transform.position = new Vector3(client.handCooArray[51], client.handCooArray[52], client.handCooArray[53]); //Index tip

            Debug.Log("Updating finger positions");
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


