using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class CoinUI : MonoBehaviour
{
    public Text coinsText;

    private void Update()
    {
        coinsText.text = PlayerStats.Money.ToString();
    }
}
