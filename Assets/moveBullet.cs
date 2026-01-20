using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class MoveBullet : MonoBehaviour {

float speed = 0.1f;

public GameObject explosion;

    void OnCollisionEnter2D(Collision2D collisionObj)

    {

        if (collisionObj.gameObject.name == "Earth")

        {

            Instantiate(explosion, this.transform.position, this.transform.rotation);

            Destroy(this.gameObject);

        }

    }
void OnBecameInvisible()

{

Destroy(this.gameObject);

}

void Update ()

{

this.transform.Translate(Vector3.up * speed);

}

}