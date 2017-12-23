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

  
    public Image img;
     

    public void ChangeTexture()
    {
        System.IO.FileStream fs = new System.IO.FileStream("D:\\image1.jpg", System.IO.FileMode.Open);
        byte[] data = new byte[fs.Length];

        fs.Read(data,0, (int)fs.Length);
        fs.Close();

        Texture2D t = new Texture2D(100, 100);
        t.LoadImage(data);
        img.sprite = Sprite.Create(t, new Rect(0, 0, t.width, t.height),Vector2.zero);
        
 

        

    }
}
