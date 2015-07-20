﻿using UnityEngine;
using System.Collections;

public enum rotationAxis {
	blue,
	red,
	green
}

public class ArrowSpin : MonoBehaviour {
	public float speed;
	public float upSpeed;
	Vector3 startPos;
	public float upCount = 0;
	public rotationAxis rotateWhichWay;

	void Start() {
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		upCount += Time.deltaTime * upSpeed;

		/*Vector3 curRotation = transform.rotation.eulerAngles;
		curRotation.y += speed;
		transform.rotation = Quaternion.Euler(curRotation);*/

		Vector3 thisWay;
		switch (rotateWhichWay) {
		case rotationAxis.blue:
			thisWay = Vector3.forward;
			break;
		case rotationAxis.red:
			thisWay = Vector3.right;
			break;
		default:
			thisWay = Vector3.down;
			break;
		}


		transform.RotateAround (transform.position, thisWay, speed);



		float upPos = Mathf.Sin(upCount);

		if (upPos < 0) {
			upPos = 0;
		}



		Vector3 curPosition = startPos;
		curPosition.y += upPos;
		transform.position = curPosition;
	}
}
