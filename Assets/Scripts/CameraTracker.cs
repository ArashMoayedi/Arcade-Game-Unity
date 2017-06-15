using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour{

	Transform playerTransform;
	float offsetX;

	void Start(){

		GameObject player = GameObject.FindGameObjectWithTag("Ball");
		if(player==null){
			
			Debug.LogError("CameraTracker script couldn't find the Ball object");
			return;
		}
		playerTransform = player.transform;
		offsetX = transform.position.x - playerTransform.position.x;
	}

	void Update(){

		Vector3 temp = transform.position;
		temp.x = playerTransform.position.x + offsetX;
		temp.z = -5.5f;
		transform.position = temp;
	}
}
