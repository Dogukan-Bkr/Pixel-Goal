using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Bu boolean deðiþken, hangi takýmýn gol attýðýný belirler (oyuncu ya da rakip)
    public bool isPlayer;

    // Bu metod, bir nesne 2D collider'ýna girdiðinde çaðrýlýr
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Çarpan nesnenin 'Ball' component'ine sahip olup olmadýðýný kontrol et
        var ball = collision.gameObject.GetComponent<Ball>();

        // Eðer çarpan nesne bir top ise, isBall true olacak
        bool isBall = ball != null;

        // Eðer çarpan nesne top ise, gol olmuþ demektir
        if (isBall)
        {
            onGoal(); // Gol iþlemlerini baþlat
        }
    }

    // Gol olduðu durumda yapýlacak iþlemleri tanýmlar
    private void onGoal()
    {
        // Topu sýfýrlamak için topu bulan ve resetleyen metod
        FindObjectOfType<Ball>().ResetBall();

        // Skorboard controller'ýný bul ve skor ekleme iþlemini yap
        ScoreBoardController scoreBoardController = FindObjectOfType<ScoreBoardController>();

        // Eðer golü oyuncu attýysa, rakip skorunu artýr
        if (isPlayer)
        {
            scoreBoardController.AddOppenentScore();
        }
        // Eðer golü rakip attýysa, oyuncu skorunu artýr
        else
        {
            scoreBoardController.AddPlayerScore();
        }
    }
}
