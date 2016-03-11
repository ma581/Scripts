using UnityEngine;
using System.Collections;

public class PickUpJoint : MonoBehaviour
{
    public static bool holdingTool = false;
    public GameObject HammerRegion; //Do  nothing 
    private AreaTrigger hammerAreaTrig;


    bool f = false;


    public GameObject heldHammer;
    public GameObject tableHammer;

    private float delay = 5f;
    private float dropTimerStart;
    private bool dropTimerStarted = false;
    private float pickTimerStart;
    private bool pickTimerStarted = false;


    void Start()
    {
        //heldHammer.SetActive(false);
        hammerAreaTrig = HammerRegion.GetComponent<AreaTrigger>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    f = !f;
        //    heldHammer.SetActive(f);
        //    tableHammer.SetActive(!f);
        //}

        if(!heldHammer.activeSelf && !pickTimerStarted)
        {
            startPickTimer();
            dropTimerStarted = false;
            holdingTool = false;
        }
         
        if (heldHammer.activeSelf && !dropTimerStarted)
        {
            startDropTimer();
            pickTimerStarted = false;
            holdingTool = true;
        }

        if (pickTimerStarted)
        {
            if (Time.time > pickTimerStart + delay && holdingTool==false)
            {
                pickUpAble();
            }
        }

           
        if (dropTimerStarted)
        {
            if (Time.time > dropTimerStart + delay)
            {
                dropAble();

            }
        }


        //if (!heldHammer.activeSelf)
        //{
        //    heldHammer.SetActive(hammerAreaTrig.HandInRegion);
        //    tableHammer.SetActive(!hammerAreaTrig.HandInRegion);
        //    timerStarted = false;
        //}
        //else if(heldHammer.activeSelf && !timerStarted)
        //{
        //    timerStart = Time.time;
        //    timerStarted = true;

        //}
        //else if (heldHammer.activeSelf && timerStarted)
        //{
        //    //Debug.Log("timerStart = " + timerStart);
        //    //Debug.Log("time = " + Time.time);

        //    //StartCoroutine(Example());
        //    if (Time.time > timerStart + delay)
        //    {
        //        Debug.Log("hand in hammer region = " + hammerAreaTrig.HandInRegion);
        //        heldHammer.SetActive(!hammerAreaTrig.HandInRegion);
        //        tableHammer.SetActive(hammerAreaTrig.HandInRegion);
        //    }

        //}






    }


    void pickUpAble()
    {
        heldHammer.SetActive(hammerAreaTrig.HandInRegion);
        tableHammer.SetActive(!hammerAreaTrig.HandInRegion);

    }

    void dropAble()
    {
        heldHammer.SetActive(!hammerAreaTrig.HandInRegion);
        tableHammer.SetActive(hammerAreaTrig.HandInRegion);
    }

    void startDropTimer()
    {
        dropTimerStart = Time.time;
        dropTimerStarted = true;
    }

    void startPickTimer()
    {
        pickTimerStart = Time.time;
        pickTimerStarted = true;
    }


}