using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void SelectLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
