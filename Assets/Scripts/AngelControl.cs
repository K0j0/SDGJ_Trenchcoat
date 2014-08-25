using UnityEngine;
using System.Collections;

public class AngelControl : MonoBehaviour {

	public SoundManager soundMan;
//	public GameObject angel;
	public GameObject follower;
	HelperController dude;
	public SpriteRenderer sRenderer;
	public Transform groundCheck;
	public float groundRadius = .1f;

	bool grounded;
	public float move;
	public float speed = 10f;
	public float jump = 300f;
	public float hitRange = 2f;
	public float launchStrengh = 300f;
	public Rigidbody2D rBody; // using parent's rigidbody so animation doesn't mess w/gravity
	bool faceRight = true;
	Animator anim;

	// For tutorial
	public bool canMove;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		sRenderer = GetComponent<SpriteRenderer> ();
		dude = follower.GetComponent<HelperController> ();
	}

	void FixedUpdate(){
		grounded = true; //Physics2D.OverlapCircle (groundCheck.position, groundRadius);

		// don't rotate!
		transform.localEulerAngles = new Vector3 (0, 0, 0);

		// Move
		if(canMove) CheckMove();


		if (move > 0 && !faceRight) {
				Flip ();
		}
		else if(move < 0 && faceRight){
			Flip();
		}
	}


	void Update(){
//		print ("Distance from follower: " + Vector3.Distance (transform.position, follower.transform.position));

		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = true; //Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
//		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius);

		// Jump!
		if(grounded && Input.GetKeyDown(KeyCode.W)){
			rBody.AddForce(new Vector2(0, jump));

			// if close to follower, then launch him up
			if(Vector3.Distance(transform.position, follower.transform.position) < .75f){
				HelperController followerController = follower.GetComponent<HelperController>();
				followerController.Launch(new Vector2(launchStrengh, launchStrengh));
			}
		}

		// Attack!
		if(Input.GetKeyDown(KeyCode.Space)){
			soundMan.PlaySound(Snd.sw_sing);
			anim.SetTrigger("Stab");
		}

//		CheckHitDude ();

//		print (sRenderer.sprite.name);
	}

	void CheckHitDude(){
		if (sRenderer.sprite.name == "Angel_Stab_2") {
			if(Vector3.Distance(gameObject.transform.position, follower.transform.position) < hitRange){
				dude.Launch(new Vector2(2* launchStrengh, 0));
			}
		}
	}

	void CheckMove(){
		move = Input.GetAxis ("Horizontal");
		move *= speed;
		
		rBody.velocity = new Vector2(move, rBody.velocity.y);
		
		// animate if moving
		anim.SetBool ("Running", move != 0);
	}

	// Use this instead of OnTriggerEnter since hit box is far from body gets triggered early
	void OnTriggerStay2D(Collider2D other){
		//print ("Tigger Enter");
		if(sRenderer.sprite.name == "Angel_Stab_2"){
			GameObject target = other.gameObject;
			if(target.tag == "Enemy"){
				EnemyScript enemy = target.GetComponent<EnemyScript>();
				enemy.Die();
			}
		}
	}

	void Flip(){
		faceRight = !faceRight;
		Vector3 vec = transform.localScale;
		vec.x *= -1;
		transform.localScale = vec;
	}

	void OnGUI(){
//		GUI.Label (new Rect(0, 0, 200, 100), "grounded: " + grounded + "\nY Vel: " + rBody.velocity.y);
	}
}
