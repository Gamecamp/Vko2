using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	bool isGrounded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Mathf.Abs ((transform.eulerAngles.x + 1) % 360) > 2 || Mathf.Abs ((transform.eulerAngles.z + 1) % 360) > 2) {
			SetIsGrounded (false);
		}*/
	}

	void OnCollisionStay(Collision col) {
		if (col.gameObject.tag == "Floor") {
			SetIsGrounded (true);
		}
	}

	void OnCollisionExit(Collision col) {
		if (col.gameObject.tag == "Floor") {
			SetIsGrounded (false);
		}
	}

	public void SetIsGrounded(bool isGrounded) {
		this.isGrounded = isGrounded;
	}

	public bool GetIsGrounded() {
		return isGrounded;
	}
}
