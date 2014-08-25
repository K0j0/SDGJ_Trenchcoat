using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D other){
		print ("Make enemy deadly");
		if(other.gameObject.tag == "Enemy"){
			EnemyScript enemy = other.GetComponent<EnemyScript>();
			enemy.deadly = true;
		}
	}
}
