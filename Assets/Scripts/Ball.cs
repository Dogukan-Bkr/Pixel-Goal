using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Rigidbody2D, topun fiziksel özelliklerini kontrol etmek için kullanýlýr
    private Rigidbody2D rb;

    // TrailRenderer, top hareket ettikçe arkada býraktýðý izi gösterecek
    public TrailRenderer trailRenderer;

    // PowerShot sýrasýnda gösterilecek özel efektin prefab'ý
    public GameObject particleEffectPrefab;

    // Etkinin süresi (örneðin, power shot sonrasý efekt)
    private const float effectDuration = 0.5f;

    // Efektin süresi için zamanlayýcý
    private float effectTimer;

    // Baþlangýçta bileþenleri alýyoruz ve TrailRenderer'ý devre dýþý býrakýyoruz
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D'yi al
    }

    // Oyun baþladýðýnda yapýlacak ilk ayarlar
    private void Start()
    {
        trailRenderer.enabled = false; // TrailRenderer'ý baþlangýçta gizle
    }

    // Her frame çaðrýlýr, efekt süresi geriye doðru iþlenir
    private void Update()
    {
        // Eðer bir efekt süresi varsa, zamanlayýcýyý azalt
        if (effectTimer > 0)
        {
            effectTimer -= Time.deltaTime; // Zaman geçtikçe efekt süresini azalt
            if (effectTimer <= 0)
            {
                StopCurrentEffect(); // Süre bitince efekti durdur
            }
        }
    }

    // Topa kuvvet ekler, isteðe baðlý olarak PowerShot efekti oluþturur
    public void AddForce(Vector2 force, bool isPowerShot = false)
    {
        // Kuvvet çarpaný, topun kütlesine göre ayarlanýr
        float forceMult = 750f;
        forceMult *= rb.mass; // Kuvveti topun kütlesine göre ölçeklendir

        // Kuvveti topa uygula
        rb.AddForce(force * forceMult);

        // Eðer power shot ise, efekt yarat
        if (isPowerShot)
        {
            CreateEffect();
        }
    }

    // PowerShot sonrasý efekt yaratýr
    private void CreateEffect()
    {
        effectTimer = effectDuration; // Efekt süresini baþlat
        // Efekti topun bulunduðu pozisyonda yarat
        Instantiate(particleEffectPrefab, transform.position, particleEffectPrefab.transform.rotation);
        trailRenderer.enabled = true; // TrailRenderer'ý etkinleþtir
    }

    // Efekt süresi dolarsa, TrailRenderer'ý devre dýþý býrak
    private void StopCurrentEffect()
    {
        trailRenderer.enabled = false; // TrailRenderer'ý gizle
    }

    // Topu sýfýrlamak için, hýzýný sýfýrla ve pozisyonunu baþlangýç noktasýna getir
    public void ResetBall()
    {
        rb.velocity = Vector2.zero; // Topun hýzýný sýfýrla
        rb.angularVelocity = 0; // Topun açýsal hýzýný sýfýrla
        transform.position = new Vector3(0, 0); // Topu baþlangýç pozisyonuna yerleþtir
    }
}
