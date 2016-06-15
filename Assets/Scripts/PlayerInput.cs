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

	private const bool DEBUG = true;

	// Use this for initialization
	void Start () {
		playerAccelerateKey = KeyCode.W;
		playerDeccerelateKey = KeyCode.S;
		rigidbody = GetComponent<Rigidbody> ();
		minimumTurnVelocity = new Vector3 (1, 1, 1);
	}

	void Update () {
		if (GetComponent<GroundCheck> ().GetIsGrounded()) {
			playerAcceleration ();
		}
		playerTurning ();
		DebugMoving (DEBUG);
	}

	void playerAcceleration() {
		rigidbody.drag = 0.6f;

		if (Input.GetKey (playerAccelerateKey)) {

			if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {
				Vector3 velo = transform.InverseTransformDirection(rigidbody.velocity);
				velo.z = velo.z * 0.98f;
				rigidbody.velocity = transform.TransformDirection(velo);
			}
			rigidbody.AddRelativeForce(new Vector3(torque, 0, 0));

		} else if (Input.GetKey (playerDeccerelateKey)) {
			rigidbody.drag = 1.0f;
		}
	}

	void playerTurning() {
		myRotation = Input.GetAxis ("Horizontal") * Time.deltaTime * turnSpeed;

		if (rigidbody.velocity.magnitude > minimumTurnVelocity.magnitude) {
			transform.Rotate (0, myRotation, 0);
		} 

	}

	void DebugMoving(bool b) {
		
		if (b) {
			Debug.DrawRay (transform.position, rigidbody.velocity, Color.red);
			Debug.DrawRay (transform.position, gameObject.transform.right * 5f, Color.green);
		}
	}

}
