using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelector;

    public void Play()
    {
        levelSelector.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
