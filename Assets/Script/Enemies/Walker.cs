using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

    GameObject[] coins;
    public float speed = 1f;
    public float distance = 5f;
    float origin;
    float end;
    // Use this for initialization
    void Start () {
        origin = transform.position.x;
        end = transform.position.x - distance;

        coins = GameObject.FindGameObjectsWithTag("coin");
        foreach (GameObject c in coins) {
            Physics.IgnoreCollision(c.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < end) {
            speed *= -1f;
        }
        if (transform.position.x > origin) {
            speed *= -1f;
        }

		transform.Translate (Vector3.right * Time.deltaTime * speed);
	}
}
