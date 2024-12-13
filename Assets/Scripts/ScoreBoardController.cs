using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardController : MonoBehaviour
{
    // Oyuncunun ve rakibin skorlarýný tutan deðiþkenler
    public int playerScore;
    public int opponentScore;

    // Skorlarý gösterecek UI metin bileþenleri
    public TMP_Text playerScoreText;
    public TMP_Text opponentScoreText;

    // Baþlangýçta UI güncellemesini yapar
    private void Start()
    {
        UpdateUI(); // Baþlangýçta skoru güncellemek için çaðrýlýr
    }

    // Oyuncunun skorunu artýrýr ve UI'ý günceller
    public void AddPlayerScore(int amount = 1)
    {
        playerScore += amount; // Skoru belirtilen miktarda artýrýr (varsayýlan 1)
        UpdateUI(); // UI'ý günceller
    }

    // Rakibin skorunu artýrýr ve UI'ý günceller
    public void AddOppenentScore(int amount = 1)
    {
        opponentScore += amount; // Rakibin skorunu belirtilen miktarda artýrýr (varsayýlan 1)
        UpdateUI(); // UI'ý günceller
    }

    // UI'ý günceller, yani skor metinlerini oyuncu ve rakip skorlarýyla günceller
    public void UpdateUI()
    {
        playerScoreText.text = playerScore.ToString(); // Oyuncunun skorunu UI'da gösterir
        opponentScoreText.text = opponentScore.ToString(); // Rakibin skorunu UI'da gösterir
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
