using UnityEngine;
using System.Collections;

public class Powerup3 : MonoBehaviour {
	
	Transform trans;
	float delta;
	float speed;
	public static int POWERUP_TIMER = 10;
	
	void Start () 
	{
		trans = transform;
		speed = 2.5f;
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
		Spawner.powerup3Activated = true;
		StartCoroutine("ActivateTimer");
		/*Destroy(other.gameObject);
        switch (other.tag)
        {
            case "Player":
                Time.timeScale = 0;
                break;
        }*/
		
	}
	IEnumerator ActivateTimer() {
		yield return new WaitForSeconds (POWERUP_TIMER);
		Spawner.powerup3Activated = false;
	}

	
}
