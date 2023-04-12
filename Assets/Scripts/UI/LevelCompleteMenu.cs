using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    public string nextLevel;

    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
        Time.timeScale = 1;
    }
}
