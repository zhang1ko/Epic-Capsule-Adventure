using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    GameObject player;
    Vector3 direction;
    public float speed = 30f;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        direction = (player.transform.position - transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
