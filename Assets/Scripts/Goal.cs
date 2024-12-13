using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Bu boolean de�i�ken, hangi tak�m�n gol att���n� belirler (oyuncu ya da rakip)
    public bool isPlayer;

    // Bu metod, bir nesne 2D collider'�na girdi�inde �a�r�l�r
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �arpan nesnenin 'Ball' component'ine sahip olup olmad���n� kontrol et
        var ball = collision.gameObject.GetComponent<Ball>();

        // E�er �arpan nesne bir top ise, isBall true olacak
        bool isBall = ball != null;

        // E�er �arpan nesne top ise, gol olmu� demektir
        if (isBall)
        {
            onGoal(); // Gol i�lemlerini ba�lat
        }
    }

    // Gol oldu�u durumda yap�lacak i�lemleri tan�mlar
    private void onGoal()
    {
        // Topu s�f�rlamak i�in topu bulan ve resetleyen metod
        FindObjectOfType<Ball>().ResetBall();

        // Skorboard controller'�n� bul ve skor ekleme i�lemini yap
        ScoreBoardController scoreBoardController = FindObjectOfType<ScoreBoardController>();

        // E�er gol� oyuncu att�ysa, rakip skorunu art�r
        if (isPlayer)
        {
            scoreBoardController.AddOppenentScore();
        }
        // E�er gol� rakip att�ysa, oyuncu skorunu art�r
        else
        {
            scoreBoardController.AddPlayerScore();
        }
    }
}
