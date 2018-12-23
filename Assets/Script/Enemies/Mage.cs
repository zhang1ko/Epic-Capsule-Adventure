using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mage : MonoBehaviour {

    public GameObject explosionPrefab;
    public ParticleSystem explode;
    public SphereCollider spCol;
    GameObject player;
    Vector3 playerPos;

    public float distance;
    public Vector3 direction;
    bool tel;
    float timer = 5.0f;

    private Renderer rend;
    
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
        rend = transform.GetComponent<Renderer>();
        spCol = GetComponent<SphereCollider>();
    }
	
	// Update is called once per frame
	void Update () {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        timer -= Time.deltaTime;

        if (timer <= 0) {
            transform.position = playerPos;
            spCol.enabled = false;
            Color c = rend.material.color;
            c.a = 0.3f;
            rend.material.color = c;

            tel = true;
            timer = 6f;
        }
        
        if (tel) {
            StartCoroutine(Explosion());
            tel = false;
        }
    }
    
    IEnumerator Explosion() {
        yield return new WaitForSeconds(1f);
        GameObject explo= Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explo, 1f);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3.0f);

        int i = 0;
        while (i < hitColliders.Length) {
			if (hitColliders [i].gameObject.tag == "Player") {

				if (hitColliders [i].GetComponent<Player>().invincible == false) {
					distance = Vector3.Distance(hitColliders [i].transform.position, transform.position);
					Mathf.Abs (distance);
					//damage
					hitColliders [i].GetComponent<Player>().health -= ((3f - distance) / 3f) * 50;
                    //force
                    direction = hitColliders[i].transform.position - transform.position;
					hitColliders[i].GetComponent<Rigidbody>().AddForce(direction * -200);

				}
			}
			i++;
		}

        rend.material.color = Color.red;
        spCol.enabled = true;
    }
}
