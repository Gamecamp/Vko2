using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform player;
	Renderer playerRenderer;

	public Transform cube;
	Renderer cubeRenderer;

	public float distanceMultiplier;

	private Vector3 middlePoint;
	private float distanceFromMiddlePoint;
	private float distanceBetweenPlayers;
	private float cameraDistance;
	private float aspectRatio;
	private float fov;
	private float tanFov;

	private float margin;
	public float zoomSpeed;

	// Use this for initialization
	void Start () {
		//playerRenderer = player.GetComponent<MeshRenderer> ();
		//cubeRenderer = cube.GetComponent<MeshRenderer> ();

		aspectRatio = Screen.width / Screen.height;
		tanFov = Mathf.Tan (Mathf.Deg2Rad * Camera.main.fieldOfView * 0.5f);
	}


	//  ** master branch Update version **
	/*
	// Update is called once per frame
	void Update () {

//		if (!playerRenderer.isVisible || !cubeRenderer.isVisible) {
//
//			print ("EI NÄY PRKL");
//
//			distancemultip = distancemultip + 0.1f;
//			transform.position = new Vector3 ((player.transform.position.x + cube.transform.position.x) / 2, Vector3.Distance(player.transform.position,cube.transform.position)*distancemultip, (player.transform.position.z + cube.transform.position.z) / 2);
//
//		}

//		float distX = Mathf.Abs(player.transform.position.x - cube.transform.position.x);
//		float distZ = Mathf.Abs(player.transform.position.z - cube.transform.position.z);
//
//		if (distX > distZ) {
//
//		}
//
//
//		Vector3 zHelperPlayer = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
//		
//		Vector3 zHelperCube = new Vector3 (cube.transform.position.x, cube.transform.position.y, player.transform.position.z);
//
		
		transform.position = new Vector3 ((player.transform.position.x + cube.transform.position.x) / 2, Vector3.Distance(player.transform.position, cube.transform.position)*distancemultip, (player.transform.position.z + cube.transform.position.z) / 2);

			//transform.position = new Vector3 ((player.transform.position.x + cube.transform.position.x) / 2, Vector3.Distance(player.transform.position,cube.transform.position)*distancemultip, (player.transform.position.z + cube.transform.position.z) / 2);
	}
	*/

	void Update() {

		Vector3 vectorBetweenPlayers = cube.position - player.position;
		middlePoint = player.position + 0.5f * vectorBetweenPlayers;

		//float xDistance = Mathf.Abs (vectorBetweenPlayers.x);
		float zDistance = Mathf.Abs (vectorBetweenPlayers.z);

		distanceMultiplier = 1 + zDistance / 90;
		margin = 2f;

		distanceBetweenPlayers = vectorBetweenPlayers.magnitude;
		cameraDistance = (distanceBetweenPlayers / 2.0f / aspectRatio) / tanFov;

		middlePoint = new Vector3 (middlePoint.x, (cameraDistance + margin) * distanceMultiplier, middlePoint.z);

		if (middlePoint.y < 20) {
			middlePoint = new Vector3 (middlePoint.x, 20, middlePoint.z);
		}
	}

	void LateUpdate() {
		transform.position = middlePoint;
		//transform.position = Vector3.Lerp(transform.position, middlePoint, Time.deltaTime * zoomSpeed);
	}
	
}
