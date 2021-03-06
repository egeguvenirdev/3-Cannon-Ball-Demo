using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private float totalBox;
    private float destroyedBoxCount = 0;
    public float progress = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] safeboxes = GameObject.FindGameObjectsWithTag("SafeBox");
        GameObject[] explosiveBoxes = GameObject.FindGameObjectsWithTag("SafeBox");
        totalBox = safeboxes.Length;
        totalBox += explosiveBoxes.Length;
    }

    public void ReduceBoxCount(int i)
    {
        destroyedBoxCount += i;
        progress = (destroyedBoxCount / totalBox) * 100;

        UIManager.Instance.SetProgress((int)progress);

        if (progress >= 100) 
        {
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel, 0") + 1);
            UIManager.Instance.NextLvUI();
        }
    }

}
