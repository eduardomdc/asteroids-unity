using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;
    public float thrust = 5.0f;
    public float steering = 220.0f;

    public Rigidbody2D prefabLaser;
    public float maxVelocity = 10.0f;
    public float laserSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Rigidbody2D laserBeam = Instantiate(
                prefabLaser,
                playerRigidBody.position,
                Quaternion.Euler(0f, 0f, playerRigidBody.rotation)
            );

            laserBeam.velocity = transform.up * laserSpeed;
        }
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
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow)){
            playerRigidBody.AddForce(transform.up * thrust, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            playerRigidBody.rotation += steering * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow)){
            playerRigidBody.rotation -= steering * Time.deltaTime;
        }
        if (playerRigidBody.velocity.magnitude > maxVelocity){
            playerRigidBody.velocity = Vector2.ClampMagnitude(
                playerRigidBody.velocity,
                maxVelocity
            );
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}
