using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Scorekeeper : MonoBehaviour {

	Text player1text;
	Text player2text;
	Text timerText;

	public bool gameGoing;

	float timePassed;
	float startTime;
	public int maxLaps;

	public int winnerFontSize;
	public int timerFontSize;

	public GameObject player1;
	CheckPointChecker player1checkPoints;
	public GameObject player2;
	CheckPointChecker player2checkPoints;

	private bool player2Active;


	// Use this for initialization
	void Start () {
		timerText = GameObject.Find ("Timer").GetComponent<Text> ();
		timerText.fontSize = timerFontSize;
		gameGoing = true;
		startTime = Time.time;


		player1 = GameObject.Find ("Player");
		player1checkPoints = player1.GetComponent<CheckPointChecker> ();
		player1text = GetComponent<Text> ();


		winnerFontSize = 20;
		timerFontSize = 14;

		try {
			player2 = GameObject.Find ("Player2");
			player2checkPoints = player2.GetComponent<CheckPointChecker> ();
			player2text = GameObject.Find ("ScorekeepHelper").GetComponent<Text> ();
			player2Active = true;
		} catch(System.Exception e) {
			player2Active = false;
		}

		print (player2Active);
		


	}
	
	// Update is called once per frame
	void Update () {
		if (gameGoing) {
			CalculateAndUpdateTime ();
			UpdatePlayerStats ();
		}
	}

	public bool GetPlayer2Active() {
		return player2Active;
	}

	public void RaceOver(GameObject winner) {
		timerText.fontSize = winnerFontSize;

		if (player2Active) {
			timerText.text = winner.name + " is the winner!\nTime: " + timePassed.ToString ("##.##");
		} else {
			timerText.text = "Time: " + timePassed.ToString ("##.##");
		}
		gameGoing = false;

	}

	void CalculateAndUpdateTime() {
		timePassed = Time.time - startTime;
		timerText.text = timePassed.ToString ("##.##");
	}

	void UpdatePlayerStats() {
		player1text.text = player1.name + "\n" + "Lap: " + player1checkPoints.GetCurrentLap () + "/" + maxLaps;

		if (player2Active) {
			player2text.text = player2.name + "\n" + "Lap: " + player2checkPoints.GetCurrentLap () + "/" + maxLaps;
		}
	}
		
}
