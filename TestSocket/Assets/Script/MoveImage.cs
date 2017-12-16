using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveImage : MonoBehaviour
{
    public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    float x = obj.transform.position.x;
	    float y = obj.transform.position.y;
	    x += 2;
	    if (x > 2000)
	        x = 0;
        obj.transform.position = new Vector3(x,y);


	}
}
