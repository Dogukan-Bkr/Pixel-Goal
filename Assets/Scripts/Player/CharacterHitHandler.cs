using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHitHandler : MonoBehaviour
{
    // Vuruþun yönünü belirten deðiþken
    public Vector2 hitDirection;

    // Güçlü vuruþun süresi (kýsa bir süre)
    public float powerHitDuration = 0.2f;

    // Güçlü vuruþun kuvvet büyüklüðü
    public float powerHitForceMag = 1.75f;

    // Güçlü vuruþun zamanlayýcýsý
    private float powerHitTimer;

    // Güçlü vuruþun kullanýlýp kullanýlamadýðýný belirten deðiþken
    private bool canUsePowerHit;

    // Update, her frame çaðrýlýr. Güçlü vuruþun zamanlayýcýsýný kontrol eder.
    private void Update()
    {
        // Boþluk tuþuna basýldýðýnda, güçlü vuruþun süresi baþlar ve kullanýlabilir hale gelir
        if (Input.GetKeyDown(KeyCode.Space))
        {
            powerHitTimer = powerHitDuration; // Zamanlayýcýyý sýfýrla ve baþlat
            canUsePowerHit = true; // Güçlü vuruþu kullanýlabilir yap
        }

        // Eðer zamanlayýcý pozitifse, zamanla sýfýrlanýr ve vuruþ iptal edilir
        if (powerHitTimer > 0)
        {
            powerHitTimer -= Time.deltaTime; // Zamaný azalt
            if (powerHitTimer <= 0)
            {
                canUsePowerHit = false; // Süre dolarsa, güçlü vuruþu devre dýþý býrak
            }
        }
    }

    // Karakterin topa çarpmasý durumunda bu metod tetiklenir
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>(); // Çarpan nesnenin top olup olmadýðýný kontrol et
        if (ball != null) // Eðer topa çarptýysa
        {
            // Güçlü vuruþ aktifse, topa daha güçlü bir kuvvet uygula
            if (canUsePowerHit)
            {
                // Güçlü vuruþ, karakterin yönünü ve kuvveti içerir
                ball.AddForce((transform.localScale.x * -1) * hitDirection.normalized * powerHitForceMag, true); // Güçlü vuruþ ekle
            }
            else
            {
                // Normal vuruþ, yalnýzca yönü kullanarak topa kuvvet uygula
                ball.AddForce((transform.localScale.x * -1) * hitDirection.normalized); // Normal vuruþ ekle
            }
        }
    }
}
