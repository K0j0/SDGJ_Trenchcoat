using UnityEngine;
using System.Collections;

public class ChunkManager : MonoBehaviour {
	public GameObject BG1;
	public GameObject BG2;
	public GameObject BG3;
	private bool doDebug = true;

	bool firstPurg = true;
	bool firstEarh = true;

	private int createCount = 0;
	private Queue chunks = new Queue ();
	private float lastDistance;

	private Time startTime;
	public int rate_mod = 1;

	public bool spawnEnemies;

	void Start() 
	{
		chunks.Enqueue( NewChunk( "b", 0.0f ) );
		chunks.Enqueue( NewChunk( "c", 12.8f ) );
		chunks.Enqueue( NewChunk( "c", 25.6f ) );
	}

	GameObject NewEnemy(){
		GameObject enemy = MonoBehaviour.Instantiate(Resources.Load("Enemy", typeof(GameObject))) as GameObject;
		enemy.transform.parent = gameObject.transform;

		Vector3 pos = new Vector3 (Random.Range (13.0f, 14.0f), 0, 0);
		float rnd = Random.Range (-1.0f, 1.0f);
		if (rnd <= 0) {
				pos.x = Random.Range (-13.0f, -14.0f);
		}
		pos.y = Random.Range( -1.0f, 8.0f);

		enemy.transform.position = pos;

		return enemy;
	}

	GameObject NewChunk( string chunkType, float pos )
	{
		Dbg( "pos: " + pos );
		GameObject emptyGameObj = new GameObject ();
		emptyGameObj.transform.position = new Vector3 ( pos, 0, 0 );
		Chunk chunk = emptyGameObj.AddComponent<Chunk> ();
		chunk.Init ( chunkType );// chunkType );
		createCount++;

		if(spawnEnemies){
			for (int i=1; i <= Mathf.Ceil( createCount / rate_mod ); i++) {
				NewEnemy();
			}
		}

		return emptyGameObj;
	}

	public void movement( float newDistance )
	{
		// does new distance require another chunk?
		GameObject firstChunk = chunks.Peek() as GameObject;
		if ( ( chunks.Count < 4 ) && ( firstChunk.transform.position.x < 0.1f ) ) {
			// indentify location of first chunk
			float pos = firstChunk.transform.position.x;

			// use that to find position of new chunk
			pos = pos + 25.6f;

			// create new chunk
			if ( createCount < 6 ) {
				chunks.Enqueue( NewChunk( "c", pos )  );
			} else if (createCount < 11) {
				chunks.Enqueue( NewChunk( "d", pos )  );
				if(firstPurg){
					firstPurg = false;
					ChangeBG (2);
				}
			} else {
				chunks.Enqueue( NewChunk( "e", pos )  );
				if(firstEarh){
					firstEarh = false;
					ChangeBG (3);
				}
			}
		}

		// reposition all chunks
		float offset = newDistance - lastDistance;
		lastDistance = newDistance;
		foreach ( GameObject chunk in chunks ) {
			Vector3 old = chunk.transform.position;
			Vector3 newPos = new Vector3( (old.x - offset), 0, 0 );
			chunk.transform.position = newPos;
		}

		// remove unneeded chunks
		if ( firstChunk.transform.position.x < -13.0 ) {
			chunks.Dequeue();
			GameObject.Destroy( firstChunk );
		}
	}

	void ChangeBG(int value){
		if(value == 2){
			BG1.SetActive(false);
			BG2.SetActive(true);
			BG3.SetActive(false);
		}
		else if(value == 3){
			BG1.SetActive(false);
			BG2.SetActive(false);
			BG3.SetActive(true);
		}
	}

	void Dbg( string msg )
	{
		if ( doDebug ) {
			Debug.Log( msg );
		}
	}	
}
