﻿using UnityEngine;
using System.Collections;

public class PartZone : MonoBehaviour {
	public BurgBuilder bb;
	new public bool enabled = true;

	// Use this for initialization
	void Start () {
		bb = transform.parent.GetComponent<BurgBuilder> ();
	}

	void OnCollisionEnter(Collision col){
		if (enabled) {
			if (col.gameObject.tag == "Food") {
				//Debug.Log (col.gameObject);
				col.gameObject.GetComponent<Food> ().isFoodPope = true;
				bb.ObtainNewPart (col.gameObject);
				enabled = false;
			}
		}
	}
}
