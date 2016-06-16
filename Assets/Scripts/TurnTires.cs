using UnityEngine;
using System.Collections;

public class TurnTires : MonoBehaviour {

	public float turnSpeed;
	float myRotation;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		myRotation = Input.GetAxis ("Horizontal") * Time.deltaTime * turnSpeed;
		transform.Rotate (0, myRotation, 0);
	}
}
