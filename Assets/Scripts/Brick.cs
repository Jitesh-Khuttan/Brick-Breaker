using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] spriteHit;
	
	private int timesHit;
	private LevelController levelController;
	public static int breakableBricks = 0;
	public AudioClip crack;	
	public Transform boomObject;
	
	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelController = GameObject.FindObjectOfType<LevelController>();
		if(gameObject.tag == "Breakable"){
			breakableBricks++;
			print ("Breakable Bricks: " + breakableBricks);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D collision){
	
		bool isBreakable = (this.tag == "Breakable");
		
		if(isBreakable){
			AudioSource.PlayClipAtPoint(crack,this.transform.position);
			handleHits();
		}	
		//Check if all the bricks have been destroyed
		if(breakableBricks <= 0){
			nextLevel();
		}
	}
	
	void handleHits(){
	
		int maxHits = spriteHit.Length + 1;
		timesHit++;
		if(timesHit >= maxHits){
			GameObject.Destroy(gameObject);
			breakableBricks--;
			Instantiate(boomObject,this.transform.position,boomObject.rotation);
			print ("Breakable Bricks: " + breakableBricks);
		}
		else{
			changeSprite();
		}
	}
	
	void changeSprite(){
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer>().sprite = spriteHit[spriteIndex];
	}
	
	void nextLevel(){
		print ("Loading Next Level" );
		levelController.LoadNextLevel();
	}
}
