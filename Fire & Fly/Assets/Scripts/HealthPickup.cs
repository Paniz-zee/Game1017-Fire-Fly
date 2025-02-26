using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] int healthAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Health.Instance.RestoreHealth(healthAmount);
            Destroy(gameObject);
            Debug.Log("Health pickup collected!");
        }
    }
}
