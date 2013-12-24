using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
	
	Transform trans;
	float delta;
	float speed;
	int scoreToAdd;
	
	void Start () 
	{
		trans = transform;
		speed = 2.7f;
		scoreToAdd = 5;
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
		if (Spawner.powerup2Activated) {
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
