using UnityEngine;
using UnityEngine.SceneManagement;

public class OverOverOver : MonoBehaviour{
	
	public float restartDelay = 0.5f;         
	Animator anim;                          
	float restartTimer;                     

	void Awake (){
		
	anim = GetComponent<Animator>();
	}
		
	void Update (){
		
		if(GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>().isDead){

			restartTimer = 0;
			anim.SetTrigger("GameOver");
			restartTimer += Time.deltaTime;
			if(restartTimer >= restartDelay){
				
				Time.timeScale = 1f;
				restartTimer = 0;
				SceneManager.LoadScene("Scene");
			}
		}
	}
}