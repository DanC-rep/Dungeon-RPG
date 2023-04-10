using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWin : MonoBehaviour
{
    public int nextLevel;

    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", nextLevel);
    }
}
