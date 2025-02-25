using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnpoint;
    [SerializeField] GameObject playerExplosionPrefab;
   
    [SerializeField] int maxHealth;
    private int currentHealth;
    private SoundScript soundScript;
  public GameOverManager gameOverManager;

    void Start()
    {
        if (soundScript == null)
        {
            soundScript = FindObjectOfType<SoundScript>();
        }
        // Initialize health
        currentHealth = maxHealth;
        Health.Instance.InitializeHearts(maxHealth);
        Health.Instance.UpdateHealthUI(currentHealth);
        
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalMovement, verticalMovement, 0.0f).normalized;

        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletInst = Instantiate(bulletPrefab, spawnpoint.position, Quaternion.identity);
            bulletInst.GetComponentInChildren<SpriteRenderer>().color = new Color(Random.Range(0f, 1f),
                Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            soundScript.PlaySoundEffect1();
        }
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    // Trigger the Game Over screen
    //void TriggerGameOver()
    //{
    //    gameOverManager.ShowGameOver();  // Show the Game Over UI
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(); // Reduce health
        }
        else if (collision.CompareTag("Enemy"))
        {
            TakeDamage(); // Reduce health
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
            Debug.Log("Player hit by an enemy!");
            Destroy(collision.gameObject);
            


        }
        if (collision.CompareTag("Obstacle"))
        {
            TakeDamage(); // Reduce player health

            Debug.Log("Player hit an obstacle!");
            Destroy(collision.gameObject);
        }
        //if (collision.CompareTag("Enemy bullet"))
        //{
        //    Destroy(collision.gameObject);
        //    TakeDamage(); // Reduce health
        //}
    }

    public void TakeDamage()
    {
        currentHealth--;  // Decrease health by 1
        Debug.Log("Player Health: " + currentHealth);  // Log current health

        // Update UI or other health-related systems
        Health.Instance.UpdateHealthUI(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
            gameOverManager.ShowGameOver();
            // If health is 0 or below, destroy the player
            Instantiate(playerExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);  // Destroy the player object
            Debug.Log("Player destroyed!");
            soundScript.PlayExplosionSound();



        } 
         

    }
   

}