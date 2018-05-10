using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerManager : MonoBehaviour {

    public GameObject jointParent;

    public GameObject Body;

    public Renderer[] rends;

    public List<BodyData> bd;

    public bool GOFound;

	// Use this for initialization
	void Start () {
        GOFound = false;
        /*rends.Add(LHand.GetComponent<Renderer>());
        rends.Add(LShoulder.GetComponent<Renderer>());
        rends.Add(LElbow.GetComponent<Renderer>());
        rends.Add(RHand.GetComponent<Renderer>());
        rends.Add(RShoulder.GetComponent<Renderer>());
        rends.Add(RElbow.GetComponent<Renderer>());
        */
        rends = jointParent.GetComponentsInChildren<Renderer>();
    }

    public void GetBody(GameObject body)
    {
        Body = body;
    }
    private void UpdateBody()
    {
        Transform[] source = Body.GetComponentsInChildren<Transform>();
        Transform[] target = jointParent.GetComponentsInChildren<Transform>();

        //erase body data to get new data
        bd.Clear();

        foreach (Transform t in target)
        {
            foreach (Transform s in source)
            {
                if(t.name == s.name)
                {
                    t.position = s.position;
                    bd.Add(new BodyData(s.name, s.position));
                }
            }
        }
        

        ////UPDATE THIS TO WORK
        //get limb data
    }


    //TEST THIS METHOD, PRINT IT OUT SOMEHOW!!!!!111!!!oneone!!eleven!!

    public List<BodyData> getData()
    {
        return bd;
    }
	
    void ToggleRenderers(bool value)
    {
        foreach (var r in rends)
        {
            r.enabled = value;
        }
    }
	// Update is called once per frame
	void Update () {
		if(Body == null)
        {
            if(GOFound == false)
            {
                Debug.Log("Body lost/not found");
                GOFound = !GOFound;
            }
        }
        //if still null disable renderers
        if(Body == null)
        {
            Destroy(gameObject);
            return;
        }
        if(Body != null)
        {
            GOFound = true;
            ToggleRenderers(true);
            UpdateBody();
        }
	}

    
}
