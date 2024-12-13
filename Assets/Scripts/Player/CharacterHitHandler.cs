using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHitHandler : MonoBehaviour
{
    // Vuru�un y�n�n� belirten de�i�ken
    public Vector2 hitDirection;

    // G��l� vuru�un s�resi (k�sa bir s�re)
    public float powerHitDuration = 0.2f;

    // G��l� vuru�un kuvvet b�y�kl���
    public float powerHitForceMag = 1.75f;

    // G��l� vuru�un zamanlay�c�s�
    private float powerHitTimer;

    // G��l� vuru�un kullan�l�p kullan�lamad���n� belirten de�i�ken
    private bool canUsePowerHit;

    // Update, her frame �a�r�l�r. G��l� vuru�un zamanlay�c�s�n� kontrol eder.
    private void Update()
    {
        // Bo�luk tu�una bas�ld���nda, g��l� vuru�un s�resi ba�lar ve kullan�labilir hale gelir
        if (Input.GetKeyDown(KeyCode.Space))
        {
            powerHitTimer = powerHitDuration; // Zamanlay�c�y� s�f�rla ve ba�lat
            canUsePowerHit = true; // G��l� vuru�u kullan�labilir yap
        }

        // E�er zamanlay�c� pozitifse, zamanla s�f�rlan�r ve vuru� iptal edilir
        if (powerHitTimer > 0)
        {
            powerHitTimer -= Time.deltaTime; // Zaman� azalt
            if (powerHitTimer <= 0)
            {
                canUsePowerHit = false; // S�re dolarsa, g��l� vuru�u devre d��� b�rak
            }
        }
    }

    // Karakterin topa �arpmas� durumunda bu metod tetiklenir
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>(); // �arpan nesnenin top olup olmad���n� kontrol et
        if (ball != null) // E�er topa �arpt�ysa
        {
            // G��l� vuru� aktifse, topa daha g��l� bir kuvvet uygula
            if (canUsePowerHit)
            {
                // G��l� vuru�, karakterin y�n�n� ve kuvveti i�erir
                ball.AddForce((transform.localScale.x * -1) * hitDirection.normalized * powerHitForceMag, true); // G��l� vuru� ekle
            }
            else
            {
                // Normal vuru�, yaln�zca y�n� kullanarak topa kuvvet uygula
                ball.AddForce((transform.localScale.x * -1) * hitDirection.normalized); // Normal vuru� ekle
            }
        }
    }
}
