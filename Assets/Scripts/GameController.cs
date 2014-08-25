using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public float defaultSpeed;

	public SoundManager soundMan;

	public GameObject title;
	public GameObject gameInfo;
	public GameObject gameOver;
	public GameObject player;
	public GameObject credits;

	AngelControl angel;
	HelperController follower;
	public GameObject escort;
	public ChunkManager chunkMan;

	public bool isStart = true;
	public bool showInfo = true;
	public bool isGameOver = false;
	public bool showCredits = true;

	bool _isGameOn = false;

	public bool isGameOn{
		get{
			return _isGameOn;
		}
	}
	

	// Use this for initialization
	void Start () {
		soundMan.PlaySound (Snd.byz);
		isStart = true;
		showInfo = true;
		angel = player.GetComponent<AngelControl> ();
		follower = escort.GetComponent<HelperController> ();
		follower.speed = 0;
		follower.anim.SetTrigger ("Walk");
		title.gameObject.SetActive (true);
	}

	void Update(){
		if(isStart && Input.anyKey){
			gameInfo.gameObject.SetActive(true);
			title.gameObject.SetActive(false);
			StartCoroutine(ShowInfoRoutine());
		}
		else if(showInfo && Input.anyKey){
			gameInfo.gameObject.SetActive(false);
			StartCoroutine(StartGame());

		}
		else if(showCredits && isGameOver && Input.anyKey){
			print ("Credits");
			showCredits = false;
			credits.SetActive(true);
			gameOver.SetActive(false);
		}
		else if(isGameOver && Input.anyKey){
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	IEnumerator ShowInfoRoutine(){
		yield return new WaitForSeconds (.5f);
		isStart = false;
	}

	IEnumerator StartGame(){
		yield return new WaitForSeconds (1f);
		follower.speed = defaultSpeed;
		showInfo = false;
		_isGameOn = true;
	}

	void OnTriggerExit2D(Collider2D other){
//		print ("LEFT");
		GameObject target = other.gameObject;
		if(target == escort){
			GameOver ();
		}
	}

	public void GameOver(){
//		print ("Game Over!!!");
		isGameOver = true;
		showInfo = true;
		_isGameOn = false;
		follower.speed = 0;
		chunkMan.spawnEnemies = false;
		gameOver.gameObject.SetActive (true);
		angel.enabled = false;
	}
}
