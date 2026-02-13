using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText; // Drag your Text object here in Inspector

    void Start()
    {
        finalScoreText.text = ScoreCounter.finalScore.ToString("#,0");
    }
}
