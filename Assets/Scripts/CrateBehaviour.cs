using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour {

	public GameObject bottleSlotPrefab;

	private GameObject[,] bottles;
	private bool placed = false;

	// Use this for initialization
	void Start () {
		InvokeRepeating("ShowRandomBottle", 0.0f, 2.0f);
		bottles = new GameObject[5, 4];
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 4; j++) {
				GameObject bottle = Instantiate (bottleSlotPrefab, this.transform);
				bottle.transform.position = bottle.transform.parent.TransformPoint (-0.4f + 0.2f*i, 0.0f, -0.375f + 0.25f*j);
				bottles [i, j] = bottle;		
				Renderer rend = bottles [i, j].GetComponent<Renderer> ();
				rend.enabled = false;

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnSelect(){
		this.gameObject.AddComponent<Rigidbody> ();
	}

	void OnCollisionEnter(){
		Renderer rend = GetComponent<Renderer> ();
		rend.enabled = false;
		placed = true;
		/*
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 4; j++) {
				rend = bottles [i, j].GetComponent<Renderer> ();
				rend.enabled = true;
			}
		}*/
	}

	void ShowRandomBottle(){
		if (placed) {
			Renderer rend;
			for (int i = 0; i < 5; i++) {
				for (int j = 0; j < 4; j++) {
					rend = bottles [i, j].GetComponent<Renderer> ();
					rend.enabled = false;
				}
			}
			rend = bottles [Random.Range (0, 5), Random.Range (0, 4)].GetComponent<Renderer> ();
			rend.enabled = true;
		}
	}

}
