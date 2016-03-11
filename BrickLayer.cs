using UnityEngine;
using System.Collections;

public class BrickLayer : MonoBehaviour {

    public static int numOfBricks = 6;
    public GameObject[] BricksParent = new GameObject[numOfBricks];
    public GameObject[] Bricks = new GameObject[numOfBricks];
    private AreaTrigger[] bricksTrigger = new AreaTrigger[numOfBricks];
    private bool[] bricksLayed = new bool[numOfBricks];

    public GameObject HandBrick;
    private AreaTrigger handBrick;

    public GameObject TableBrickParent;
    public GameObject TableBrick;
    private AreaTrigger tableBrickTrigger;
    public bool test;

    bool f = false;


    private bool holdingBrick;

    // Use this for initialization
    void Start () {
        //Assigning in AreaTriggers
        for (int k = 0; k < numOfBricks; k++)
        {
            bricksTrigger[k] = BricksParent[k].GetComponent<AreaTrigger>();
        }
        tableBrickTrigger = TableBrickParent.GetComponent<AreaTrigger>();




    }

    // Update is called once per frame
    void Update () {

        //Holding or not holding brick
        if (HandBrick.activeSelf)
        {
            holdingBrick = true;
            PickUpJoint.holdingTool = true;
        }
        else
        {
            holdingBrick = false;
        }

        //Picking up brick from table
        if (!holdingBrick)
        {
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    f = !f;
            //    HandBrick.SetActive(f);
            //    TableBrick.SetActive(!f);
            //}

            if (PickUpJoint.holdingTool == false)
            {
                HandBrick.SetActive(tableBrickTrigger.HandInRegion);
                TableBrick.SetActive(!tableBrickTrigger.HandInRegion);
                BrickOnTopOfCement.brickLayed = false;
            }



        }
        

        //Dropping brick in place
        if (holdingBrick)
        {
           
            for (int k = 0; k < numOfBricks; k++)
            {
                if (bricksLayed[k] == false && bricksTrigger[k].HandInRegion)
                {
                    Bricks[k].SetActive(bricksTrigger[k].HandInRegion);
                    HandBrick.SetActive(!bricksTrigger[k].HandInRegion);
                    TableBrick.SetActive(bricksTrigger[k].HandInRegion);
                    bricksLayed[k] = bricksTrigger[k].HandInRegion; //Update brick permanently layed
                }
                else
                {
                    PickUpJoint.holdingTool = false;
                }

                if(BrickOnTopOfCement.brickLayed == true)
                {
                    HandBrick.SetActive(false);
                    TableBrick.SetActive(true);
                }
            }
            
        }


    }
}
