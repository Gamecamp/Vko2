using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform player;
	public Transform cube;
	public float distanceMultiplier;

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
	}

	void Update() {

		Vector3 vectorBetweenPlayers = cube.position - player.position;
		middlePoint = player.position + 0.5f * vectorBetweenPlayers;

		distanceBetweenPlayers = vectorBetweenPlayers.magnitude;
		cameraDistance = (distanceBetweenPlayers / 2.0f / aspectRatio) / tanFov;

		float zDistance = Mathf.Abs (vectorBetweenPlayers.z);
		distanceMultiplier = 1 + zDistance / 90;
		margin = 2f;

		middlePoint = new Vector3 (middlePoint.x, (cameraDistance + margin) * distanceMultiplier, middlePoint.z);

		//min distance zoom
		if (middlePoint.y < 30) {
			middlePoint = new Vector3 (middlePoint.x, 30, middlePoint.z);
		}
	}

	void LateUpdate() {
		transform.position = middlePoint;
	}
	
}
