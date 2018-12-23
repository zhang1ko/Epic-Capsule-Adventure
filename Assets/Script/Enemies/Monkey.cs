using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour {

    public GameObject rockPrefab;
    public GameObject player;
    public Vector3 startPos;
    public float fireRate;
    public float nextFire;
    // Use this for initialization
    void Start () {
        fireRate = 3f;
        nextFire = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        CheckToFire();
	}

    void CheckToFire() {
        if (Time.time > nextFire && Mathf.Abs(player.transform.position.x - transform.position.x) <= 10) {
            startPos = new Vector3(transform.position.x, transform.position.y + 1.5f, 0);
            GameObject rock = Instantiate(rockPrefab, transform.position, transform.rotation);
            Physics.IgnoreCollision(rock.GetComponent<Collider>(), GetComponent<Collider>());
            nextFire = Time.time + fireRate;
        }
    }
}
