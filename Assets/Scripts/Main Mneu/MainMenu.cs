using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text bestRecordText;

    private void Start()
    {
        int bestScore = PlayerPrefs.GetInt(GameManager.keyBestSocre, 5000);
        bestRecordText.text = "Best Record: " + bestScore.ToString();
    }
}
