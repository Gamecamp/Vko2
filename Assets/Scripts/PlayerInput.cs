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

	private Vector3 minimumTurnVelocity;

	// Use this for initialization
	void Start () {
		playerAccelerateKey = KeyCode.W;
		playerDeccerelateKey = KeyCode.S;
		rigidbody = GetComponent<Rigidbody> ();
		minimumTurnVelocity = new Vector3 (1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		GetPlayerInput ();
	}

	/*
	void GetPlayerInput () {
		if (Input.GetKey (playerAccelerateKey)) {
			rigidbody.AddRelativeForce(new Vector3(torque, 0, 0));
		} else if (Input.GetKey (playerDeccerelateKey)) {
			rigidbody.AddRelativeForce(new Vector3(-torque * torqueDeccerelationMultiplier, 0, 0));
		}
			
		if (Mathf.Abs (transform.InverseTransformDirection (rigidbody.velocity).x) > minimumSpeedForTurning || Mathf.Abs (transform.InverseTransformDirection (rigidbody.velocity).z) > minimumSpeedForTurning) {
			myRotation = Input.GetAxis ("Horizontal") * Time.deltaTime * turnSpeed;
		} else {
			myRotation = Input.GetAxis ("Horizontal") * Time.deltaTime * turnSpeed * (Mathf.Abs (transform.InverseTransformDirection (rigidbody.velocity).x));
		}

		transform.Rotate (0, myRotation, 0);
	}
	*/

	void GetPlayerInput() {
		rigidbody.drag = 0.6f;

		if (Input.GetKey (playerAccelerateKey)) {
//			if (Vector3.Angle (rigidbody.velocity, gameObject.transform.right) > 30) {
//				rigidbody.AddRelativeForce(new Vector3(torque, 0, 0) + transform.right);
//			}

			if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {
				//Vector3 velo = new Vector3 (rigidbody.velocity.x, rigidbody.velocity.y, rigidbody.velocity.z * 0.9f);
				//Vector3 velo = transform.TransformDirection(rigidbody.velocity);
				Vector3 velo = transform.InverseTransformDirection(rigidbody.velocity);
				velo.z = velo.z * 0.98f;
				rigidbody.velocity = transform.TransformDirection(velo);
//				rigidbody.velocity = (new Vector3 (transform.InverseTransformDirection(rigidbody.velocity.x)
//					, transform.InverseTransformDirection.(rigidbody.velocity.y),
//					transform.InverseTransformDirection(rigidbody.velocity.z * 0.9f)));
			}

			rigidbody.AddRelativeForce(new Vector3(torque, 0, 0));


		} else if (Input.GetKey (playerDeccerelateKey)) {
			//rigidbody.AddRelativeForce(new Vector3(-torque * torqueDeccerelationMultiplier, 0, 0));
			//rigidbody.AddRelativeForce(-(rigidbody.velocity * 0.4f));
			rigidbody.drag = 1.0f;
		}
			
		myRotation = Input.GetAxis ("Horizontal") * Time.deltaTime * turnSpeed;

		if (rigidbody.velocity.magnitude > minimumTurnVelocity.magnitude) {
			transform.Rotate (0, myRotation, 0);
		} 
			
		print (" angle = " + Vector3.Angle(rigidbody.velocity, gameObject.transform.right));

		if (Vector3.Angle (rigidbody.velocity, gameObject.transform.right) > 30) {

		}

		Debug.DrawRay (transform.position, rigidbody.velocity, Color.red);
		Debug.DrawRay (transform.position, gameObject.transform.right * 5f, Color.green);

		print ("velocity = " + rigidbody.velocity);
	}
}
