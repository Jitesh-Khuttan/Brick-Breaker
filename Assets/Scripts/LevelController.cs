using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public void changeLevel(string name){
		//Since The value of static variable "breakableBricks" persists when levels change, therefore we need to make it 0 whenevre
		//level change happens
		Brick.breakableBricks = 0;
		Application.LoadLevel(name);
	}
	
	public void quitGame(){
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Brick.breakableBricks = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	
}
