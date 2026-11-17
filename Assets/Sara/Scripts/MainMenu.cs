using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneIndex;
    public GameObject SettingsUI;
    public GameObject MenuUI;
    public GameObject CreditsUI;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        MenuUI.SetActive(false);
        SettingsUI.SetActive(true);
    }
    public void CloseSettings()
    {
        SettingsUI.SetActive(false);
        MenuUI.SetActive(true);    
    }
    public void OpenCredits()
    {
        MenuUI.SetActive(false);
        CreditsUI.SetActive(true);
    }
    public void CloseCredits()
    {
        MenuUI.SetActive(true);
        CreditsUI.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
