using UnityEngine;
using System.Collections;

public class BrickOnTopOfCement : MonoBehaviour {

    public static bool brickLayed = false;

    Quaternion[] rotationArray = new Quaternion[2];
    public Transform BrickPrefab;
    Vector3 shiftInPosition = new Vector3(0f, 0.033f, 0f);
    bool hasCement = false;
    Vector3 finalRotation;
    // Use this for initialization
    void Start()
    {
        //rotationArray[0] = Quaternion.Euler(0, 0, -10);
        //rotationArray[1] = Quaternion.Euler(0, 0, 0);
        Vector3 skew = new Vector3(0f, 0f, -10f);
        finalRotation = skew + this.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
            if (!hasCement)
            {
                int randomNumber = 0;
                Instantiate(BrickPrefab, this.transform.position + shiftInPosition, Quaternion.Euler(finalRotation));
                hasCement = true;
                Debug.Log(randomNumber);
            }
    }

    void OnCollisionEnter(Collision col)
    {
        if (PickUpJoint.holdingTool == false)
        {
            if (!hasCement)
            {
                if (col.gameObject.name == "HandBrick")
                {
                    Instantiate(BrickPrefab, this.transform.position + shiftInPosition, Quaternion.Euler(finalRotation));
                    hasCement = true;
                    brickLayed = true;
                }
            }
        }
    }
}
