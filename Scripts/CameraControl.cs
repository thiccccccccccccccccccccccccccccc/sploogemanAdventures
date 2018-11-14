using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	
	
	public float cameraSpeed = 4.0f;
	public float maxCameraDistance = 5.0f;
	private float move;
	private float[] buffer = { -0.02f, 0.02f };
	private PlayerPlatformerController ppc;
	// Use this for initialization
	void Start () {
		ppc = transform.parent.GetComponent<PlayerPlatformerController>();
	}
	
	// Update is called once per frame
	void Update () {
		move = GetBaseInput();
		smoothCameraComeBack();
		if (move != 0 && ppc.grounded) {
			if (transform.localPosition.x > -maxCameraDistance && transform.localPosition.x < maxCameraDistance) {
				transform.Translate(new Vector3(move, 0, 0) * cameraSpeed * Time.deltaTime);
				move = 0f;
			}
			
		}
		
	}
	
	private void smoothCameraComeBack() {
		Vector3 moveFactor = new Vector3(1.0f,0f,0f);
		
		if (move == 0) {
			if (transform.localPosition.x != 0) {
				if (transform.localPosition.x < 0) {
					transform.Translate(moveFactor * cameraSpeed * Time.deltaTime);
				} else if (transform.localPosition.x > 0) {
					transform.Translate(-moveFactor * cameraSpeed * Time.deltaTime);
				}
			}
			if (transform.localPosition.x > buffer[0] && transform.localPosition.x < buffer[1]) {
				transform.localPosition = new Vector3(0,0, -10.0f);
			}
		}
	}
	
	private float GetBaseInput() {
		float input = Input.GetAxisRaw("CameraHorizontal");
		return input;
	}
}
