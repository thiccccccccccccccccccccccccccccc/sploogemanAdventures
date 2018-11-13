using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
	
	Vector2 move = new Vector2(0,0);
	public float cameraSpeed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		move = GetBaseInput();
		/**if (Input.GetButtonUp("CameraHorizontal")) {
			transform.localPosition = new Vector3(0,0, -10);
		}**/
		smoothCameraComeBack();
		transform.Translate(move * cameraSpeed * Time.deltaTime);
		Debug.Log(transform.localPosition);
	}
	
	private void smoothCameraComeBack() {
		if (Input.GetButtonUp("CameraHorizontal")) {
			for (float i = 10f; i>=0f; i-=0.1f) {
				transform.localPosition = new Vector3(i*Time.deltaTime,0, -10);
			}
		}
	}
	
	private Vector2 GetBaseInput() {
		Vector2 input = new Vector2();
		if (Input.GetKey(KeyCode.Q)) {
			input += new Vector2(-1, 0);
		}
		if (Input.GetKey(KeyCode.E)) {
			input += new Vector2(1, 0);
		}
		return input;
	}
}
