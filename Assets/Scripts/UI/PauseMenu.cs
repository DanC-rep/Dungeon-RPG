using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject[] otherUI;
    public GameObject menuPanel;

    public void Resume()
    {
        foreach (var el in otherUI)
        {
            el.SetActive(true);
        }

        menuPanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
