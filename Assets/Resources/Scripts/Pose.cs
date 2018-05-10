using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


public class Pose{

    //Pose descriptor

    //2hands
    Vector3 LHand;
    Vector3 RHand;
    Vector3 RShoulder;
    Vector3 LShoulder;
    //head
    Vector3 Head;

    public Pose(Vector3 LH, Vector3 RH, Vector3 H, Vector3 RS, Vector3 LS)
    {
        LHand = LH;
        RHand = RH;
        RShoulder = RS;
        LShoulder = LS;
        Head = H;
    }

    public override string ToString()
    {
        return LHand + " " + RHand + " " + RShoulder + " " + LShoulder + " " + Head;
    }

    string Encode()
    {
        //dummy function
        return (LHand + "|" + RHand + "|" + RShoulder + "|" + LShoulder + "|" + Head);
    }

    Pose Decode(string s)
    {
        Vector3 LHand = new Vector3();
        Vector3 RHand = new Vector3();
        Vector3 RShoulder = new Vector3();
        Vector3 LShoulder = new Vector3();
        Vector3 Head = new Vector3();

        string[] encodedPose = Regex.Split(s,"|");

        LHand = StringToVector3(encodedPose[0]);
        RHand = StringToVector3(encodedPose[1]);
        RShoulder = StringToVector3(encodedPose[2]);
        LShoulder = StringToVector3(encodedPose[3]);
        Head = StringToVector3(encodedPose[4]);

        return new Pose(LHand,RHand,RShoulder,LShoulder,Head);
    }

    private static Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }
}
