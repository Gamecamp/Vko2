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
			Debug.Log ("Accelerating");
		} else if (Input.GetKey (playerDeccerelateKey)) {
			rigidbody.AddRelativeForce(new Vector3(-torque * torqueDeccerelationMultiplier, 0, 0));
			Debug.Log ("Deccelerating");
		}

		myRotation = Input.GetAxis ("Horizontal") * Time.deltaTime * turnSpeed;
		transform.Rotate (0, myRotation ,0);

	}
}
