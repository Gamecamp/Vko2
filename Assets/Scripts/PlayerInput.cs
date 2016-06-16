using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	Scorekeeper scorekeeper;

	private KeyCode playerAccelerateKey;
	private KeyCode playerDeccerelateKey;
	private KeyCode playerTurnLeftKey;
	private KeyCode playerTurnRightKey;
	private Rigidbody rigidbody;
	private Rigidbody groundCheckRB;
	private GroundCheck groundCheck;

	private float myRotation;
	public float turnSpeed;
	public float torque;
	public float torqueDeccerelationMultiplier;
	public float minimumSpeedForTurning;


	private string horizontalAxisName;
	private Vector3 minimumTurnVelocity;
	private bool isGrounded;
	private float resetTime;

	private const bool DEBUG = true;

	CheckPointChecker checkPointChecker;


	// Use this for initialization
	void Start () {
		scorekeeper = GameObject.Find ("Scorekeeper").GetComponent<Scorekeeper>();
		checkPointChecker = GetComponent<CheckPointChecker> ();

		if (gameObject.name == "Player") {
			playerAccelerateKey = KeyCode.W;
			playerDeccerelateKey = KeyCode.S;
			horizontalAxisName = "Horizontal";
			groundCheckRB = GameObject.Find ("GroundCheckPlayer1").GetComponent<Rigidbody> ();
			groundCheck = GameObject.Find ("GroundCheckPlayer1").GetComponent<GroundCheck>();
		}

		if (gameObject.name == "Player2") {
			playerAccelerateKey = KeyCode.UpArrow;
			playerDeccerelateKey = KeyCode.DownArrow;
			horizontalAxisName = "Horizontal2";
			groundCheckRB = GameObject.Find ("GroundCheckPlayer2").GetComponent<Rigidbody> ();
			groundCheck = GameObject.Find ("GroundCheckPlayer2").GetComponent<GroundCheck>();
		}

		rigidbody = GetComponent<Rigidbody> ();
		minimumTurnVelocity = new Vector3 (5f, 5f, 5f);
		resetTime = 0;


	}

	void Update () {
		if (scorekeeper.gameGoing) {
			isGrounded = groundCheck.GetIsGrounded ();
			if (isGrounded) {
				playerAcceleration ();
			}
			playerTurning ();
			resetPosition ();
			DebugMoving (DEBUG);
		}

	}

	void playerAcceleration() {
		groundCheckRB.drag = 0.6f;

		if (Input.GetKey (playerAccelerateKey)) {

			if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {
				Vector3 velo = transform.InverseTransformDirection(rigidbody.velocity);
				velo.z = velo.z * 0.98f;
				rigidbody.velocity = transform.TransformDirection(velo);
			}
			rigidbody.AddRelativeForce(new Vector3(torque, 0, 0));

		} else if (Input.GetKey (playerDeccerelateKey)) {
			groundCheckRB.drag = 1.0f;
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
					transform.rotation = GameObject.Find ("Finishline").transform.rotation;
				}
				print ("current point :" + checkPointChecker.GetCurrentPoint ());

				resetTime = 0;
			}
		} else {
			resetTime = 0;
		}
	}

	void playerTurning() {

		myRotation = Input.GetAxis(horizontalAxisName) * Time.deltaTime * turnSpeed;

		if (rigidbody.velocity.magnitude > minimumTurnVelocity.magnitude) {
			transform.Rotate (0, myRotation, 0);
		} else {
			transform.Rotate (0, myRotation * (rigidbody.velocity.magnitude / minimumTurnVelocity.magnitude), 0);
		}

	}

	void DebugMoving(bool b) {
		
		if (b) {
			Debug.DrawRay (transform.position, rigidbody.velocity, Color.red);
			Debug.DrawRay (transform.position, gameObject.transform.right * 5f, Color.green);
		}
	}

}
