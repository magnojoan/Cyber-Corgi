using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    int secondsToWait;
	int secondsToWait2;
	int secondsToWait3;

    GameObject enemy;
	GameObject enemy2;
	GameObject enemy3;

	GameObject powerup2;
	GameObject powerup3;

	public static bool powerup2Activated;
	public static bool powerup3Activated;

	public static int score;
	public static GUIText playerPoints;
	
	GUITexture powerUpIndicator2;
	GUITexture powerUpIndicator3;

		
	void Start () {
        enemy = Resources.Load("Prefabs/Enemy") as GameObject;
		enemy2 = Resources.Load ("Prefabs/Enemy2") as GameObject;
		enemy3 = Resources.Load ("Prefabs/Enemy3") as GameObject;

		powerup2 = Resources.Load ("Prefabs/Powerup2") as GameObject;
		powerup3 = Resources.Load ("Prefabs/Powerup3") as GameObject;
		//Seconds to wait till new enemy instantiates
		secondsToWait = 6;
		secondsToWait2 = 8;
		secondsToWait3 = 10;

		powerup2Activated = false;
		powerup3Activated = false;

		score = 0;
		playerPoints = GameObject.Find ("playerPoints").guiText;
		playerPoints.text = "0";
		powerUpIndicator2 = GameObject.Find("powerUpIndicator2").guiTexture;
		powerUpIndicator3 = GameObject.Find("powerUpIndicator3").guiTexture;


		StartCoroutine("SpawnEnemy");
		StartCoroutine("DistancePoints");
		StartCoroutine ("SpawnPowerupCoroutine2");
	}

	void Update() {
		if (powerup2Activated) {
			powerUpIndicator2.enabled = true;
		} else { 
			powerUpIndicator2.enabled = false;
		}
		if (powerup3Activated) {
			powerUpIndicator3.enabled = true;
		} else { 
			powerUpIndicator3.enabled = false;
		}
	}

	//Gain points while timer runs
	IEnumerator DistancePoints() {
		yield return new WaitForSeconds (1);
		score++;
		playerPoints.text = score.ToString ();
		StartCoroutine ("DistancePoints");
	}

	//Activate timer for power up 2, 20 seconds only
	/*
	public static IEnumerator ActivatePowerupTimer2() {
		powerup2Activated = true;
		yield return new WaitForSeconds (POWERUP_TIMER);
		powerup2Activated = false;
	}

	public static IEnumerator ActivatePowerupTimer3() {
		powerup3Activated = true;
		yield return new WaitForSeconds (POWERUP_TIMER);
		powerup3Activated = false;
	}*/

	//Spawn a powerup2 after 30 seconds and initiate spawning enemy2s
	IEnumerator SpawnPowerupCoroutine2() {
		yield return new WaitForSeconds (30);
		SpawnPowerup2 ();
		StartCoroutine ("SpawnEnemy2");
		StartCoroutine ("SpawnPowerupCoroutine3");
		}

	IEnumerator SpawnPowerupCoroutine3() {
		yield return new WaitForSeconds (45);
		SpawnPowerup3 ();
		StartCoroutine ("SpawnEnemy3");
	}

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(secondsToWait);
        GameObject e1 = Instantiate(enemy) as GameObject;
        e1.transform.position = new Vector3(Random.Range(-2f, 2f), 4, 0);
		StartCoroutine("SpawnEnemy");
    }

	IEnumerator SpawnEnemy2() {
		GameObject e2 = Instantiate(enemy2) as GameObject;
		e2.transform.position = new Vector3(Random.Range(-2f, 2f), 4, 0);	
		yield return new WaitForSeconds (secondsToWait2);
		StartCoroutine ("SpawnEnemy2");
	}

	IEnumerator SpawnEnemy3() {
		GameObject e3 = Instantiate(enemy3) as GameObject;
		e3.transform.position = new Vector3(Random.Range(-2f, 2f), 4, 0);	
		yield return new WaitForSeconds (secondsToWait3);
		StartCoroutine ("SpawnEnemy3");
	}

	void SpawnPowerup2() {
		GameObject pu2 = Instantiate(powerup2) as GameObject;
		pu2.transform.position = new Vector3(Random.Range(-2f, 2f), 4, 0);	
	}

	void SpawnPowerup3() {
		GameObject pu3 = Instantiate(powerup3) as GameObject;
		pu3.transform.position = new Vector3(Random.Range (-2f, 2f), 4, 0);
	}
                        

}
