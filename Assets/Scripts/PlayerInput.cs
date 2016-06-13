using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	KeyCode playerAccelerateKey;
	KeyCode playerDeccerelateKey;
	Rigidbody rigidbody;

	float myRotation;
	public float turnSpeed;
	public float torque;
	public float torqueDeccerelationMultiplier;
	public float minimumSpeedForTurning;

	// Use this for initialization
	void Start () {
		playerAccelerateKey = KeyCode.W;
		playerDeccerelateKey = KeyCode.S;
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetPlayerInput ();
	}

	void GetPlayerInput () {
		if (Input.GetKey (playerAccelerateKey)) {
			rigidbody.AddRelativeForce(new Vector3(torque, 0, 0));
		} else if (Input.GetKey (playerDeccerelateKey)) {
			rigidbody.AddRelativeForce(new Vector3(-torque * torqueDeccerelationMultiplier, 0, 0));
		}
			
		if (Mathf.Abs (transform.InverseTransformDirection (rigidbody.velocity).x) > minimumSpeedForTurning || Mathf.Abs (transform.InverseTransformDirection (rigidbody.velocity).z) > minimumSpeedForTurning) {
			myRotation = Input.GetAxis ("Horizontal") * Time.deltaTime * turnSpeed;
		} else {
			print ("YAMAN");
			myRotation = Input.GetAxis ("Horizontal") * Time.deltaTime * turnSpeed * (Mathf.Abs (transform.InverseTransformDirection (rigidbody.velocity).x));
		}

		transform.Rotate (0, myRotation, 0);


	}
}
