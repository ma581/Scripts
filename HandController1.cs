using UnityEngine;
using System.Collections;


public class HandController1 : MonoBehaviour
{
    public GameObject rightHand; //Do  nothing 
    private FingerManager handFingers; // Need to attach the gameObject with the FingerManager script component 

    public GameObject Pipe;
    private Client client;

    public GameObject mid, root, thumbs, indexs, pinkys, rings, middles; //To control cubes to finger poses

    private struct fingDirection
    {
        public Directions tipDirection;
        public Directions midDirection;
        public Directions basDirection;
    }
    fingDirection thumb, index, middle, ring, pinky; //to store relative directions of fingers
    fingDirection thumbOld, indexOld, middleOld, ringOld, pinkyOld;
    private struct Directions
    {       
        public Vector3 up;
        public Vector3 forward;
        public Vector3 right;
    }
    Directions baseDirection, baseOldDirecion;

    public bool updatefinger;
    
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
            updateMidPos();
            updateTipPos();
           
            //Directions
            calculateOldDirections();
            calculateNewDirections();

            //Update direction
            updateDirections();
        }

       

      
    }

    void updateBasePos()
    {
        //HAND BASE
        rightHand.transform.position = new Vector3(client.handCooArray[3], client.handCooArray[4]-0.03f, client.handCooArray[5]); //Hand centre 
        //rightHand.transform.position = new Vector3(275.3907f, 1.1321f, 275.5441f);

        //FINGER BASES
        //rightHand.transform.GetChild(0).position = new Vector3(client.handCooArray[57], client.handCooArray[58], client.handCooArray[59]); //Thumb base 
        //rightHand.transform.GetChild(1).position = new Vector3(client.handCooArray[6], client.handCooArray[7], client.handCooArray[8]); //Pinky base
        //rightHand.transform.GetChild(2).position = new Vector3(client.handCooArray[18], client.handCooArray[19], client.handCooArray[20]); //Ring base
        //rightHand.transform.GetChild(3).position = new Vector3(client.handCooArray[30], client.handCooArray[31], client.handCooArray[32]); //Middle base
        //rightHand.transform.GetChild(4).position = new Vector3(client.handCooArray[42], client.handCooArray[43], client.handCooArray[44]); //Index base


        //FINGER CUBES
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

    void calculateOldDirections()

    {

        //BASE
        baseOldDirecion.forward = rightHand.transform.forward;
        Debug.Log("baseOld.forward = " + baseOldDirecion.forward.ToString("F4"));
        baseOldDirecion.right = rightHand.transform.right;
        Debug.Log("baseOld.right = " + baseOldDirecion.right.ToString("F4"));
        Debug.Log("baseOld.up = " + rightHand.transform.up.ToString("F4"));
        ////THUMB
        //thumbOld.tipDirection.forward = handFingers.finger[0][1].transform.forward;
        //thumbOld.tipDirection.right = handFingers.finger[0][1].transform.right;
        //thumbOld.midDirection.forward = handFingers.finger[0][0].transform.forward;
        //thumbOld.midDirection.right = handFingers.finger[0][0].transform.right;
        //thumbOld.basDirection.forward = rightHand.transform.GetChild(0).transform.forward;
        //thumbOld.basDirection.right = rightHand.transform.GetChild(0).transform.right;

        ////INDEX
        //indexOld.tipDirection.forward = handFingers.finger[1][1].transform.forward;
        //indexOld.tipDirection.right = handFingers.finger[1][1].transform.right;
        //indexOld.midDirection.forward = handFingers.finger[1][0].transform.forward;
        //indexOld.midDirection.right = handFingers.finger[1][0].transform.right;
        //indexOld.basDirection.forward = rightHand.transform.GetChild(1).transform.forward;
        //indexOld.basDirection.right = rightHand.transform.GetChild(1).transform.right;

        ////MIDDLE
        //middleOld.tipDirection.forward = handFingers.finger[2][1].transform.forward;
        //middleOld.tipDirection.right = handFingers.finger[2][1].transform.right;
        //middleOld.midDirection.forward = handFingers.finger[2][0].transform.forward;
        //middleOld.midDirection.right = handFingers.finger[2][0].transform.right;
        //middleOld.basDirection.forward = rightHand.transform.GetChild(2).transform.forward;
        //middleOld.basDirection.right = rightHand.transform.GetChild(2).transform.right;

        ////RING
        //ringOld.tipDirection.forward = handFingers.finger[3][1].transform.forward;
        //ringOld.tipDirection.right = handFingers.finger[3][1].transform.right;
        //ringOld.midDirection.forward = handFingers.finger[3][0].transform.forward;
        //ringOld.midDirection.right = handFingers.finger[3][0].transform.right;
        //ringOld.basDirection.forward = rightHand.transform.GetChild(3).transform.forward;
        //ringOld.basDirection.right = rightHand.transform.GetChild(3).transform.right;

        ////PINKY
        //pinkyOld.tipDirection.forward = handFingers.finger[4][1].transform.forward;
        //pinkyOld.tipDirection.right = handFingers.finger[4][1].transform.right;
        //pinkyOld.midDirection.forward = handFingers.finger[4][0].transform.forward;
        //pinkyOld.midDirection.right = handFingers.finger[4][0].transform.right;
        //pinkyOld.basDirection.forward = rightHand.transform.GetChild(4).transform.forward;
        //pinkyOld.basDirection.right = rightHand.transform.GetChild(4).transform.right;

    }

    void calculateNewDirections()
    {
        //BASE
        baseDirection.forward = new Vector3(client.handCooArray[42], client.handCooArray[43], client.handCooArray[44]) - new Vector3(client.handCooArray[30], client.handCooArray[31], client.handCooArray[32]);
        baseDirection.right = new Vector3(client.handCooArray[0], client.handCooArray[1], client.handCooArray[2]) - new Vector3(client.handCooArray[3], client.handCooArray[4], client.handCooArray[5]);
        //baseDirection.forward = new Vector3(1.1113f, 1.1220f, 275.5441f) - new Vector3(1.1878f, 1.2036f, 1.1405f);
        Debug.Log("base.forward = " + baseDirection.forward.ToString("F4"));
        //baseDirection.right = new Vector3(275.3907f, 275.3908f, 275.4292f) - new Vector3(275.4331f, 275.4365f, 275.4349f);
        Debug.Log("base.right = " + baseDirection.right.ToString("F4"));
        baseDirection.up =  Vector3.Cross(baseDirection.forward, baseDirection.right).normalized;
        Debug.Log("base.up = " + baseDirection.up.ToString("F4"));

        ////THUMB
        //thumb.tipDirection.right = baseDirection.right;
        //thumb.tipDirection.forward = new Vector3(client.handCooArray[63], client.handCooArray[64], client.handCooArray[65]) - new Vector3(client.handCooArray[60], client.handCooArray[61], client.handCooArray[62]);
        //thumb.midDirection.right = baseDirection.right;
        //thumb.midDirection.forward = new Vector3(client.handCooArray[60], client.handCooArray[61], client.handCooArray[62]) - new Vector3(client.handCooArray[57], client.handCooArray[58], client.handCooArray[59]);
        //thumb.basDirection.right = baseDirection.right;
        //thumb.basDirection.forward = new Vector3(client.handCooArray[57], client.handCooArray[58], client.handCooArray[59]) - new Vector3(client.handCooArray[54], client.handCooArray[55], client.handCooArray[56]);



    }

    void calculateTransDirections()
    {
        //        % M =
        //%
        //% -3.4999 - 3.7718 - 0.0055
        //% 10.3147   11.1472    0.0050
        //% 0.9948 - 0.3978    0.0002
    }

    void updateDirections()
    {



        //Base
        //if (Input.GetKeyUp(KeyCode.Alpha3))
        //{
            //rightHand.transform.rotation = rightHand.transform.rotation* Quaternion.FromToRotation(rightHand.transform.forward, -1*baseDirection.z);
            //rightHand.transform.right = -1*baseDirection.y;
            Debug.Log("Fixing rotation");
            //rightHand.transform.rotation = Quaternion.FromToRotation(rightHand.transform.forward, -1 * baseDirection.y);
            rightHand.transform.rotation =  Quaternion.LookRotation(baseDirection.forward, -1*baseDirection.up);
        //}

        if (Input.GetKey(KeyCode.Alpha4))
        {
            //rightHand.transform.forward =  baseDirection.z;
            //rightHand.transform.rotation = Quaternion.FromToRotation()
            //rightHand.transform.LookAt(baseDirection);



        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            //rightHand.transform.up = baseDirection.x;
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


