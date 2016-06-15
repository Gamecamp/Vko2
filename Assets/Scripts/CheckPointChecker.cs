using UnityEngine;
using System.Collections;

public class CheckPointChecker : MonoBehaviour {

	public GameObject[] checkPoints;

	int currentPoint;
	public int maxPoint;

	int currentLap;
	public int maxLap;


	// Use this for initialization
	void Start () {
		currentPoint = 0;
		currentLap = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		print ("woop woop");
		if(col.gameObject.Equals(checkPoints[currentPoint])) {
			print ("score");
			currentPoint++;
		}
	}
}
