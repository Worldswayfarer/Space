using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    public IntVariable PlayerHealth;
    public GameEvent PlayerHit;
    public GameObject Laser;
    public ObjectQueue Asteroids;
    public ObjectQueue Lasers;

    private Rigidbody2D _rigidbody;

    private void Damage()
    {
        PlayerHealth.RuntimeValue -= 10;
        PlayerHit.Raise();
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject laserObject = Instantiate(Laser);
            laserObject.SetActive(false);
            Lasers.Enqueue(laserObject);
        }
    }

    private void OnMove(InputValue value)
    {
        _rigidbody.velocity = value.Get<Vector2>() * 5;
    }

    private void OnFire()
    {
        if(Time.timeScale == 0f) { return; }
        GameObject laserObject = Lasers.Dequeue();
        laserObject.transform.position = transform.position + new Vector3(0,0.5f);
        laserObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Damage();
            collision.gameObject.SetActive(false);
            Asteroids.Enqueue(collision.gameObject);
        }
    }
}
