using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelController levelController;
	
	void Start(){
		levelController = GameObject.FindObjectOfType<LevelController>();
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		print ("Collision!");
		levelController.changeLevel("Lose");
	}
	
	void OnTriggerEnter2D(Collider2D trigger){
		
		print ("Trigger");
	}
	
}
