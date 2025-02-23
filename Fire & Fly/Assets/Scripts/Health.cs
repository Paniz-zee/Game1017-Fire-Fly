using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health Instance;

    [SerializeField] Transform heartsContainer;
    [SerializeField] GameObject heartPrefab;
    [SerializeField] float heartSpacing;

    private List<GameObject> hearts = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void InitializeHearts(int maxHealth)
    {
        foreach (var heart in hearts)
        {
            Destroy(heart);
        }
        hearts.Clear();

        for (int i = 0; i < maxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsContainer);
            hearts.Add(heart);

            heart.transform.localPosition = new Vector3(i * heartSpacing, 0f, 0f);
        }
    }
    public void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }
}