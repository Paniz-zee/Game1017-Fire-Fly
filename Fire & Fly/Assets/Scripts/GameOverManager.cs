using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public TMP_Text gameOverText;

    void Start()
    {
        gameOverUI.SetActive(false);
    }

    // Method to show the Game Over UI
    public void ShowGameOver()
    {
        SceneManager.LoadScene("GameOverScene");
        //gameOverUI.SetActive(true);
        //gameOverText.text = "Game Over!";
    }

    // Restart the game
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}