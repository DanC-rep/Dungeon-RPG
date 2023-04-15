using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public GameObject[] otherUI;
    public string level;

    private void Start()
    {
        if (gameObject.activeSelf)
        {
            foreach (var el in otherUI)
            {
                el.SetActive(false);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(level);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
