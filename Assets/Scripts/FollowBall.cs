using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour{

	Transform playerTransform;
	float offsetX;
	static int randomNum;
	void Start(){

		randomNum = Random.Range(0, 5);
		GameObject player = GameObject.FindGameObjectWithTag("Ball");
		if (player==null){
			
			Debug.LogError("CameraTracker script couldn't find the Ball object");
			return;
		}
		playerTransform = player.transform;
		offsetX = transform.position.x - playerTransform.position.x;
	}

	void Update(){

		Vector3 temp = transform.position;
		temp.x = playerTransform.position.x + offsetX;
		temp.z = 0;
		transform.position = temp;
	}

	void OnCollisionEnter2D(Collision2D collision){

		Vector2 temp = collision.gameObject.transform.position;
		temp.x += 24;
		collision.gameObject.transform.position = temp;
		Animator animator = collision.gameObject.GetComponent<Animator>();
		int tempNum = Random.Range (1, 5);
		while (tempNum == randomNum){

			tempNum = Random.Range (1, 5);
		}
		animator.SetInteger ("Color", tempNum);
		randomNum = tempNum;
	}
}
