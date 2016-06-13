using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public GameObject player;
	Renderer playerRenderer;

	public GameObject cube;
	Renderer cubeRenderer;

	public float distancemultip;

	// Use this for initialization
	void Start () {
		playerRenderer = player.GetComponent<MeshRenderer> ();
		cubeRenderer = cube.GetComponent<MeshRenderer> ();
	}

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
}
