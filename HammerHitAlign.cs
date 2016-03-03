using UnityEngine;
using System.Collections;

public class HammerHitAlign : MonoBehaviour
{
    GameObject hammer;
    bool hammerHitBrick = false;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hammerHitBrick)
        {
            UpdateRotation();
        }

        //Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward, Color.red);
        //Debug.DrawRay(gameObject.transform.position, Vector3.forward, Color.white);
        //Debug.DrawRay(gameObject.transform.position, (Vector3.forward / 200 + gameObject.transform.forward.normalized / 2), Color.blue);


    }


    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("COLLIDED");

        if (col.gameObject.name == "Hammer")
        {
            //Debug.Log(col.gameObject.name);
            hammerHitBrick = true;
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            hammer = col.gameObject;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Hammer")
        {
            hammerHitBrick = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            hammer = col.gameObject;
        }
    }

    void UpdateRotation()
    {
        //Vector3 halfWay = Vector3.forward / 2 + gameObject.transform.forward.normalized / 2;
        //Debug.DrawRay(gameObject.transform.position, halfWay, Color.blue);
        //Vector3 halfWay = Vector3.Lerp(Vector3.forward, gameObject.transform.forward, 0.5F);
        Vector3 halfWay = halfWayRotation();

        gameObject.transform.rotation = Quaternion.LookRotation(halfWay, Vector3.up);

    }

    Vector3 halfWayRotation()
    {
        Vector3 halfWay = Vector3.forward / 100 + gameObject.transform.forward.normalized / 2;
        return halfWay;
    }

}
