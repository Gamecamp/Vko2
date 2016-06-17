using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnePlayerGame() {
		GameObject.Find ("PlayerAmount").GetComponent<PlayerAmount> ().SetAmountOfPlayers (1);
		SceneManager.LoadScene("rofl");
	}

	public void TwoPlayerGame() {
		GameObject.Find ("PlayerAmount").GetComponent<PlayerAmount> ().SetAmountOfPlayers (2);
		SceneManager.LoadScene("rofl");
	}

	public void StartScreen() {
		SceneManager.LoadScene("start");
	}


}
