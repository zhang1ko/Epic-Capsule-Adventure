using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

		
	// Update is called once per frame
	void OnTriggerExit(Collider col) {
        Destroy(col.gameObject);
    }
}
