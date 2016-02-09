using UnityEngine;
using System.Collections;

public class HandController1 : MonoBehaviour
{
    public GameObject rightHand; //Do  nothing 
    private FingerManager handFingers; // Need to attach the gameObject with the FingerManager script component 

    public GameObject Pipe;
    private Client client;

    public GameObject mid, root, thumbs, indexs, pinkys, rings, middles; 

    private struct fingDirection
    {
        public Vector3 tipDirection;
        public Vector3 midDirection;
        public Vector3 basDirection;
    }
    fingDirection thumb, index, middle, ring, pinky; //to store relative directions of fingers
    Vector3 baseDirection;
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
            //Update positions
            updateBasePos();
            //updateMidPos();
            //updateTipPos();
           
            //Directions
            calculateDirections();

            //Update direction
            updateDirections();
        }

        //for (int i = 0; i < 5; i++)
        //{
        //    handFingers.finger[i][0].transform.Rotate(Vector3.up * Time.deltaTime * 10f);
        //}

      
    }

    void updateBasePos()
    {
        //Base
        rightHand.transform.position = new Vector3(client.handCooArray[0], client.handCooArray[1], client.handCooArray[2]); //Hand centre 

        //rightHand.transform.GetChild(0).position = new Vector3(client.handCooArray[57], client.handCooArray[58], client.handCooArray[59]); //Thumb base 
        //rightHand.transform.GetChild(1).position = new Vector3(client.handCooArray[6], client.handCooArray[7], client.handCooArray[8]); //Pinky base
        //rightHand.transform.GetChild(2).position = new Vector3(client.handCooArray[18], client.handCooArray[19], client.handCooArray[20]); //Ring base
        //rightHand.transform.GetChild(3).position = new Vector3(client.handCooArray[30], client.handCooArray[31], client.handCooArray[32]); //Middle base
        //rightHand.transform.GetChild(4).position = new Vector3(client.handCooArray[42], client.handCooArray[43], client.handCooArray[44]); //Index base

        root.transform.position = new Vector3(client.handCooArray[3], client.handCooArray[4], client.handCooArray[5]); //Hand centre 
        mid.transform.position = new Vector3(client.handCooArray[0], client.handCooArray[1], client.handCooArray[2]); //Hand centre 
        thumbs.transform.position = new Vector3(client.handCooArray[63], client.handCooArray[64], client.handCooArray[65]); //Hand centre 
        indexs.transform.position = new Vector3(client.handCooArray[51], client.handCooArray[52], client.handCooArray[53]); //Hand centre 
        middles.transform.position = new Vector3(client.handCooArray[39], client.handCooArray[40], client.handCooArray[41]); //Hand centre 
        pinkys.transform.position = new Vector3(client.handCooArray[15], client.handCooArray[16], client.handCooArray[17]); //Hand centre 
        rings.transform.position = new Vector3(client.handCooArray[27], client.handCooArray[28], client.handCooArray[29]); //Hand centre 
    }

   void updateMidPos()
    {
        //Middle
        handFingers.finger[0][0].transform.position = new Vector3(client.handCooArray[60], client.handCooArray[61], client.handCooArray[62]); //Thumb middle
        handFingers.finger[4][0].transform.position = new Vector3(client.handCooArray[9], client.handCooArray[10], client.handCooArray[11]); //Pinky middle
        handFingers.finger[3][0].transform.position = new Vector3(client.handCooArray[21], client.handCooArray[22], client.handCooArray[23]); //Ring middle
        handFingers.finger[2][0].transform.position = new Vector3(client.handCooArray[33], client.handCooArray[34], client.handCooArray[35]); //Middle middle
        handFingers.finger[1][0].transform.position = new Vector3(client.handCooArray[45], client.handCooArray[46], client.handCooArray[47]); //Index middle
    }

    void updateTipPos()
    {
        //Tips
        handFingers.finger[0][1].transform.position = new Vector3(client.handCooArray[63], client.handCooArray[64], client.handCooArray[65]); //Thumb tip
        handFingers.finger[4][1].transform.position = new Vector3(client.handCooArray[15], client.handCooArray[16], client.handCooArray[17]); //Pinky tip
        handFingers.finger[3][1].transform.position = new Vector3(client.handCooArray[27], client.handCooArray[28], client.handCooArray[29]); //Ring tip
        handFingers.finger[2][1].transform.position = new Vector3(client.handCooArray[39], client.handCooArray[40], client.handCooArray[41]); //Middle tip
        handFingers.finger[1][1].transform.position = new Vector3(client.handCooArray[51], client.handCooArray[52], client.handCooArray[53]); //Index tip
    }

    void calculateDirections()
    {
        //baseDirection = (new Vector3(client.handCooArray[0], client.handCooArray[1], client.handCooArray[2]) - new Vector3(client.handCooArray[3], client.handCooArray[4], client.handCooArray[5]))- rightHand.transform.forward;
        baseDirection = new Vector3(client.handCooArray[42], client.handCooArray[43], client.handCooArray[44]) - new Vector3(client.handCooArray[30], client.handCooArray[31], client.handCooArray[32]);

        //thumb.tipDirection = handFingers.finger[0][1].transform.position - handFingers.finger[0][0].transform.position;
        //Debug.Log("Thumb tip direction = " + thumb.tipDirection);
        //thumb.midDirection = handFingers.finger[0][0].transform.position - rightHand.transform.GetChild(0).position;
        //thumb.basDirection = thumb.midDirection;

        //index.tipDirection = handFingers.finger[1][1].transform.position - handFingers.finger[1][0].transform.position;
        //index.midDirection = handFingers.finger[1][0].transform.position - rightHand.transform.GetChild(1).position;
        //index.basDirection = index.midDirection;

        //middle.tipDirection = handFingers.finger[2][1].transform.position - handFingers.finger[2][0].transform.position;
        //middle.midDirection = handFingers.finger[2][0].transform.position - rightHand.transform.GetChild(2).position;
        //middle.basDirection = middle.midDirection;

        //ring.tipDirection = handFingers.finger[3][1].transform.position - handFingers.finger[3][0].transform.position;
        //ring.midDirection = handFingers.finger[3][0].transform.position - rightHand.transform.GetChild(3).position;
        //ring.basDirection = ring.midDirection;

        //pinky.tipDirection = handFingers.finger[4][1].transform.position - handFingers.finger[4][0].transform.position;
        //pinky.midDirection = handFingers.finger[4][0].transform.position - rightHand.transform.GetChild(4).position;
        //pinky.basDirection = pinky.midDirection;
    }

    void updateDirections()
    {

        //Vector3 TargetLocation = Person2.transform.position - this.transform.position;

        //Quaternion TargetRotation = Quaternion.FromToRotation(transform.forward, TargetLocation);

        //this.transform.rotation = TargetRotation;

        //Base
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            rightHand.transform.rotation = rightHand.transform.rotation* Quaternion.FromToRotation(rightHand.transform.forward, baseDirection);

        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            //rightHand.transform.rotation = Quaternion.FromToRotation()
            //rightHand.transform.LookAt(baseDirection);

            rightHand.transform.rotation = Quaternion.FromToRotation(rightHand.transform.forward, baseDirection);

            
        }
        //rightHand.transform.rotation = Quaternion.LookRotation(Vector3.up);

        // rightHand.transform.Rotate(Vector3.up * Time.deltaTime * 10f);

        ////Thumb

        //Debug.Log("Original rotation = " + handFingers.finger[0][1].transform.rotation);
        //handFingers.finger[0][1].transform.rotation = Quaternion.FromToRotation(handFingers.finger[0][1].transform.position, thumb.tipDirection); //tip
        //Debug.Log("New rotation = " + handFingers.finger[0][1].transform.rotation);
        //handFingers.finger[0][0].transform.rotation = Quaternion.FromToRotation(handFingers.finger[0][0].transform.position, thumb.midDirection); //mid
        //rightHand.transform.GetChild(0).rotation = Quaternion.FromToRotation(rightHand.transform.GetChild(0).position, thumb.basDirection); //base

        ////Index
        //handFingers.finger[1][1].transform.rotation = Quaternion.FromToRotation(handFingers.finger[1][1].transform.position, index.tipDirection); //tip
        //handFingers.finger[1][0].transform.rotation = Quaternion.FromToRotation(handFingers.finger[1][0].transform.position, index.midDirection); //mid
        //rightHand.transform.GetChild(1).rotation = Quaternion.FromToRotation(rightHand.transform.GetChild(1).position, index.basDirection); //base


    }
}


