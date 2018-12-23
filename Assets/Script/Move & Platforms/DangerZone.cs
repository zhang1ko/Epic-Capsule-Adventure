using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DangerZone : MonoBehaviour {

    public Transform player;
    // Use this for initialization
    void Start () {

    }

    void LateUpdate () {
        if (player.position.x > transform.position.x) {
            transform.position = new Vector3(player.position.x, -8, 0);
        }
    }
	
	void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
