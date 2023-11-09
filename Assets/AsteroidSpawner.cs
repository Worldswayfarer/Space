using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject Asteroid;
    public ObjectQueue Asteroids;

    void Start()
    {
        for(int i = 0; i<20; i++)
        {
            GameObject asteroidObject = Instantiate(Asteroid, transform);
            asteroidObject.SetActive(false);
            Asteroids.Enqueue(asteroidObject);
        }
        InvokeRepeating("SpawnAsteroid", 1, 0.1f);
    }

    void SpawnAsteroid()
    {
        GameObject asteroidObject = Asteroids.Dequeue();
        if(!asteroidObject) { return; }
        asteroidObject.transform.position = new Vector2(Random.Range(-10, 10), 6);
        asteroidObject.SetActive(true);
    }
}
