using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject[] otherUI;
    public GameObject menuPanel;

    public void OpenMenu()
    {
        foreach (var el in otherUI)
        {
            el.SetActive(false);
        }

        menuPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
