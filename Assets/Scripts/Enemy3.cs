using UnityEngine;
using System.Collections;

public class Enemy3 : MonoBehaviour {
	
	Transform trans;
	float delta;
	float speed;
	int scoreToAdd;
	
	void Start () 
	{
		trans = transform;
		speed = 2.4f;
		scoreToAdd = 10;
	}
	
	
	void FixedUpdate () 
	{
		delta = Time.deltaTime;
		Move();
	}
	
	void Move()
	{
		trans.Translate(Vector3.up * delta * speed);
		if (trans.position.y > 6)
		{
			SetPosition();
		}
	}
	
	void SetPosition()
	{
		trans.position = new Vector3(Random.Range(-2f, 2f), -6, 0);
	}
	
	void OnTriggerEnter(Collider other)
	{
		SetPosition();
		if (Spawner.powerup3Activated) {
			Spawner.score += scoreToAdd;
			Spawner.playerPoints.text = Spawner.score.ToString ();
		} else {
			Destroy(other.gameObject);
			switch (other.tag)
			{
			case "Player":
				Time.timeScale = 0;
				break;
			}
		}
		
	}
	
}
