using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScreenController : MonoBehaviour
{
    public void StartGameButton()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ScreenSoulUpgradeButton()
    {
        SceneManager.LoadScene("SoulUpgrade");
    }
    public void RemoveAllSaveButton()
    {
        PlayerPrefs.DeleteAll();
    }
}
