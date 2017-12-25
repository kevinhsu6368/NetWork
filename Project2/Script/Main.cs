using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public GameObject panel_login;
    public GameObject panel_registed;

    public GameObject background1;
    public GameObject background2;
    public GameObject background3;

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

        background1.SetActive(true);
        background2.SetActive(false);

    }

    public void ShowRegisted()
    {
        if (panel_login != null)
            panel_login.SetActive(false);

        if (panel_registed != null)
            panel_registed.SetActive(true);

        background1.SetActive(false);
        background2.SetActive(true);
    }


}
