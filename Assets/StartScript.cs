using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {
    static bool saw0nce = false;
	
	void Start () {
        if (!saw0nce)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            Time.timeScale = 0;
        }
        saw0nce = true;
	}
	
	
	void Update () {
        if(Time.timeScale==0 && Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            GetComponent<SpriteRenderer>().enabled = false;
        }
		
	}
}
