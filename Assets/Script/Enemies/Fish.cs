using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

    GameObject player;
    public float speed = 3f;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindWithTag("Player");
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    /*  fish bounces back if it collides with player
    void OnTriggerEnter (Collider col) {
        if (col.gameObject.tag == "Player") {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position = transform.position - direction*15;
        }
    }*/
}
