using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralStage3 : MonoBehaviour {

	public GameObject platformA;    // normal platform
    public GameObject platformB;    // horizontalMove platform
    public GameObject platformC;    // verticalMove platform
    public EndZone endPlatform;

    public Coin gold;
    public GameObject starPowerup;
    public GameObject laserPowerup;
    public GameObject teleportPowerup;
    public GameObject jumpPowerup;
    public GameObject healthPowerup;

                        // Enemies
    public GameObject walker;
    public GameObject monkey;
    public GameObject thwomp;
    public GameObject mage;

    public GameObject player;

    public float chance;    //platform Chance
    public float objectChance;
    public float powerupChance;
    public float enemyChance;
    public int objectCount = 0;
    public int enemyCount = 0;
    public float levelSize = 1;
    public float xPos = 20;

    public int platformCount = 0;
    public int normalCount = 0;
    public int horizontalCount = 0;
    public int verticalCount = 0;
    public int endCount = 0;

    public float totalDistance = 0;
    public float sectionSize = 10f;

    // Use this for initialization
    void Start () {
        objectCount = 0;
        enemyCount = 0;
        levelSize = 1;
        xPos = 22;
        totalDistance = 0;
        sectionSize = 10f;

        normalCount = 0;
        horizontalCount = 0;
        verticalCount = 0;

        if (player.transform.position.x >= (totalDistance) && levelSize <= 10) {
            totalDistance += sectionSize;

            chance = Random.value;
            if (chance < 0.6 && normalCount <= 0) { //normal platform generation
                GameObject A = Instantiate(platformA, new Vector3(xPos, 0, 0), Quaternion.identity);

                while (objectCount < 5) {
                    objectChance = Random.value;
                    Vector3 location = new Vector3(xPos - 2 + objectCount, 1f, 0);

                    if (objectChance < 0.55) {   //coin generation
                        Coin coin = Instantiate(gold, location, Quaternion.identity) as Coin;
                        coin.transform.parent = A.transform;
                        objectCount++;
                    }
                    else if (objectChance >= 0.55 && objectChance < 0.6) { //powerup generation
                        powerupChance = Random.value;

                        if (powerupChance < 0.2) {
                            GameObject star = Instantiate(starPowerup, location, Quaternion.identity);
                            star.transform.parent = A.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.2 && powerupChance < 0.4) {
                            GameObject laser = Instantiate(laserPowerup, location, Quaternion.identity);
                            laser.transform.parent = A.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.4 && powerupChance < 0.8) {
                            GameObject teleport = Instantiate(teleportPowerup, location, Quaternion.identity);
                            teleport.transform.parent = A.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.6 && powerupChance < 0.8) {
                            GameObject jump = Instantiate(jumpPowerup, location, Quaternion.identity);
                            jump.transform.parent = A.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.8) {
                            GameObject health = Instantiate(healthPowerup, location, Quaternion.identity);
                            health.transform.parent = A.transform;
                            objectCount++;
                        }
                    }
                    else if (objectChance >= 0.6 && objectChance < 0.8 && enemyCount <= 0) {     //enemy generation
                        enemyChance = Random.value;

                        if (enemyChance < 0.25) {
                            GameObject walk = Instantiate(walker, new Vector3(xPos - 2 + objectCount, 1.5f, 0), Quaternion.identity);
                            walk.transform.parent = A.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.25 && enemyChance < 0.5) {
                            GameObject mon = Instantiate(monkey, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            mon.transform.parent = A.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.5 && enemyChance < 0.75) {
                            GameObject thwo = Instantiate(thwomp, new Vector3(xPos - 2 + objectCount, 5.5f, 0), Quaternion.identity);
                            thwo.transform.parent = A.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.75) {
                            GameObject m = Instantiate(mage, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            m.transform.parent = A.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                    }
                    else if (objectChance >= 0.8) { //do nothing
                        objectCount++;
                    }
                }
                enemyCount = 0;
                objectCount = 0;
                horizontalCount = 0;
                verticalCount = 0;
                xPos = xPos + 20 + 2;   // current xPOs, (length of normal section)


                totalDistance += sectionSize;
                sectionSize = totalDistance - xPos;
                levelSize++;
            } else if (chance >= 0.6 && chance < 0.8 && horizontalCount <= 0) {  //horizontalMove platform generation
                GameObject B = Instantiate(platformB, new Vector3(xPos, 0, 0), Quaternion.identity) as GameObject;
                platformCount++;

                while (objectCount < 5) {
                    objectChance = Random.value;
                    Vector3 location = new Vector3(xPos - 2 + objectCount, 1f, 0);

                    if (objectChance < 0.55) {   //coin generation
                        Coin coin = Instantiate(gold, location, Quaternion.identity) as Coin;
                        coin.transform.parent = B.transform;
                        objectCount++;
                    }
                    else if (objectChance >= 0.55 && objectChance < 0.6) { //powerup generation
                        powerupChance = Random.value;

                        if (powerupChance < 0.2) {
                            GameObject star = Instantiate(starPowerup, location, Quaternion.identity);
                            star.transform.parent = B.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.2 && powerupChance < 0.4) {
                            GameObject laser = Instantiate(laserPowerup, location, Quaternion.identity);
                            laser.transform.parent = B.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.4 && powerupChance < 0.8) {
                            GameObject teleport = Instantiate(teleportPowerup, location, Quaternion.identity);
                            teleport.transform.parent = B.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.6 && powerupChance < 0.8) {
                            GameObject jump = Instantiate(jumpPowerup, location, Quaternion.identity);
                            jump.transform.parent = B.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.8) {
                            GameObject health = Instantiate(healthPowerup, location, Quaternion.identity);
                            health.transform.parent = B.transform;
                            objectCount++;
                        }
                    }
                    else if (objectChance >= 0.6 && objectChance < 0.8 && enemyCount <= 0) {     //enemy generation
                        enemyChance = Random.value;

                        if (enemyChance < 0.2) {
                            GameObject walk = Instantiate(walker, new Vector3(xPos - 2 + objectCount, 1.5f, 0), Quaternion.identity);
                            walk.transform.parent = B.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.25 && enemyChance < 0.5) {
                            GameObject mon = Instantiate(monkey, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            mon.transform.parent = B.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.5 && enemyChance < 0.75) {
                            GameObject thwo = Instantiate(thwomp, new Vector3(xPos - 2 + objectCount, 5.5f, 0), Quaternion.identity);
                            thwo.transform.parent = B.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.75) {
                            GameObject m = Instantiate(mage, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            m.transform.parent = B.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                    }
                    else if (objectChance >= 0.8) { //do nothing
                        objectCount++;
                    }
                }
                enemyCount = 0;
                objectCount = 0;
                horizontalCount++;
                normalCount = 0;
                xPos = xPos + 20 - 2;   // current xPOs, (length of normal section) negative distance for horizontalPlatform

                totalDistance += sectionSize;
                sectionSize = totalDistance - xPos;
                levelSize++;
            } else if (chance >= 0.8 && chance < 1.0 && verticalCount <= 0) {  //verticalMove platform generation
                GameObject C = Instantiate(platformC, new Vector3(xPos, 0, 0), Quaternion.identity);
                platformCount++;
                
                while (objectCount < 5) {
                    objectChance = Random.value;
                    Vector3 location = new Vector3(xPos - 2 + objectCount, 1f, 0);

                    if (objectChance < 0.55) {   //coin generation
                        Coin coin = Instantiate(gold, location, Quaternion.identity) as Coin;
                        coin.transform.parent = C.transform;
                        objectCount++;
                    }
                    else if (objectChance >= 0.55 && objectChance < 0.6) { //powerup generation
                        powerupChance = Random.value;

                        if (powerupChance < 0.2) {
                            GameObject star = Instantiate(starPowerup, location, Quaternion.identity);
                            star.transform.parent = C.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.2 && powerupChance < 0.4) {
                            GameObject laser = Instantiate(laserPowerup, location, Quaternion.identity);
                            laser.transform.parent = C.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.4 && powerupChance < 0.8) {
                            GameObject teleport = Instantiate(teleportPowerup, location, Quaternion.identity);
                            teleport.transform.parent = C.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.6 && powerupChance < 0.8) {
                            GameObject jump = Instantiate(jumpPowerup, location, Quaternion.identity);
                            jump.transform.parent = C.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.8) {
                            GameObject health = Instantiate(healthPowerup, location, Quaternion.identity);
                            health.transform.parent = C.transform;
                            objectCount++;
                        }
                    }
                    else if (objectChance >= 0.6 && objectChance < 0.8 && enemyCount <= 0) {     //enemy generation
                        enemyChance = Random.value;

                        if (enemyChance < 0.2) {
                            GameObject walk = Instantiate(walker, new Vector3(xPos - 2 + objectCount, 1.5f, 0), Quaternion.identity);
                            walk.transform.parent = C.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.25 && enemyChance < 0.5) {
                            GameObject mon = Instantiate(monkey, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            mon.transform.parent = C.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.5 && enemyChance < 0.75) {
                            GameObject thwo = Instantiate(thwomp, new Vector3(xPos - 2 + objectCount, 5.5f, 0), Quaternion.identity);
                            thwo.transform.parent = C.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.75) {
                            GameObject m = Instantiate(mage, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            m.transform.parent = C.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                    }
                    else if (objectChance >= 0.8) { //do nothing
                        objectCount++;
                    }
                }
                enemyCount = 0;
                objectCount = 0;
                verticalCount++;
                normalCount = 0;
                xPos = xPos + 20 + 2;   // current xPOs, (length of normal section), space between section
                    
                totalDistance += sectionSize;
                levelSize++;
            }
        }
}
	
	// Update is called once per frame
	void Update () {

        if (player.transform.position.x >= (totalDistance + (sectionSize / 2)) && levelSize <= 10) {
            totalDistance += sectionSize;

            chance = Random.value;
            if (chance < 0.6 && normalCount <= 0) { //normal platform generation
                GameObject A = Instantiate(platformA, new Vector3(xPos, 0, 0), Quaternion.identity);

                while (objectCount < 5) {
                    objectChance = Random.value;
                    Vector3 location = new Vector3(xPos - 2 + objectCount, 1f, 0);

                    if (objectChance < 0.55) {   //coin generation
                        Coin coin = Instantiate(gold, location, Quaternion.identity) as Coin;
                        coin.transform.parent = A.transform;
                        objectCount++;
                    }
                    else if (objectChance >= 0.55 && objectChance < 0.6) { //powerup generation
                        powerupChance = Random.value;

                        if (powerupChance < 0.2) {
                            GameObject star = Instantiate(starPowerup, location, Quaternion.identity);
                            star.transform.parent = A.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.2 && powerupChance < 0.4) {
                            GameObject laser = Instantiate(laserPowerup, location, Quaternion.identity);
                            laser.transform.parent = A.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.4 && powerupChance < 0.8) {
                            GameObject teleport = Instantiate(teleportPowerup, location, Quaternion.identity);
                            teleport.transform.parent = A.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.6 && powerupChance < 0.8) {
                            GameObject jump = Instantiate(jumpPowerup, location, Quaternion.identity);
                            jump.transform.parent = A.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.8) {
                            GameObject health = Instantiate(healthPowerup, location, Quaternion.identity);
                            health.transform.parent = A.transform;
                            objectCount++;
                        }
                    }
                    else if (objectChance >= 0.6 && objectChance < 0.8 && enemyCount <= 0) {     //enemy generation
                        enemyChance = Random.value;

                        if (enemyChance < 0.25) {
                            GameObject walk = Instantiate(walker, new Vector3(xPos - 2 + objectCount, 1.5f, 0), Quaternion.identity);
                            walk.transform.parent = A.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.25 && enemyChance < 0.5) {
                            GameObject mon = Instantiate(monkey, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            mon.transform.parent = A.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.5 && enemyChance < 0.75) {
                            GameObject thwo = Instantiate(thwomp, new Vector3(xPos - 2 + objectCount, 5.5f, 0), Quaternion.identity);
                            thwo.transform.parent = A.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.75) {
                            GameObject m = Instantiate(mage, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            m.transform.parent = A.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                    }
                    else if (objectChance >= 0.8) { //do nothing
                        objectCount++;
                    }
                }
                enemyCount = 0;
                objectCount = 0;
                horizontalCount = 0;
                verticalCount = 0;
                xPos = xPos + 20 + 2;   // current xPOs, (length of normal section)


                totalDistance += sectionSize;
                sectionSize = totalDistance - xPos;
                levelSize++;
            } else if (chance >= 0.6 && chance < 0.8 && horizontalCount <= 0) {  //horizontalMove platform generation
                GameObject B = Instantiate(platformB, new Vector3(xPos, 0, 0), Quaternion.identity) as GameObject;
                platformCount++;

                while (objectCount < 5) {
                    objectChance = Random.value;
                    Vector3 location = new Vector3(xPos - 2 + objectCount, 1f, 0);

                    if (objectChance < 0.55) {   //coin generation
                        Coin coin = Instantiate(gold, location, Quaternion.identity) as Coin;
                        coin.transform.parent = B.transform;
                        objectCount++;
                    }
                    else if (objectChance >= 0.55 && objectChance < 0.6) { //powerup generation
                        powerupChance = Random.value;

                        if (powerupChance < 0.2) {
                            GameObject star = Instantiate(starPowerup, location, Quaternion.identity);
                            star.transform.parent = B.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.2 && powerupChance < 0.4) {
                            GameObject laser = Instantiate(laserPowerup, location, Quaternion.identity);
                            laser.transform.parent = B.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.4 && powerupChance < 0.8) {
                            GameObject teleport = Instantiate(teleportPowerup, location, Quaternion.identity);
                            teleport.transform.parent = B.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.6 && powerupChance < 0.8) {
                            GameObject jump = Instantiate(jumpPowerup, location, Quaternion.identity);
                            jump.transform.parent = B.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.8) {
                            GameObject health = Instantiate(healthPowerup, location, Quaternion.identity);
                            health.transform.parent = B.transform;
                            objectCount++;
                        }
                    }
                    else if (objectChance >= 0.6 && objectChance < 0.8 && enemyCount <= 0) {     //enemy generation
                        enemyChance = Random.value;

                        if (enemyChance < 0.2) {
                            GameObject walk = Instantiate(walker, new Vector3(xPos - 2 + objectCount, 1.5f, 0), Quaternion.identity);
                            walk.transform.parent = B.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.25 && enemyChance < 0.5) {
                            GameObject mon = Instantiate(monkey, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            mon.transform.parent = B.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.5 && enemyChance < 0.75) {
                            GameObject thwo = Instantiate(thwomp, new Vector3(xPos - 2 + objectCount, 5.5f, 0), Quaternion.identity);
                            thwo.transform.parent = B.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.75) {
                            GameObject m = Instantiate(mage, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            m.transform.parent = B.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                    }
                    else if (objectChance >= 0.8) { //do nothing
                        objectCount++;
                    }
                }
                enemyCount = 0;
                objectCount = 0;
                horizontalCount++;
                normalCount = 0;
                xPos = xPos + 20 - 2;   // current xPOs, (length of normal section) negative distance for horizontalPlatform

                totalDistance += sectionSize;
                sectionSize = totalDistance - xPos;
                levelSize++;
            } else if (chance >= 0.8 && chance < 1.0 && verticalCount <= 0) {  //verticalMove platform generation
                GameObject C = Instantiate(platformC, new Vector3(xPos, 0, 0), Quaternion.identity);
                platformCount++;
                
                while (objectCount < 5) {
                    objectChance = Random.value;
                    Vector3 location = new Vector3(xPos - 2 + objectCount, 1f, 0);

                    if (objectChance < 0.55) {   //coin generation
                        Coin coin = Instantiate(gold, location, Quaternion.identity) as Coin;
                        coin.transform.parent = C.transform;
                        objectCount++;
                    }
                    else if (objectChance >= 0.55 && objectChance < 0.6) { //powerup generation
                        powerupChance = Random.value;

                        if (powerupChance < 0.2) {
                            GameObject star = Instantiate(starPowerup, location, Quaternion.identity);
                            star.transform.parent = C.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.2 && powerupChance < 0.4) {
                            GameObject laser = Instantiate(laserPowerup, location, Quaternion.identity);
                            laser.transform.parent = C.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.4 && powerupChance < 0.8) {
                            GameObject teleport = Instantiate(teleportPowerup, location, Quaternion.identity);
                            teleport.transform.parent = C.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.6 && powerupChance < 0.8) {
                            GameObject jump = Instantiate(jumpPowerup, location, Quaternion.identity);
                            jump.transform.parent = C.transform;
                            objectCount++;
                        }
                        else if (powerupChance >= 0.8) {
                            GameObject health = Instantiate(healthPowerup, location, Quaternion.identity);
                            health.transform.parent = C.transform;
                            objectCount++;
                        }
                    }
                    else if (objectChance >= 0.6 && objectChance < 0.8 && enemyCount <= 0) {     //enemy generation
                        enemyChance = Random.value;

                        if (enemyChance < 0.2) {
                            GameObject walk = Instantiate(walker, new Vector3(xPos - 2 + objectCount, 1.5f, 0), Quaternion.identity);
                            walk.transform.parent = C.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.25 && enemyChance < 0.5) {
                            GameObject mon = Instantiate(monkey, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            mon.transform.parent = C.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.5 && enemyChance < 0.75) {
                            GameObject thwo = Instantiate(thwomp, new Vector3(xPos - 2 + objectCount, 5.5f, 0), Quaternion.identity);
                            thwo.transform.parent = C.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                        else if (enemyChance >= 0.75) {
                            GameObject m = Instantiate(mage, new Vector3(xPos - 2 + objectCount, 0, 0), Quaternion.identity);
                            m.transform.parent = C.transform;
                            objectCount++;
                            enemyCount++;
                            break;
                        }
                    }
                    else if (objectChance >= 0.8) { //do nothing
                        objectCount++;
                    }
                }
                enemyCount = 0;
                objectCount = 0;
                verticalCount++;
                normalCount = 0;
                xPos = xPos + 20 + 2;   // current xPOs, (length of normal section), space between section
                    
                totalDistance += sectionSize;
                levelSize++;
            }
        }
        
        if (levelSize > 10 && endCount <= 0) {
            Instantiate(endPlatform, new Vector3(xPos, 0, 0), Quaternion.identity);
            endCount++;
        }
	}
}
