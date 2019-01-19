using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private bool hasStarted = false;
	private Paddle paddle;
	private Vector3 distanceFromPaddleToBall;
	public Sprite[] ballSprites;
	private static int ballSpriteIndex = 0;
	public Text text;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		distanceFromPaddleToBall = this.transform.position - paddle.transform.position;
		this.GetComponent<SpriteRenderer>().sprite = ballSprites[ballSpriteIndex];
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevel != 7){
			if(!hasStarted){
				this.transform.position = paddle.transform.position + distanceFromPaddleToBall;
				
				if(Input.GetMouseButtonDown(0)){
					print ("Ball Launched!");
					this.GetComponent<Rigidbody2D>().velocity = new Vector2(5f,8f);
					hasStarted = true;
				}
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if(Application.loadedLevel != 7){
			Vector2 tweak = new Vector2(Random.Range(0f,.2f),Random.Range(0f,0.2f));
			//print("Value of Tweak is: " + tweak.x + tweak.y);
			
			//If it hits the Paddle
			if(this.transform.position.y < (paddle.transform.position.y + distanceFromPaddleToBall.y + 0.2)){
				
				if(this.transform.position.x > paddle.transform.position.x - 0.2 && this.transform.position.x < paddle.transform.position.x + 0.2 ){
					//					this.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f,8f);
					this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f,2f),8f);
				}
				else if(this.transform.position.x < paddle.transform.position.x){
//					this.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f,8f);
					this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5f,-3f),8f);
				}
				else{
//					this.GetComponent<Rigidbody2D>().velocity = new Vector2(5f,8f);
					this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(3f,5f),8f);
				}
				print ("Collision With Paddle");
			}
			else if(collision.collider.name == "invincible"){
				if(this.transform.position.y < (collision.collider.transform.position.y + distanceFromPaddleToBall.y + 0.2) &&
				   this.transform.position.y > (collision.collider.transform.position.y  - 0.1)){
					if(this.transform.position.x < collision.collider.transform.position.x){
						this.GetComponent<Rigidbody2D>().velocity = new Vector2(-2.5f,4f);
					}
					else{
						this.GetComponent<Rigidbody2D>().velocity = new Vector2(2.5f,4f);
					}
					print ("Collision With Invincible Brick");
				}	
			}
			else{
				this.GetComponent<Rigidbody2D>().velocity += tweak;
			}
		}
	}
	
	public void setBallSprite(int index){
		text.text = index.ToString();
		ballSpriteIndex = index - 1;
	}
}
