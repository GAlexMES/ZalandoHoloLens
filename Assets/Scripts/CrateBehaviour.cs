using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBehaviour : MonoBehaviour {

	public GameObject bottleSlotPrefab;

	private GameObject[,] bottles;

	// Use this for initialization
	void Start () {
		bottles = new GameObject[5, 4];
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 4; j++) {
				GameObject bottle = Instantiate (bottleSlotPrefab, this.transform);
				bottle.transform.position = bottle.transform.parent.TransformPoint (-0.4f + 0.2f*i, 0.0f, -0.375f + 0.25f*j);
				bottles [i, j] = bottle;
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnSelect(){
		this.gameObject.AddComponent<Rigidbody> ();
	}
}
