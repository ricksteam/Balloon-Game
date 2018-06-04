using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitRestartControl : MonoBehaviour {

    public GameObject exit;
    public GameObject restart;
	// Use this for initialization
	void Start () {
        int level = Data.level;
        if (level <= 1)
        {
            exit.gameObject.SetActive(true);
            restart.gameObject.SetActive(false);
        }
        else
        {
            exit.gameObject.SetActive(false); 
            restart.gameObject.SetActive(true);
        }
        
	}
	 
}
