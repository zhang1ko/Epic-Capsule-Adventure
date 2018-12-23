using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlinkingText : MonoBehaviour {

    Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        StartCoroutine(Blink());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(1);
        }
	}

    IEnumerator Blink() {
        while (true) {
            switch (text.color.a.ToString())
            {
                case "0":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                    yield return new WaitForSeconds(0.3f);
                    break;
                case "1":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                    yield return new WaitForSeconds(0.3f);
                    break;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
