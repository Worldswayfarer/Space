using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBase : MonoBehaviour
{
    public ObjectQueue ObjectQueue;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        ObjectQueue.Enqueue(collision.gameObject);
    }
}
