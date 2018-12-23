using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour {

    public float verticalSpeed = 2f;
    public float distance = 3f;
    float origin;
    float end;
    // Use this for initialization
    void Start () {
        origin = transform.position.y;
        end = transform.position.y + distance;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y >= end) {
            verticalSpeed *= -1f;
        }
        if (transform.position.y < origin) {
            verticalSpeed *= -1f;
        }

        transform.Translate(Vector3.up * Time.deltaTime * verticalSpeed);
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Thwomp" || col.gameObject.tag == "Enemy"){
            col.transform.parent = this.transform;
        }
    }
 
    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Thwomp" || col.gameObject.tag == "Enemy"){
             col.transform.parent = null;
        }
    }
}
