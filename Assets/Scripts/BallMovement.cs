using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour{

	Animator animator;
	public bool isDead;
	public int score;
	public int highScore;
	public Text scoreString;
	public Text highScoreString;

	void Start (){

		animator = GetComponent<Animator>();
		isDead = false;
		score = 0;
		highScore = PlayerPrefs.GetInt ("highScore", highScore);
	}

	void FixedUpdate(){

		scoreString.text = "Score: " + score;
		highScoreString.text = "Highscore: " + highScore;
		Vector2 temp = transform.position;
		temp.x += 1.245f * Time.deltaTime;
		transform.position = temp;
		if (Time.timeScale <= 3f){
			
			Time.timeScale += Time.deltaTime * 0.03f;
		}
		if (Input.GetKey(KeyCode.Q)){
			
			animator.SetInteger("Color", 1);
		}
		if (Input.GetKey (KeyCode.W)){
			
			animator.SetInteger("Color", 2);
		}
		if (Input.GetKey (KeyCode.E)){

			animator.SetInteger("Color", 3);
		}
		if (Input.GetKey (KeyCode.R)){

			animator.SetInteger("Color", 4);
		}
	}

	void OnTriggerEnter2D(Collider2D collider){

		Vector2 temp = GetComponent<Rigidbody2D>().velocity;
		Vector2 temp2 = transform.position;
		temp2.x = collider.transform.position.x;
		transform.position = temp2;
		temp.y = 8f;
		GetComponent<Rigidbody2D>().velocity = temp;
		if (collider.gameObject.GetComponent<Animator> ().GetInteger ("Color") != animator.GetInteger("Color")){

			isDead = true;
			if (score > highScore){

				highScore = score;
				PlayerPrefs.SetInt("highScore", highScore);
			}
		} else{

			score += 1;
		}
	}
}