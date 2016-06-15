using UnityEngine;
using System.Collections;

public class CheckPointChecker : MonoBehaviour {

	public GameObject[] checkPoints;

	int currentPoint;
	public int maxPoint;

	int currentLap;
	int maxLaps;

	Scorekeeper scorekeeper;


	// Use this for initialization
	void Start () {
		currentPoint = 0;
		currentLap = 0;
		scorekeeper = GameObject.Find ("Scorekeeper").GetComponent<Scorekeeper> ();
		maxPoint = checkPoints.Length;
		maxLaps = scorekeeper.maxLaps;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetCurrentLap() {
		return currentLap;
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Checkpoint") {
			if (currentPoint< checkPoints.Length && col.gameObject.Equals (checkPoints [currentPoint])) {
				print ("Checkpoint! " + checkPoints[currentPoint]);
				currentPoint++;
			}
		}
		if (col.gameObject.tag == "Finishline") {
			if (currentLap == 0) {
				currentLap++;
				currentPoint = 0;
			} else if (currentLap < maxLaps && currentPoint == maxPoint) {
				currentLap++;
				currentPoint = 0;
			} else if (currentLap == maxLaps && currentPoint == maxPoint) {
				currentPoint = 0;
				AnnounceWinner ();
			}
		}
	}

	void AnnounceWinner() {
		scorekeeper.RaceOver(gameObject);
	}
}
