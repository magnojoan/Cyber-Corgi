using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    Transform trans;
    float delta;
    float speed;
	void Start () {
        trans = transform;
        speed = 4;
	}
	
	void FixedUpdate () {
        delta = Time.deltaTime;
        trans.Translate(Vector3.forward * speed * delta);
        if (trans.position.y > 10)
        {
            SetPosition();
        }
	}

    void SetPosition()
    {
        trans.position = new Vector3(0, -10, 1);
    }
}
