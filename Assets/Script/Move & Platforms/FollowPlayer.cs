using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    private Vector3 offset;
    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (player.position.x >= transform.position.x) {
            transform.position = player.transform.position + offset;
        }
        if (player.position.y != transform.position.y) {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + offset.y, transform.position.z);
            
        }
        //transform.position.y = player.transform.position.y;

    }
}
