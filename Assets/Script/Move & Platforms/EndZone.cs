using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            player.GetComponent<Player>().SetEndStage(true);
        }
    }
}
