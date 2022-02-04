using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public static int countReplay; 

    public void ReplayGame()
    {
        countReplay++;
        SceneManager.LoadScene("Level");
        if(countReplay >= 5)
        {
            if (PlayerPrefs.GetInt("Ads") == 0)
            {
                AdManager.instance.ShowPantallaCompleta();
            }
            countReplay = 0;
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
        if (PlayerPrefs.GetInt("Ads") == 0)
        {
            AdManager.instance.ShowPantallaCompleta();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        AdManager.instance.HideBanner();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("Ads") == 0)
        {
            AdManager.instance.RequestBanner();
        }
    }
}
