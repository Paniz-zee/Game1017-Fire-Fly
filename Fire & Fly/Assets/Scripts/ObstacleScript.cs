using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;



    void Update()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
        if (transform.position.x <= -8.5f)
        {
            transform.position = new Vector3(8.5f, Random.Range(-5.5f, 5.5f), 0f);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); // Only destroy the obstacle, don't call TakeDamage
        }
    }
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        PlayerScript player = collision.GetComponent<PlayerScript>();
    //        if (player != null)
    //        {
    //            player.TakeDamage(); // Reduce player's health
    //        }


    //        Destroy(gameObject); // Destroy the enemy
    //    }
    //}
}
    