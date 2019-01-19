using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Paddle : MonoBehaviour {

	float mousePositionInBlocks;
	Vector3 paddlePos;
	private Ball ball;
	public bool autoPlay = false;
	public Sprite[] paddles;
	public static int selectedPaddleIndex = 0;
	public Text text;
	
	
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		this.GetComponent<SpriteRenderer>().sprite = paddles[selectedPaddleIndex];
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevel != 7){
			if(!autoPlay){
				PlayerPlay();
			}
			else{
				AutoPlay();
			}
		}	
	}
	
	void PlayerPlay(){
		/*Setting Position at 8 world unit i.e. center towards x axis and 0.5 blocks (from 12 blocks) towards y axis */
		paddlePos = new Vector3(this.transform.position.x,this.transform.position.y,0f);	
		
		/*We matched the mouse coordinates to the world units [0-16]*/
		/*Since our brick is equal to 1 world unit, therefore the amount of distance that brick will move will be according to 
		  the distance moved by mouse (which is mapped to world units) */
		mousePositionInBlocks = (Input.mousePosition.x / Screen.width * 16); //Gives Coordinates relative to World Units
		paddlePos.x = Mathf.Clamp(mousePositionInBlocks,1f,15f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay(){
		paddlePos = new Vector3(this.transform.position.x,this.transform.position.y,0f);	
		paddlePos.x = Mathf.Clamp(ball.transform.position.x,1f,15f);
		this.transform.position = paddlePos;
	}
	
	public void selectPaddle(int paddleIndex){
		text.text = paddleIndex.ToString();
		selectedPaddleIndex = paddleIndex - 1;
	}
	
}


