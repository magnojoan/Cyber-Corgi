using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    Transform trans;
    float delta;
    float speed;

	void Start () 
    {
        trans = transform;
        speed = 4;
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
		Spawner.score++;
		Spawner.playerPoints.text = Spawner.score.ToString();

        /*Destroy(other.gameObject);
        switch (other.tag)
        {
            case "Player":
                Time.timeScale = 0;
                break;
        }*/

    }

}
