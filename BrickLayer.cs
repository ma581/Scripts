using UnityEngine;
using System.Collections;

public class BrickLayer : MonoBehaviour {

    static int numOfBricks = 1;
    public GameObject[] BricksParent = new GameObject[numOfBricks];
    public GameObject[] Bricks = new GameObject[numOfBricks];
    private AreaTrigger[] bricksTrigger = new AreaTrigger[numOfBricks];

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

            
            HandBrick.SetActive(tableBrickTrigger.HandInRegion);
            TableBrick.SetActive(!tableBrickTrigger.HandInRegion);

           
            
        }

        //Dropping brick in place
        if (holdingBrick)
        {
           
            for (int k = 0; k < numOfBricks; k++)
            {
                Bricks[k].SetActive(bricksTrigger[k].HandInRegion);
                HandBrick.SetActive(!bricksTrigger[k].HandInRegion);
                TableBrick.SetActive(bricksTrigger[k].HandInRegion);
            }
            
        }


    }
}
