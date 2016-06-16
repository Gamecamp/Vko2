using UnityEngine;
using System.Collections;

public class MuSick : MonoBehaviour {

	bool speedUp;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		speedUp = false;
		audioSource = GetComponent<AudioSource> ();
	}

	public void SpeedUp() {
		speedUp = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (speedUp && audioSource.pitch < 1.2f) {
			audioSource.pitch += 0.01f;
		}
	}
}
