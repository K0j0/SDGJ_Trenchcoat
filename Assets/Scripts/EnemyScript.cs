using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public SoundManager soundMan;
	GameController gameController;
	Animator anim;
	public GameObject target;
	public float speed = 1f;
	bool isDying;
	public bool deadly;

	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		anim = GetComponent<Animator> ();
		GameObject follower = GameObject.FindGameObjectWithTag ("Follower");
		target = follower;
	}
	
	// Update is called once per frame
	void Update () {
		if(isDying){
			AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
			if(stateInfo.IsName("EnemyDie") && stateInfo.normalizedTime >= 1){				 
				print ("Destroy!!!");
				Destroy(gameObject);
			}
		}
		else{
			if(gameController.isGameOn){
				ChasePlayer();
			}
		}
	}

	void ChasePlayer(){
		/*
		// Look at where target is and head towards it
		float moveX = speed; //target.transform.position.x > transform.position.x ? speed : -speed;
		float moveY = speed; //target.transform.position.y > transform.position.y ? speed : -speed;

		float angle = Vector2.Angle (transform.position, target.transform.position);

		Vector2 move = rigidbody2D.velocity;
		move.x = Mathf.Cos(Mathf.Deg2Rad * angle) * moveX;
		move.y = Mathf.Sin(Mathf.Deg2Rad * angle) * moveY;
		rigidbody2D.velocity = move;

//		print ("Enemy angle: " + angle + " speed: " + speed + "moveY: " + moveY + " velocity: " + move);

//		rigidbody2D.AddForce (new Vector2 (moveX, moveY));
		*/
		
		float moveX = target.transform.position.x > transform.position.x ? speed : -speed;
		float moveY = target.transform.position.y > transform.position.y ? speed : -speed;
		
		Vector2 move = rigidbody2D.velocity;
		move.x = moveX;
		move.y = moveY;
		rigidbody2D.velocity = move;
	}

	void OnTriggerEnter2D(Collider2D other){
//		print ("hit");
		GameObject target = other.gameObject;
		if(!isDying && deadly && target.tag == "Follower"){
			speed = 0;
			HelperController follower = target.GetComponent<HelperController>();
			follower.Die();
		}
	}

	public void Die(){
//		soundMan.PlaySound (Snd.enem_ded);
//		print ("Oh Noe!");
		isDying = true;
		anim.SetTrigger ("Die");
	}
}
