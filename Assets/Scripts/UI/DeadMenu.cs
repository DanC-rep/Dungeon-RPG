using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public GameObject[] otherUI;

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
        SceneManager.LoadScene(1);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
