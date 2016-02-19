using UnityEngine;
using System.Collections;


public class HandControllerAngle : MonoBehaviour
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
            //Directions
            calculateOldDirections();
            calculateNewDirections();

            //Update directions
            //updateBaseDir();
            //updateMidDir();
            //updateTipDir();
           
            

            //Update direction
            updateBaseDir();
            updateTipDir();
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
        baseDirection.forward = (new Vector3(client.handCooArray[42], client.handCooArray[43], client.handCooArray[44]) - new Vector3(client.handCooArray[30], client.handCooArray[31], client.handCooArray[32])) * (-1);
        baseDirection.right = (new Vector3(client.handCooArray[0], client.handCooArray[1], client.handCooArray[2]) - new Vector3(client.handCooArray[3], client.handCooArray[4], client.handCooArray[5]))*(-1);
        //baseDirection.forward = new Vector3(1.1113f, 1.1220f, 275.5441f) - new Vector3(1.1878f, 1.2036f, 1.1405f);
        Debug.Log("base.forward = " + baseDirection.forward.ToString("F4"));
        //baseDirection.right = new Vector3(275.3907f, 275.3908f, 275.4292f) - new Vector3(275.4331f, 275.4365f, 275.4349f);
        Debug.Log("base.right = " + baseDirection.right.ToString("F4"));
        baseDirection.up =  Vector3.Cross(baseDirection.forward, baseDirection.right);
        Debug.Log("base.up = " + baseDirection.up.ToString("F4"));
       

        ////THUMB
        thumb.tipDirection.forward = baseDirection.forward;
        thumb.tipDirection.right = (new Vector3(client.handCooArray[63], client.handCooArray[64], client.handCooArray[65]) - new Vector3(client.handCooArray[60], client.handCooArray[61], client.handCooArray[62])) * (-1);
        //thumb.tipDirection.up = Vector3.Cross(thumb.tipDirection.forward, thumb.tipDirection.right);

        thumb.midDirection.forward = baseDirection.right;
        thumb.midDirection.right = (new Vector3(client.handCooArray[60], client.handCooArray[61], client.handCooArray[62]) - new Vector3(client.handCooArray[57], client.handCooArray[58], client.handCooArray[59])) * (-1);

        thumb.basDirection.forward = baseDirection.right;
        thumb.basDirection.right = (new Vector3(client.handCooArray[57], client.handCooArray[58], client.handCooArray[59]) - new Vector3(client.handCooArray[54], client.handCooArray[55], client.handCooArray[56])) * (-1);


        ////Index
        index.tipDirection.forward = baseDirection.forward;
        index.tipDirection.right = (new Vector3(client.handCooArray[51], client.handCooArray[52], client.handCooArray[53]) - new Vector3(client.handCooArray[48], client.handCooArray[49], client.handCooArray[50])) * (-1);
        index.tipDirection.up = Vector3.Cross(index.tipDirection.forward, index.tipDirection.right);

        //index.midDirection.forward = baseDirection.forward;
        //index.midDirection.right = (new Vector3(client.handCooArray[60], client.handCooArray[61], client.handCooArray[62]) - new Vector3(client.handCooArray[57], client.handCooArray[58], client.handCooArray[59])) * (-1);
        ////index.midDirection.up = Vector3.Cross(middle.basDirection.forward, middle.basDirection.right);

        index.basDirection.forward = baseDirection.forward;
        index.basDirection.right = (new Vector3(client.handCooArray[45], client.handCooArray[46], client.handCooArray[47]) - new Vector3(client.handCooArray[42], client.handCooArray[43], client.handCooArray[44])) * (-1);
        index.basDirection.up = Vector3.Cross(index.basDirection.forward, index.basDirection.right);


        ////Middle
        middle.tipDirection.forward = baseDirection.forward;
        middle.tipDirection.right = (new Vector3(client.handCooArray[39], client.handCooArray[40], client.handCooArray[41]) - new Vector3(client.handCooArray[36], client.handCooArray[37], client.handCooArray[38])) * (-1);
        middle.tipDirection.up = Vector3.Cross(middle.tipDirection.forward, middle.tipDirection.right);

        //middle.midDirection.forward = baseDirection.forward;
        //middle.midDirection.right = (new Vector3(client.handCooArray[60], client.handCooArray[61], client.handCooArray[62]) - new Vector3(client.handCooArray[57], client.handCooArray[58], client.handCooArray[59])) * (-1);
        //middle.midDirection.up = Vector3.Cross(middle.basDirection.forward, middle.basDirection.right);

        middle.basDirection.forward = baseDirection.forward;
        middle.basDirection.right = (new Vector3(client.handCooArray[33], client.handCooArray[34], client.handCooArray[35]) - new Vector3(client.handCooArray[30], client.handCooArray[31], client.handCooArray[32])) * (-1);
        middle.basDirection.up = Vector3.Cross(middle.basDirection.forward, middle.basDirection.right);

        Debug.DrawRay(rightHand.transform.GetChild(1).transform.position, index.basDirection.forward, Color.white);
        Debug.DrawRay(rightHand.transform.GetChild(1).transform.position, index.basDirection.right, Color.red);
        Debug.DrawRay(rightHand.transform.GetChild(1).transform.position, index.basDirection.up, Color.blue);

        ////Ring
        ring.tipDirection.forward = baseDirection.forward;
        ring.tipDirection.right = (new Vector3(client.handCooArray[27], client.handCooArray[28], client.handCooArray[29]) - new Vector3(client.handCooArray[24], client.handCooArray[25], client.handCooArray[26])) * (-1);
        ring.tipDirection.up = Vector3.Cross(ring.basDirection.forward, ring.basDirection.right);

        //ring.midDirection.forward = baseDirection.forward;
        //ring.midDirection.right = (new Vector3(client.handCooArray[60], client.handCooArray[61], client.handCooArray[62]) - new Vector3(client.handCooArray[57], client.handCooArray[58], client.handCooArray[59])) * (-1);
        //ring.tipDirection.up = Vector3.Cross(ring.basDirection.forward, ring.basDirection.right);

        ring.basDirection.forward = baseDirection.forward;
        ring.basDirection.right = (new Vector3(client.handCooArray[21], client.handCooArray[22], client.handCooArray[23]) - new Vector3(client.handCooArray[18], client.handCooArray[19], client.handCooArray[20])) * (-1);
        ring.basDirection.up = Vector3.Cross(ring.basDirection.forward, ring.basDirection.right);

        ////Pinky
        pinky.tipDirection.forward = baseDirection.forward;
        pinky.tipDirection.right = (new Vector3(client.handCooArray[15], client.handCooArray[16], client.handCooArray[17]) - new Vector3(client.handCooArray[12], client.handCooArray[13], client.handCooArray[14])) * (-1);
        pinky.tipDirection.up = Vector3.Cross(pinky.basDirection.forward, pinky.basDirection.right);

        //pinky.midDirection.forward = baseDirection.forward;
        //pinky.midDirection.right = (new Vector3(client.handCooArray[60], client.handCooArray[61], client.handCooArray[62]) - new Vector3(client.handCooArray[57], client.handCooArray[58], client.handCooArray[59])) * (-1);
        //ring.tipDirection.up = Vector3.Cross(ring.basDirection.forward, ring.basDirection.right);

        pinky.basDirection.forward = baseDirection.forward;
        pinky.basDirection.right = (new Vector3(client.handCooArray[9], client.handCooArray[10], client.handCooArray[11]) - new Vector3(client.handCooArray[6], client.handCooArray[7], client.handCooArray[8])) * (-1);
        pinky.basDirection.up = Vector3.Cross(pinky.basDirection.forward, pinky.basDirection.right);

    }

    void calculateTransDirections()
    {
        //        % M =
        //%
        //% -3.4999 - 3.7718 - 0.0055
        //% 10.3147   11.1472    0.0050
        //% 0.9948 - 0.3978    0.0002
    }

    void updateBaseDir()
    {

        //Base
        rightHand.transform.rotation =  Quaternion.LookRotation(baseDirection.forward, -1*baseDirection.up);
        //Thumb
        rightHand.transform.GetChild(0).rotation = Quaternion.LookRotation(thumb.basDirection.forward, -1 * thumb.basDirection.up); //base
        //Index
        rightHand.transform.GetChild(1).rotation = Quaternion.LookRotation(index.basDirection.forward, -1 * index.basDirection.up); //base
        //Middle
        rightHand.transform.GetChild(2).rotation = Quaternion.LookRotation(middle.basDirection.forward, -1 * middle.basDirection.up); //base
        //Ring
        rightHand.transform.GetChild(3).rotation = Quaternion.LookRotation(ring.basDirection.forward, -1 * ring.basDirection.up); //base
        //Pinky
        rightHand.transform.GetChild(4).rotation = Quaternion.LookRotation(pinky.basDirection.forward, -1 * pinky.basDirection.up); //base


    }

    void updateTipDir()
    {
        //Thumb
        handFingers.finger[0][1].transform.rotation = Quaternion.LookRotation(thumb.tipDirection.forward, -1 * thumb.tipDirection.up);
        //Index
        handFingers.finger[1][1].transform.rotation = Quaternion.LookRotation(index.tipDirection.forward, -1 * index.tipDirection.up);
        //Middle
        handFingers.finger[2][1].transform.rotation = Quaternion.LookRotation(middle.tipDirection.forward, -1 * middle.tipDirection.up);
        //Ring
        handFingers.finger[3][1].transform.rotation = Quaternion.LookRotation(ring.tipDirection.forward, -1 * ring.tipDirection.up);
        //Pinky
        handFingers.finger[4][1].transform.rotation = Quaternion.LookRotation(pinky.tipDirection.forward, -1 * pinky.tipDirection.up);

    }

    void updateMidDir()
    {
        //Thumb
        handFingers.finger[0][0].transform.rotation = Quaternion.LookRotation(thumb.midDirection.forward, -1 * thumb.midDirection.up);
        //Index
        handFingers.finger[1][0].transform.rotation = Quaternion.LookRotation(index.midDirection.forward, -1 * index.midDirection.up);
        //Middle
        handFingers.finger[2][0].transform.rotation = Quaternion.LookRotation(middle.midDirection.forward, -1 * middle.midDirection.up);
        //Ring
        handFingers.finger[3][0].transform.rotation = Quaternion.LookRotation(ring.midDirection.forward, -1 * ring.midDirection.up);
        //Pinky
        handFingers.finger[4][0].transform.rotation = Quaternion.LookRotation(pinky.midDirection.forward, -1 * pinky.midDirection.up);

    }
}


