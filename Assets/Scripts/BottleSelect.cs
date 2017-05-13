using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSelect : MonoBehaviour {

	CrateBehaviour parent;
	int x =0;
	int y = 0;
	
	public void setCrate(CrateBehaviour crate,int  x,int y){
		parent = crate;
		Debug.Log("create box select"+x+":"+y);
		this.x = x;
		this.y = y;
		Debug.Log("created box select"+x+":"+y);
	}
	
	void OnSelect()
    {
		Debug.Log("on select triggered");
		Debug.Log(x+":"+y);
		parent.bottleClicked(x,y);
    }
}


