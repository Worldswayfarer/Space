using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    public int speed = 8;

    public ObjectQueue Asteroids;
    public ObjectQueue Lasers;

    public IntVariable ScoreValue;
    public GameEvent ScoreEvent;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _rigidbody.velocity = speed * Vector2.down;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            ScorePoint();

            Lasers.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
            
            Asteroids.Enqueue(gameObject);
            gameObject.SetActive(false);
            
        }
    }

    private void ScorePoint()
    {
        ScoreValue.RuntimeValue ++;
        ScoreEvent.Raise();
    }
}
