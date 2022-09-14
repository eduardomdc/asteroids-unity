using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    public GameObject asteroid;
    public int asteroidsQuantity;
    // Start is called before the first frame update
    void Start()
    {
        for ( int i = 0; i < asteroidsQuantity; i++ ){
            float x = Random.Range(-7.0f, 7.0f);
            float y = Random.Range(-4f, 4f);
            Vector3 position = new Vector3(x, y, 0f);
            Instantiate(asteroid, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
