using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform player;
	public Transform cube;
	public float distanceMultiplier;
	public float minimumDistance;
	public float maximumDistance;

	private bool player2Active;
	private Vector3 middlePoint;
	private float distanceFromMiddlePoint;
	private float distanceBetweenPlayers;
	private float cameraDistance;
	private float aspectRatio;
	private float fov;
	private float tanFov;
	private float margin;

	// Use this for initialization
	void Start () {
		aspectRatio = Screen.width / Screen.height;
		tanFov = Mathf.Tan (Mathf.Deg2Rad * Camera.main.fieldOfView * 0.5f);

		try  {
			cube = GameObject.Find("Player2").GetComponent<Transform>();
			player2Active = true;
		} catch (System.Exception e) {
			cube = player;
			player2Active = false;
		}

		print (player2Active);
	}

	void Update() {
		if (player2Active) {
			MoveCamera2Player ();
		} else {
			MoveCamera1Player ();
		}
	}

	void MoveCamera2Player() {
		Vector3 vectorBetweenPlayers = cube.position - player.position;
		middlePoint = player.position + 0.5f * vectorBetweenPlayers;

		print (middlePoint.z);

		distanceBetweenPlayers = vectorBetweenPlayers.magnitude;
		cameraDistance = (distanceBetweenPlayers / 2.0f / aspectRatio) / tanFov;

		float zDistance = Mathf.Abs (vectorBetweenPlayers.z);
		distanceMultiplier = 1 + zDistance / 200;
		margin = 2f;

		middlePoint = new Vector3 (middlePoint.x, (cameraDistance + margin) * distanceMultiplier, middlePoint.z);

		//min distance zoom
		if (middlePoint.y < minimumDistance) {
			middlePoint = new Vector3 (middlePoint.x, minimumDistance, middlePoint.z);
		}

		if (middlePoint.y > maximumDistance) {
			middlePoint = new Vector3 (middlePoint.x, maximumDistance, middlePoint.z);
		}

		middlePoint = new Vector3(middlePoint.x, 0.8f * middlePoint.y, middlePoint.z - (Mathf.Tan (Mathf.Deg2Rad * 30)) * middlePoint.y);
	}

	void MoveCamera1Player() {
		middlePoint = player.position;
		middlePoint.y = minimumDistance;
		middlePoint.z = middlePoint.z - 40;
	}

	void LateUpdate() {
		transform.position = middlePoint;
	}
	
}
