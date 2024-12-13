using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardController : MonoBehaviour
{
    // Oyuncunun ve rakibin skorlar�n� tutan de�i�kenler
    public int playerScore;
    public int opponentScore;

    // Skorlar� g�sterecek UI metin bile�enleri
    public TMP_Text playerScoreText;
    public TMP_Text opponentScoreText;

    // Ba�lang��ta UI g�ncellemesini yapar
    private void Start()
    {
        UpdateUI(); // Ba�lang��ta skoru g�ncellemek i�in �a�r�l�r
    }

    // Oyuncunun skorunu art�r�r ve UI'� g�nceller
    public void AddPlayerScore(int amount = 1)
    {
        playerScore += amount; // Skoru belirtilen miktarda art�r�r (varsay�lan 1)
        UpdateUI(); // UI'� g�nceller
    }

    // Rakibin skorunu art�r�r ve UI'� g�nceller
    public void AddOppenentScore(int amount = 1)
    {
        opponentScore += amount; // Rakibin skorunu belirtilen miktarda art�r�r (varsay�lan 1)
        UpdateUI(); // UI'� g�nceller
    }

    // UI'� g�nceller, yani skor metinlerini oyuncu ve rakip skorlar�yla g�nceller
    public void UpdateUI()
    {
        playerScoreText.text = playerScore.ToString(); // Oyuncunun skorunu UI'da g�sterir
        opponentScoreText.text = opponentScore.ToString(); // Rakibin skorunu UI'da g�sterir
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
