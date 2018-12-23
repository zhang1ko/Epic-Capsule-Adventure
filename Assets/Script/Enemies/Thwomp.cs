using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwomp : MonoBehaviour {

    GameObject player;
    Rigidbody rb;
    Vector3 startPos;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 2 && (transform.position.y >= startPos.y)) {
            rb.AddForce(Vector3.down * 50000f);
        }
    }
    /*
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ground") {
            rb.velocity = Vector3.zero;
            transform.position = Vector3.MoveTowards(transform.position, startPos, 30f * Time.deltaTime);
        }
    }*/
}
