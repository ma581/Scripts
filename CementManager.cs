using UnityEngine;
using System.Collections;

public class CementManager : MonoBehaviour {

    Quaternion[] rotationArray = new Quaternion[2];

    public Transform CementPrefab;
    Vector3 shiftInPosition = new Vector3(0f, 0.033f, 0f);
    bool hasCement = false;
    // Use this for initialization
    void Start () {
        rotationArray[0] = Quaternion.Euler(0, 0, 0);
        rotationArray[1] = Quaternion.Euler(0, 180, 0);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.C))
            if (!hasCement)
            {
                    int randomNumber = Random.Range(0, 2);
                    Instantiate(CementPrefab, this.transform.position + shiftInPosition, rotationArray[randomNumber]);
                    hasCement = true;   
                Debug.Log(randomNumber);
            }
    }

    void OnCollisionEnter(Collision col)
    {
        if (!hasCement)
        {
            if (col.gameObject.name == "shovel")
            {
                int randomNumber = Random.Range(0, 2);
                Instantiate(CementPrefab, this.transform.position + shiftInPosition, rotationArray[randomNumber]);
                hasCement = true;
            }
        }
    }
}


