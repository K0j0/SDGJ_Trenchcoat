using UnityEngine;
using System.Collections;

public class HelperController : MonoBehaviour {

	public Animator anim;
	public float speed; //.6
	public ChunkManager chunkManager;
	public GameController gameController;

	private float dist;
	public float walkSpeed = 1f;

	bool isDying;

	public Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		// Wasn't working for some reason
//		Physics2D.GetIgnoreLayerCollision (10, 9);
//		Physics2D.GetIgnoreLayerCollision (9, 10);
	}
	
	// Update is called once per frame
	void Update () {
		if(isDying){
			AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
			if(stateInfo.IsName("FollowerDieReal") && stateInfo.normalizedTime >= 1){
				gameController.GameOver();
				Destroy(gameObject);
			}
		}
		else{
			dist = dist + speed;
			chunkManager.movement (dist);
			
			//		gameObject.transform.position = new Vector3 (0, gameObject.transform.position.y, gameObject.transform.position.z);
			// Move towards horizontal center of screen if not there
			float moveX = 0;
			if(Mathf.Abs(gameObject.transform.position.x) > .1f){
				moveX = gameObject.transform.position.x < 0 ? walkSpeed : -walkSpeed;
			}
			rBody.velocity = new Vector2 (moveX, rBody.velocity.y);
		}
	}

	public void Launch(Vector2 launchForce){
		rBody.AddForce(launchForce);
	}

	public void Die(){
		isDying = true;
		anim.SetTrigger ("Die");
	}
}
