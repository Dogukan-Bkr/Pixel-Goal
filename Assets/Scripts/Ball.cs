using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Rigidbody2D, topun fiziksel �zelliklerini kontrol etmek i�in kullan�l�r
    private Rigidbody2D rb;

    // TrailRenderer, top hareket ettik�e arkada b�rakt��� izi g�sterecek
    public TrailRenderer trailRenderer;

    // PowerShot s�ras�nda g�sterilecek �zel efektin prefab'�
    public GameObject particleEffectPrefab;

    // Etkinin s�resi (�rne�in, power shot sonras� efekt)
    private const float effectDuration = 0.5f;

    // Efektin s�resi i�in zamanlay�c�
    private float effectTimer;

    // Ba�lang��ta bile�enleri al�yoruz ve TrailRenderer'� devre d��� b�rak�yoruz
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D'yi al
    }

    // Oyun ba�lad���nda yap�lacak ilk ayarlar
    private void Start()
    {
        trailRenderer.enabled = false; // TrailRenderer'� ba�lang��ta gizle
    }

    // Her frame �a�r�l�r, efekt s�resi geriye do�ru i�lenir
    private void Update()
    {
        // E�er bir efekt s�resi varsa, zamanlay�c�y� azalt
        if (effectTimer > 0)
        {
            effectTimer -= Time.deltaTime; // Zaman ge�tik�e efekt s�resini azalt
            if (effectTimer <= 0)
            {
                StopCurrentEffect(); // S�re bitince efekti durdur
            }
        }
    }

    // Topa kuvvet ekler, iste�e ba�l� olarak PowerShot efekti olu�turur
    public void AddForce(Vector2 force, bool isPowerShot = false)
    {
        // Kuvvet �arpan�, topun k�tlesine g�re ayarlan�r
        float forceMult = 750f;
        forceMult *= rb.mass; // Kuvveti topun k�tlesine g�re �l�eklendir

        // Kuvveti topa uygula
        rb.AddForce(force * forceMult);

        // E�er power shot ise, efekt yarat
        if (isPowerShot)
        {
            CreateEffect();
        }
    }

    // PowerShot sonras� efekt yarat�r
    private void CreateEffect()
    {
        effectTimer = effectDuration; // Efekt s�resini ba�lat
        // Efekti topun bulundu�u pozisyonda yarat
        Instantiate(particleEffectPrefab, transform.position, particleEffectPrefab.transform.rotation);
        trailRenderer.enabled = true; // TrailRenderer'� etkinle�tir
    }

    // Efekt s�resi dolarsa, TrailRenderer'� devre d��� b�rak
    private void StopCurrentEffect()
    {
        trailRenderer.enabled = false; // TrailRenderer'� gizle
    }

    // Topu s�f�rlamak i�in, h�z�n� s�f�rla ve pozisyonunu ba�lang�� noktas�na getir
    public void ResetBall()
    {
        rb.velocity = Vector2.zero; // Topun h�z�n� s�f�rla
        rb.angularVelocity = 0; // Topun a��sal h�z�n� s�f�rla
        transform.position = new Vector3(0, 0); // Topu ba�lang�� pozisyonuna yerle�tir
    }
}
