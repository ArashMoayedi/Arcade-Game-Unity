using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTimeColorSetter : MonoBehaviour{

	static int previousColor;
	bool firstTime = true;

	void Start(){

		Animator animator = GetComponent<Animator>();
		if (CompareTag("Respawn")){

			animator.SetInteger("Color", 1);
			return;
		}
		if (firstTime){

			previousColor = 0;
			firstTime = false;
		}
		int randomNum = Random.Range(1, 5);
		while (randomNum == previousColor){

			randomNum = Random.Range (1, 5);
		}
		animator.SetInteger("Color", randomNum);
		previousColor = randomNum;
	}
}
