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
        
    }

    void OnTriggerEnter2D(Collider2D body){
        Destroy(gameObject);
        Destroy(body.gameObject);
    }
}
