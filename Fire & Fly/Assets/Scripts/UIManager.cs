using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        optionsPanel.SetActive(false);
        musicSlider.onValueChanged.AddListener(MainController.Instance.SoundManager.SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(MainController.Instance.SoundManager.SetSFXVolume);
    }

    public void ToggleOptions()
    {
        bool isActive = !optionsPanel.activeSelf;
        optionsPanel.SetActive(isActive);
        Time.timeScale = isActive ? 0f : 1f;
    }
}
