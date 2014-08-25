using UnityEngine;
using System.Collections;

public class Chunk : MonoBehaviour {
	GameObject platform;
	private bool _initialized = false;

	public void Init(string type){
		_initialized = true;

		string assetPath = "box";
		switch(type){
		case "b":
			assetPath = "hell_screens2/Hell beggining screen 2";
			break;
		case "c":
			int r1 = Mathf.CeilToInt( Random.Range ( 0.0f, 5.0f ) );
			switch( r1 ) {
				case 0:
				case 1:
					assetPath = "hell_screens2/Hell Screen 1Ver3";
					break;
				case 2:
					assetPath = "hell_screens2/HellSet_1AVer3";
					break;
				case 3:
					assetPath = "hell_screens2/HellSet_1BVer3";
					break;
				case 4:
					assetPath = "hell_screens2/HellSet_2A_Ver3";
					break;
				case 5:
					assetPath = "hell_screens2/HellSet_2B_Ver3";
					break;
			}
			break;
		case "d":
			int r2= Mathf.CeilToInt( Random.Range ( 0.0f, 6.0f ) );
			switch( r2 ) {
				case 0:
				case 1:
					assetPath = "purg_screens/Purg_Level_1";
					break;
				case 2:
					assetPath = "purg_screens/Purg_Level_2";
					break;
				case 3:
					assetPath = "purg_screens/Purg_Level_3";
					break;
				case 4:
					assetPath = "purg_screens/Purg_Level_4";
					break;
				case 5:
					assetPath = "purg_screens/Purg_Level_5";
					break;
				case 6:
					assetPath = "purg_screens/Purg_Level_6";
					break;
			}
			break;
		case "e":
			int r3= Mathf.CeilToInt( Random.Range ( 0.0f, 7.0f ) );
			switch( r3 ) {
			case 0:
			case 1:
				assetPath = "earth_screens/Earth-Level1";
				break;
			case 2:
				assetPath = "earth_screens/Earth-Level2";
				break;
			case 3:
				assetPath = "earth_screens/Earth-Level3";
				break;
			case 4:
				assetPath = "earth_screens/Earth-Level4";
				break;
			case 5:
				assetPath = "earth_screens/Earth-Level5";
				break;
			case 6:
				assetPath = "earth_screens/Earth-Level6";
				break;
			case 7:
				assetPath = "earth_screens/Earth-Level7";
				break;
			}
			break;
		default:
			int rng2= Mathf.CeilToInt( Random.Range ( 0.0f, 0.06f ) );
			switch( rng2 ) {
			case 0:
			case 1:
				assetPath = "hell_screens2/Hell,Generic,1";
				break;
			case 2:
				assetPath = "hell_screens2/Hell Screen 1Ver3";
				break;
			case 3:
				assetPath = "hell_screens2/HellSet_1AVer3";
				break;
			case 4:
				assetPath = "hell_screens2/HellSet_1BVer3";
				break;
			case 5:
				assetPath = "hell_screens2/HellSet_2A_Ver3";
				break;
			case 6:
				assetPath = "hell_screens2/HellSet_2B_Ver3";
				break;
			}
			break;
		}

		print (assetPath);

		platform = MonoBehaviour.Instantiate(Resources.Load(assetPath, typeof(GameObject))) as GameObject;
		platform.transform.parent = gameObject.transform;
		platform.transform.localPosition = Vector3.zero;

		platform.layer = LayerMask.NameToLayer("Ground");
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!_initialized) {
			return;
		}
	}
}
