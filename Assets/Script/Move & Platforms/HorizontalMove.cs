using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour {

    public float horizontalSpeed = 2f;
    public float distance = 5f;
    float origin;
    float end;
    
    // Use this for initialization
    void Start () {
        origin = transform.position.x;
        end = transform.position.x - distance;
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < end) {
            horizontalSpeed *= -1f;
        }
        if (transform.position.x > origin) {
            horizontalSpeed *= -1f;
        }

        transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Thwomp" || col.gameObject.tag == "Enemy"){
            col.transform.parent = this.transform;
        }
    }
 
    void OnTriggerExit(Collider col){
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Thwomp" || col.gameObject.tag == "Enemy") {
             col.transform.parent = null;
        }
    }
}
