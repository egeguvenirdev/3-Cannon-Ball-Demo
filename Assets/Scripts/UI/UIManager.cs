using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameObject tapToPlayUI;
    [SerializeField] private GameObject nextLvMenuUI;
    [SerializeField] private GameObject restartMenuUI;

    //pause button ui uthilities
    [SerializeField] private GameObject pausedText;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Toggle vibrationToggle;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private TMP_Text currentLV;
    [SerializeField] private TMP_Text nextLV;
    [SerializeField] private TMP_Text shotCount;

    public Slider slider;

    public bool isPaused;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("vibrationOnOff") == 0)
        {
            vibrationToggle.GetComponent<Toggle>().isOn = false;
        }

        if (PlayerPrefs.GetInt("soundOnOff") == 0)
        {
            soundToggle.GetComponent<Toggle>().isOn = false;
        }
    }

    private void Start()
    {
        isPaused = true;

        PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
        LevelText();
    }

    public void PlayResButton()
    {
        if (tapToPlayUI.activeSelf)
        {
            tapToPlayUI.SetActive(false);
            isPaused = false;
        }

        if (nextLvMenuUI.activeSelf)
        {
            nextLvMenuUI.SetActive(false);
            isPaused = false;

            SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));     
        }

        if (restartMenuUI.activeSelf)
        {
            restartMenuUI.SetActive(false);
            isPaused = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void NextLvUI()
    {
        if (!isPaused) //if the game not stopped
        {
            Debug.Log("next lv ui");
            nextLvMenuUI.SetActive(true);
            isPaused = true;          
        }
    }

    public void RestartButtonUI()
    {
        if (!isPaused) //if the game not stopped
        {
            restartMenuUI.SetActive(true);
            isPaused = true;
        }
    }

    public void UIVibrationToggle(bool checkOnOff)
    {
        if (checkOnOff)
        {
            vibrationToggle.GetComponent<Toggle>().isOn = true;
            PlayerPrefs.SetInt("vibrationOnOff", 1);
        }
        else
        {
            vibrationToggle.GetComponent<Toggle>().isOn = false;
            PlayerPrefs.SetInt("vibrationOnOff", 0);
        }
    }

    public void UISoundToggle(bool checkOnOff)
    {
        if (checkOnOff)
        {
            soundToggle.GetComponent<Toggle>().isOn = true;
            PlayerPrefs.SetInt("soundOnOff", 1);
        }
        else
        {
            soundToggle.GetComponent<Toggle>().isOn = false;
            PlayerPrefs.SetInt("soundOnOff", 0);
        }
    }

    public void LevelText()
    {
        currentLV.text = "Lv " + (PlayerPrefs.GetInt("CurrentLevel"));
        nextLV.text = "Lv " + (PlayerPrefs.GetInt("CurrentLevel") + 1);
    }

    public void ShotCountText(int count)
    {
        shotCount.text = "x" + count;
    }

    public void SetProgress(int progress)
    {
        slider.value = progress;
        progressText.text = "% " + progress;
    }

    public void UIQuitGame()
    {
        Application.Quit();
    }
}
