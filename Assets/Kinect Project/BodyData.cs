using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyData : MonoBehaviour {

    string JointName;
    Vector3 Position;

    public BodyData(string n, Vector3 p)
    {
        JointName = n;
        Position = p;
    }
}
