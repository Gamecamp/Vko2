using UnityEngine;
using System.Collections;

public class PlayerAmount : MonoBehaviour {

	private int amountOfPlayers;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int GetAmountOfPlayers() {
		return amountOfPlayers;
	}

	public void SetAmountOfPlayers(int players) {
		amountOfPlayers = players;
	}
}
