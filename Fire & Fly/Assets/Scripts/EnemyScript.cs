using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] int health = 1;
    [SerializeField] GameObject explosionPrefab;
    private SoundScript soundScript;
    void Update()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
        if (transform.position.x <= -8.5f)
        {
            transform.position = new Vector3(8.5f, Random.Range(-5.5f, 5.5f), 0f);
        }
        if (health <= 0)
        {
            OnDeath(); // Call OnDeath when health is 0
        }
    }
    [SerializeField] int scoreValue = 10;
    [SerializeField] float spawnRate;
    [SerializeField] GameObject enemyBullet;

    void Start()
    {
        if (soundScript == null)
        {
            soundScript = FindObjectOfType<SoundScript>(); // This finds SoundScript in the scene
        }
        spawnRate = Random.Range(1.5f, 3f);
        Invoke("SpawnBulletRandom", spawnRate);
    }

    private void SpawnBulletRandom()
    {
        SpawnBullet();
        spawnRate = Random.Range(1.5f, 3f);
        Invoke("SpawnBulletRandom", spawnRate);
    }

    private void SpawnBullet()
    {
        Instantiate(enemyBullet, transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerScript player = collision.GetComponent<PlayerScript>();
            if (player != null)
            {
                /*player.TakeDamage();*/
            }

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // Destroy the enemy

        }
        else if (collision.CompareTag("Bullet"))
        {
            // Destroy the bullet and the enemy
            Destroy(collision.gameObject); // Destroy the bullet
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // Destroy the enemy
            soundScript.PlayExplosionSound();
        }

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        PlayerScript player = collision.GetComponent<PlayerScript>();
    //        if (player != null)
    //        {
    //            player.TakeDamage(); // Reduce player's health
    //        }

    //        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    //        Destroy(gameObject); // Destroy the enemy
    //    }
    //}
    private void OnDestroy()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(scoreValue);
        }
    }
    private void OnDeath()
    {
        if (soundScript != null)
        {
            soundScript.PlayExplosionSound(); // Play explosion sound when enemy dies
        }
        Destroy(gameObject);
    }
}