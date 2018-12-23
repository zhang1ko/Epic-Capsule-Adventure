using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public GameObject endPanel;
    public bool endStage;

    public float speed = 1f;
    public float maxSpeed = 2f;
    public int maxjumps = 2;
    int jumps = 0;
    public Rigidbody rb;
    public bool grounded;

    public float health = 100f;
    public Text healthText;
    int coin = 0;
    public Text coinText;
    int enemy = 0;
    public Text enemyText;

    //powerups
    Color startColor;
    bool laser;
    LineRenderer line;
    public Vector3 mousePos;
    bool teleport;
    int teleportNum;
    Ray ray;
    RaycastHit hit;
    public bool invincible;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody>();
        endPanel.SetActive(false);
        startColor = transform.GetComponent<Renderer>().material.color;
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (endStage) {
            StartCoroutine(NextStage());
        }

        if (Input.GetMouseButtonDown(0)) {

            if (teleport == true && teleportNum > 0) {
                transform.GetComponent<Renderer>().material.color = Color.magenta;

                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.name == "Plane") {
                        mousePos = hit.point;
                        mousePos.z = 0;
                        transform.position = mousePos;
                    }
                }
                invincible = true;
                StartCoroutine(Star(2, transform.GetComponent<Renderer>().material.color));
                teleportNum -= 1;
                jumps = 0;
                grounded = true;   // resetting double jump
            }
            else if (transform.GetComponent<Renderer>().material.color==Color.magenta && teleportNum <= 0) {
                teleport = false;
                transform.GetComponent<Renderer>().material.color = startColor;
            }

            if (laser == true) {
                teleport = false;
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.collider.name == "Plane") {
                        mousePos = hit.point;
                        mousePos.z = 0;
                        RaycastHit hit2;
                        Debug.DrawRay(transform.position, mousePos * 10000f, Color.red, 1);
                        line.enabled = true;
                        line.SetPosition(1, transform.position);
                        line.SetPosition(1, mousePos * 1000);

                        StartCoroutine(LaserStop(0.5f));

                        if (Physics.Raycast(transform.position, mousePos, out hit2)) {
                            if (hit2.transform.gameObject.tag == "Enemy") {
                                Destroy(GameObject.FindWithTag("Enemy"));
                                enemy++;
                            } else if (hit2.transform.gameObject.tag == "Thwomp") {
                                Destroy(GameObject.FindWithTag("Thwomp"));
                                enemy++;
                            } else if (hit2.transform.gameObject.tag == "Rock") {
                                Destroy(GameObject.FindWithTag("Rock"));
                                enemy++;
                            }
                        }

                    }
                }
            }
        }
    }
	
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
            rb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            rb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            jump();
        }
        if (Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) {
            speed = maxSpeed;
        } else{
            speed = 15f;
        }
	}

    void LateUpdate () {
        coinText.text = "Coins : " + coin.ToString();
        enemyText.text = "Enemies : " + enemy.ToString();
        healthText.text = "Health : " + health.ToString("0.00");

        if (health <= 0) {
            PlayerDeath();
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Ground") {
            jumps = 0;
            grounded = true;
        }
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Rock") {
            Vector3 normal = (transform.position - col.transform.position).normalized;
            if (transform.position.y > (col.transform.position.y + 1) || invincible) {
                Destroy(col.gameObject);
                rb.AddForce(Vector3.up * 150);      //slight jump after jumping on enemies
                enemy++;
            } else {
                health -= 5;
                Vector3 direction = (col.transform.position - transform.position).normalized;   //bouces back when player takes damage
                rb.AddForce(direction * -150);
            }
        }
        if (col.gameObject.tag == "Thwomp" && !invincible) {
            if (transform.position.y < col.transform.position.y - 1.5) { // if Player is directly under Thwomp when colliding
                health -= 100;
            }
            else {
                health -= 5;
                Vector3 direction = (col.transform.position - transform.position).normalized;   //bouces back when player takes damage
                rb.AddForce(direction * -150);
            }
        } else if (col.gameObject.tag == "Thwomp" && invincible) {
            Destroy(col.gameObject);
        }

        //collectables and powerups
        if (col.gameObject.tag == "Coin") {
            Destroy(col.gameObject);
            coin++;
        }
        if (col.gameObject.tag == "Invincible") {
            Destroy(col.gameObject);
            StartCoroutine(Star(10, Color.green));
        }
        if (col.gameObject.tag == "Jump") {
            Destroy(col.gameObject);
            StartCoroutine(JumpBuff(10));
        }
        if (col.gameObject.tag == "Health") {
            Destroy(col.gameObject);
            StartCoroutine(HealthBuff(0.5f));
        }
        if (col.gameObject.tag == "Teleport") {
            Destroy(col.gameObject);
            teleport = true;
            teleportNum = 5;
        }
        if (col.gameObject.tag == "Laser") {
            Destroy(col.gameObject);
            StartCoroutine(LaserBuff(30));
            laser = true;
        }
    }

    IEnumerator Star(int s, Color c) {
        transform.GetComponent<Renderer>().material.color = c;
        invincible = true;
        yield return new WaitForSeconds(s);
        transform.GetComponent<Renderer>().material.color = startColor;
        invincible = false;
    }
    IEnumerator JumpBuff(int s) {
        transform.GetComponent<Renderer>().material.color = Color.blue;
        maxjumps = 10;
        yield return new WaitForSeconds(s);
        transform.GetComponent<Renderer>().material.color = startColor;
        maxjumps = 2;
    }
    IEnumerator HealthBuff(float s) {
        transform.GetComponent<Renderer>().material.color = new Color(255, 165, 0);
        if (health < 80) {
            health += 20;
        }
        else {
            health = 100;
        }
        yield return new WaitForSeconds(s);
        transform.GetComponent<Renderer>().material.color = startColor;
    }
    IEnumerator LaserBuff(int s) {
        transform.GetComponent<Renderer>().material.color = Color.red;
        
        yield return new WaitForSeconds(s);
        transform.GetComponent<Renderer>().material.color = startColor;
        laser = false;
    }
    IEnumerator LaserStop(float s) {
        yield return new WaitForSeconds(s);
        line.enabled = false;
    }

    IEnumerator NextStage() {
        endPanel.SetActive(true);
        yield return new WaitForSeconds(2f);

        int cleared = PlayerPrefs.GetInt("LevelsCleared");
        if (cleared < SceneManager.GetActiveScene().buildIndex - 1) {
            PlayerPrefs.SetInt("LevelsCleared", SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (SceneManager.GetActiveScene().buildIndex < 4) {

            Debug.Log(PlayerPrefs.GetInt("TotalCoins"));
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + coin);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else {

            Debug.Log(PlayerPrefs.GetInt("TotalCoins"));
            PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + coin);
            SceneManager.LoadScene(0);
        }
    }

    public void SetEndStage(bool b) {
        endStage = b;
    }
    void jump() {
        if (jumps < maxjumps) {
            rb.AddForce(Vector3.up * 350);
            grounded = false;
            jumps++;
        }
        else {
            
        }
    }
    void PlayerDeath() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
