using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Vector3 direction; // The direction in which the bullet will move
    public float speed; // The speed at which the bullet will move

    private void Update()
    {
        // Move the bullet in the specified direction at the specified speed
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the bullet collides with another object, destroy the bullet
        Destroy(this.gameObject);
    }
}