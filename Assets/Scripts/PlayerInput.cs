using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	Scorekeeper scorekeeper;

	private KeyCode playerAccelerateKey;
	private KeyCode playerDeccerelateKey;
	private Rigidbody rigidbody;
<<<<<<< HEAD

=======
>>>>>>> origin/master

	private float myRotation;
	public float turnSpeed;
	public float torque;
	public float torqueDeccerelationMultiplier;
	public float minimumSpeedForTurning;

	private Vector3 minimumTurnVelocity;
	private bool isGrounded;
	private float resetTime;

	private const bool DEBUG = true;

	CheckPointChecker checkPointChecker;


	// Use this for initialization
	void Start () {
		scorekeeper = GameObject.Find ("Scorekeeper").GetComponent<Scorekeeper>();
		checkPointChecker = GetComponent<CheckPointChecker> ();

		playerAccelerateKey = KeyCode.W;
		playerDeccerelateKey = KeyCode.S;
		rigidbody = GetComponent<Rigidbody> ();
		minimumTurnVelocity = new Vector3 (1, 1, 1);
		resetTime = 0;
	}

	void Update () {
<<<<<<< HEAD

=======
>>>>>>> origin/master
		if (scorekeeper.gameGoing) {
			isGrounded = GetComponent<GroundCheck> ().GetIsGrounded ();
			print (isGrounded);

			if (isGrounded) {
				playerAcceleration ();
			}
			playerTurning ();
			resetPosition ();
			DebugMoving (DEBUG);
		}
<<<<<<< HEAD

		isGrounded = GetComponent<GroundCheck> ().GetIsGrounded ();
		print (isGrounded);

		if (isGrounded) {
			playerAcceleration ();
		}
		playerTurning ();
		resetPosition ();
		DebugMoving (DEBUG);
=======

>>>>>>> origin/master
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

	void resetPosition() {
		if (!isGrounded) {
			resetTime += Time.deltaTime;

			if (resetTime > 3.0f) {
				print ("reset");

				if (checkPointChecker.GetCurrentPoint() > 0) {
					transform.position = checkPointChecker.checkPoints [checkPointChecker.GetCurrentPoint () - 1].transform.position;
					transform.rotation = checkPointChecker.checkPoints [checkPointChecker.GetCurrentPoint () - 1].transform.rotation;
				} else {
					transform.position = GameObject.Find ("Finishline").transform.position;
				}
				print ("current point :" + checkPointChecker.GetCurrentPoint ());

				resetTime = 0;
			}
		} else {
			resetTime = 0;
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
