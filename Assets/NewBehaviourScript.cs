using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject player;
	Rigidbody rb;
	public float speed;
	public float turningSpeed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		PlayerInput ();
		Movement ();
	}

	void Movement() {
		rb.AddForce (new Vector3 (Mathf.Cos(transform.eulerAngles.y * Mathf.Deg2Rad) * speed, 0, Mathf.Sin(transform.eulerAngles.y * Mathf.Deg2Rad) * speed));
	}

	void PlayerInput() {
		if (Input.GetKey (KeyCode.A)) {
			player.transform.rotation =
				Quaternion.Euler (player.transform.eulerAngles.x, player.transform.eulerAngles.y - turningSpeed, player.transform.eulerAngles.z);
		}

		if (Input.GetKey (KeyCode.D)) {
			player.transform.rotation =
				Quaternion.Euler (player.transform.eulerAngles.x, player.transform.eulerAngles.y + turningSpeed, player.transform.eulerAngles.z);
		}
	}
}
