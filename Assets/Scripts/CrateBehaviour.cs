using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour {

	public GameObject bottleSlotPrefab;

	private GameObject[,] bottles;
	private bool[,] used;
	private bool placed = false;
	int counter = 0;

	// Use this for initialization
	void Start () {
		Debug.Log("start");
		//InvokeRepeating("ShowRandomBottle", 0.0f, 2.0f);
		used = new bool[5,4];
		bottles = new GameObject[5, 4];
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 4; j++) {
				GameObject bottle = Instantiate (bottleSlotPrefab, this.transform);
				bottle.GetComponent<BottleSelect>().setCrate(this, i,j);
				bottle.transform.position = bottle.transform.parent.TransformPoint (-0.4f + 0.2f*i, 0.0f, -0.375f + 0.25f*j);
				bottles [i, j] = bottle;
				used[i,j] = false;
				Renderer rend = bottles [i, j].GetComponent<Renderer> ();
				rend.enabled = false;
			}
		}
	}
	
	public void bottleClicked(int x, int y){
		if(!used[x,y]){
			Debug.Log(x+":"+y+"  "+used[x,y]);
			used[x,y] = true;
			counter ++;
			Debug.Log("counter: "+counter);
			if(counter <19){
				ShowRandomBottle();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnSelect(){
		if(!placed){
			this.gameObject.AddComponent<Rigidbody> ();
		}
	}

	void OnCollisionEnter(){
		/*Renderer rend = GetComponent<Renderer> ();
		rend.enabled = false;*/
		Destroy(this.GetComponent<Renderer>());
		Destroy(this.GetComponent<Collider>());
		if(!placed){
			placed = true;
			//GetComponent<Collider>().enabled=false;
			ShowRandomBottle();
		}
		Destroy(this.GetComponent<Rigidbody>());
		
		
		/*
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 4; j++) {
				rend = bottles [i, j].GetComponent<Renderer> ();
				rend.enabled = true;
			}
		}*/
	}

	void ShowRandomBottle(){
		Debug.Log("choose bottle");
		if (placed) {
			Renderer rend;
			for (int i = 0; i < 5; i++) {
				for (int j = 0; j < 4; j++) {
					rend = bottles [i, j].GetComponent<Renderer> ();
					rend.enabled = false;
					bottles [i, j].GetComponent<Collider> ().enabled=false;
				}
			}
			int x;
			int y;
			Debug.Log("find bottle");
			do{
				x = Random.Range (0, 5);
				y = Random.Range (0, 4);
				Debug.Log("loop");
			}while(used[x,y]);
			Debug.Log("bottle found: "+x+":"+y);
			rend = bottles [x,y].GetComponent<Renderer> ();
			rend.enabled = true;
			bottles [x,y].GetComponent<Collider> ().enabled=true;
			Debug.Log("enabled");
		}
	}

}
