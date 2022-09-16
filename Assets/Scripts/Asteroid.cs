using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Rigidbody2D selfRigidBody;
    public float maxVelocity = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 direction = Random.insideUnitCircle;
        direction *= maxVelocity;
        selfRigidBody.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 10f){
            float newPosX = transform.position.x * -1 + 0.1f;
            transform.position = new Vector2(newPosX, transform.position.y);
        }
        else if (transform.position.x < - 10f){
            float newPosX = transform.position.x * -1 - 0.1f;
            transform.position = new Vector2(newPosX, transform.position.y);
        }
        else if (transform.position.y > 6f){
            float newPosY = transform.position.y * -1 + 0.1f;
            transform.position = new Vector2(transform.position.x, newPosY);
        }
        else if (transform.position.y < -6f){
            float newPosY = transform.position.y * -1 - 0.1f;
            transform.position = new Vector2(transform.position.x, newPosY);
        }
    }

    void OnTriggerEnter2D(Collider2D body){
        Destroy(gameObject);
        Destroy(body.gameObject);
    }
}
