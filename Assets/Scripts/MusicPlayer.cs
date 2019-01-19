using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer musicPlayer = null;
	
	//The first method that gets called when script is loaded
	void Awake(){
		
		/*GameObject is the name of the class, DontDestroyOnLoad() is the static function of that class,
		  gameObject is the name of the current object on which the script is currrently added as a Component (in our case
		  Music Player[Notice The Space] ) */
		
		/* Declaration : public static void DontDestroyOnLoad(Object target) */
		/*Object is the top class in hierarchy of Unity C# */
		/*this and gameObject are different things.this refers to instance of class, Eg: MusicPlayer Mp = new MusicPlayer()
		  gameObject refers to object on which script is attached.(Inour case: Music Player) */

		/*The keyword "this" is a reference to the current class, where as gameObject is what object the script is on, 
		when you call Destroy(this) you are just removing the script from the game object rather than trying to destroy
		 the actual object*/
		
		if(musicPlayer != null){
			GameObject.Destroy(gameObject);
			print("Newly Created Duplicate Object Destroyed!");
		}
		else{
			musicPlayer = this;
			GameObject.DontDestroyOnLoad(gameObject);
			print("Music Player Object is Created!");
		}
	}

	// Use this for initialization
	void Start () {	
		 	
	}		
	
	// Update is called once per frame
	void Update () {
	
	}
}
