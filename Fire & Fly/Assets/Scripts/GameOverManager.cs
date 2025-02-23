using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;  // Reference to the Game Over UI
    public TMP_Text gameOverText;  // Reference to the TMP_Text component for the Game Over message

    void Start()
    {
        gameOverUI.SetActive(false);  // Hide Game Over UI at the start
    }

    // Method to show the Game Over UI
    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);  // Show the Game Over UI
        gameOverText.text = "Game Over!";  // Update the text to show "Game Over!"
    }

    // Restart the game
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}