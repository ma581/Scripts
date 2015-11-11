using UnityEngine;
using System.Collections;

[AddComponentMenu("MK/Object/MKSelectable2")] //Adds Component Menu 

public class MKSelectable2 : MonoBehaviour {
    bool touched = false; //To see if the object was initially touched
    //for highlights
    [Tooltip("This material will be temporarily blended with this object's original material when the object is highlighted by a Wand.")]
    public Material highlightMaterial;
    [Tooltip("This material will be temporarily blended with this object's original material when the object is selected by a Wand.")]
    public Material selectionMaterial;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


    void OnCollisionEnter(Collision col)
    {
        Debug.Log(this.name + "Collided with " + col.gameObject.tag);

        if (col.gameObject.tag != "Player")
        {
            Debug.Log(this.name + " is no longer in contact with Player");
            touched = false;
            Debug.Log("Touched is now false");

            //if (highlightMaterial != null) {                 
            //    //OnSelectionHighlightEnd(); //Removes highlight
            //}

            if (touched == true)
            {
                //OnSelectionHighlightEnd(); //Removes highlight
                touched = false;
                Debug.Log("Touched is now false");

            }


        }

        // Doesn't seem to detect RightHand
        //if (col.gameObject.tag == "RightHand")
        //{
        //    Debug.Log(this.name + "Collided with " + col.gameObject.tag);
        //    //GetComponent<Rigidbody>().isKinematic = true; // stop physics
        //    //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

        //    OnSelectionHighlight(); // Highlights material that is collided
        //}

        if (col.gameObject.tag == "Player")
        {
            Debug.Log(this.name + "Collided with " + col.gameObject.tag);
            //Doesn't work to move object with hand, but rather a general movement with the player. This is not precise enough
            //GetComponent<Rigidbody>().isKinematic = true; // stop physics
            //transform.parent = col.transform; // doesn't move yet, but will move w/what it hit

            OnSelectionHighlight(); // Highlights material that is collided
            touched = true;
            Debug.Log("Touched is now true");

        }

    }

    //void onCollisionExit(Collision col)
    //{
    //    Debug.Log("****************CollsionExit");

    //    Debug.Log("No longer in contact with" + col.gameObject.tag);
    //    if (col.gameObject.tag == "Player")

    //    { 
    //        OnSelectionHighlightEnd();
    //        touched = false;
    //        Debug.Log("Touched is now false");

    //    }//Removes highlight
    //}



    public virtual void OnSelectionHighlight()
    {

        if (highlightMaterial != null)
            AddMaterialToEverything(highlightMaterial);
    }

    public virtual void OnSelectionHighlightEnd()
    {
        if (highlightMaterial != null)
            RemoveMaterialFromEverything();
    }

    protected void AddMaterial(Material m, Renderer r)
    {
        if (m == null || r == null || r.GetType() == typeof(ParticleRenderer)
            || r.GetType() == typeof(ParticleSystemRenderer))
            return;

        Material[] newMaterials = new Material[r.materials.Length + 1];
        for (int i = 0; i < r.materials.Length; i++)
        {
            newMaterials[i] = r.materials[i];
        }

        newMaterials[newMaterials.Length - 1] = m;
        r.materials = newMaterials;
    }

    protected void RemoveMaterial(Renderer r)
    {
        if (r == null || r.GetType() == typeof(ParticleRenderer)
            || r.GetType() == typeof(ParticleSystemRenderer) || r.materials.Length == 0)
            return;

        Material[] newMaterials = new Material[r.materials.Length - 1];
        for (int i = 0; i < newMaterials.Length; i++)
        {
            newMaterials[i] = r.materials[i];
        }
        r.materials = newMaterials;
    }

    protected void AddMaterialToEverything(Material m)
    {
        AddMaterial(m, GetComponent<Renderer>());

        foreach (Renderer childRenderer in GetComponentsInChildren<Renderer>())
        {
            AddMaterial(m, childRenderer);
            //childRenderer.reflectionProbeUsage = UnityEngine.Rendering.ReflectionProbeUsage.Off;
            //childRenderer.receiveShadows = false;
        }
    }

    protected void RemoveMaterialFromEverything()
    {
        RemoveMaterial(GetComponent<Renderer>());

        foreach (Renderer childRenderer in GetComponentsInChildren<Renderer>())
        {
            RemoveMaterial(childRenderer);
        }
    }
}
