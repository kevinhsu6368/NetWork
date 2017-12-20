using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public GameObject panel_login;
    public GameObject panel_registed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowLogin()
    {
       if(panel_login!=null)
            panel_login.SetActive(true);

        if (panel_registed != null)
            panel_registed.SetActive(false);

    }

    public void ShowRegisted()
    {
        if (panel_login != null)
            panel_login.SetActive(false);

        if (panel_registed != null)
            panel_registed.SetActive(true);
    }


}
