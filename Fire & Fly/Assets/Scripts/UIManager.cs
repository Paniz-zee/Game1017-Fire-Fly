using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public Button pauseButton;
    public Button optionsButton;
    private bool isGamePaused = false;
    [SerializeField] TMP_Text pauseBtnTxt;

    void Start()
    {
        optionsButton.onClick.AddListener(ToggleOptions);
        pauseButton.onClick.AddListener(TogglePause);
        optionsPanel.SetActive(false);
    }

    public void ToggleOptions()
    {
        optionsPanel.SetActive(!optionsPanel.activeSelf);
    }

    public void TogglePause()
    {
       
        


            isGamePaused = !isGamePaused;
            Time.timeScale = isGamePaused ? 0 : 1;
        pauseBtnTxt.text = isGamePaused ? "Resume" : "Pause";
        pauseButton.GetComponentInChildren<TextMeshPro>().text = isGamePaused ? "Resume" : "Pause";

            Debug.Log(isGamePaused ? "Game Paused!" : "Game Resumed!");
        
    }
}

