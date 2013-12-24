using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    Transform trans;
    float delta;
    float speed;
    //GameObject projectile;
    GUITexture restartButton;
	void Start () 
    {
        trans = transform;
        speed = 6;

        //same as making projectile public and drag and dropping to script component
        //projectile = Resources.Load("Prefabs/Projectile") as GameObject;
        restartButton = GameObject.Find("restartButton").guiTexture;
	}
	
    //happens once per frame
    //60fps
	void FixedUpdate () 
    {
        delta = Time.deltaTime;
        Move();
        //Shoot();
	}

    void Move()
    {
        float direction = Input.GetAxis("Horizontal");

        //for efficiency, only check ifs when w,s,left or right is pressed
        if (direction != 0)
        {
            if (trans.position.x > -2f && trans.position.x < 2f)
            {
                trans.Translate(Input.GetAxis("Horizontal") * delta * speed, 0, 0);
            }
            else
            {
                //bounce back
                trans.position = new Vector3(trans.position.x - direction*0.6f, 2, 0);
            }
        }

    }

	/**
    void Shoot()
    {
        //left mouse button
        if (Input.GetButtonUp("Fire1"))
        {
            //create new projectile from prefab
                                        //gameobject, starting position, rotation
            GameObject p = Instantiate(projectile, trans.position, Quaternion.identity) as GameObject;

            //push instantiated projectil up
            p.rigidbody.AddForce(Vector3.up * 65792 * delta);
        }

        //CHALLENGE!
        //make it so that there is an array of projectiles and instead of instantiating new ones, simply set their positions and add forces
    }
    **/

    //called when Enemy collides with Player. See Enemy Script
    void OnDestroy()
    {
        restartButton.enabled = true;
    }



}
