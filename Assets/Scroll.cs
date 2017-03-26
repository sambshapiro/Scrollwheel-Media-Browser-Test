using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
	public int numOfPlanes = 7;
	private GameObject[] planes;
	private int planeInSelectionSlot;
	private Vector3[] positionSlots;
	private Vector3[] rotationSlots;

	// Use this for initialization
	void Start () {
		//ignore 0th array positions
		planes = new GameObject[numOfPlanes+1];
		for (int i = 1; i < numOfPlanes+1; i++) {
			planes [i] = GameObject.Find ((i).ToString());
		}
		planeInSelectionSlot = 4;

		positionSlots = new Vector3[numOfPlanes * 2];
		rotationSlots = new Vector3[numOfPlanes * 2];
		float j = 0f;
		for (int i = numOfPlanes-1; i > 0; i--) {
			positionSlots [i] = new Vector3 (-7.8f - j, 1.12f, 13.82f);
			rotationSlots [i] = new Vector3 (90f, -166f, 90f);
			j++;
			//Debug.Log ("slot " + i + ": " + positionSlots [i]);
		}
		positionSlots [numOfPlanes] = new Vector3 (0f, 1.12f, 13.82f);
		rotationSlots [numOfPlanes] = new Vector3 (90f, -90f, 90f);
		j = 0;
		for (int i = numOfPlanes+1; i < positionSlots.Length; i++) {
			positionSlots [i] = new Vector3 (7.8f + j, 1.12f, 13.82f);
			rotationSlots [i] = new Vector3 (90, -194f, 270f);
			j++;
			//Debug.Log ("slot " + i + ": " + positionSlots [i]);
		}
	}

	public void shiftLeft() {
		if (planeInSelectionSlot != numOfPlanes) {
			int leftmostslot = numOfPlanes - planeInSelectionSlot;
			for (int i = 1; i < planes.Length; i++) {
				iTween.MoveTo (planes [i], iTween.Hash ("x", positionSlots [leftmostslot + i - 1].x, "y", positionSlots [leftmostslot + i - 1].y, "z", positionSlots [leftmostslot + i - 1].z, "time", 2f));
				iTween.RotateTo (planes [i], iTween.Hash ("x", rotationSlots [leftmostslot + i - 1].x, "y", rotationSlots [leftmostslot + i - 1].y, "z", rotationSlots [leftmostslot + i - 1].z, "time", 2f));
			}
			planeInSelectionSlot++;
		}
	}

	public void shiftRight() {
		if (planeInSelectionSlot != 1) {
			int leftmostslot = numOfPlanes - planeInSelectionSlot;
			for (int i = 1; i < planes.Length; i++) {
				iTween.MoveTo (planes [i], iTween.Hash ("x", positionSlots [leftmostslot + i + 1].x, "y", positionSlots [leftmostslot + i + 1].y, "z", positionSlots [leftmostslot + i + 1].z, "time", 2f));
				iTween.RotateTo (planes [i], iTween.Hash ("x", rotationSlots [leftmostslot + i + 1].x, "y", rotationSlots [leftmostslot + i + 1].y, "z", rotationSlots [leftmostslot + i + 1].z, "time", 2f));
			}
			planeInSelectionSlot--;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel")<0)
			shiftRight ();
		if (Input.GetAxis("Mouse ScrollWheel")>0)
			shiftLeft ();
	}
}
