using System;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour

{
    
    [SerializeField] int maxHealth = 5;
    [SerializeField] CharacterController controller;
    [SerializeField] TMP_Text healthText;
    [SerializeField] HurtFlash flash;
    [SerializeField] float safeTime = 1f;
    float safeLeft;
    Vector3 respawnPoint;
    int health;
    void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(int amount)
    {
        if (safeLeft > 0f) return;
        health -= amount;
        safeLeft = safeTime;
        if (flash != null) flash.Flash();
        if (health <= 0) Respawn();
        ShowHealth();
    }

    public void SetCheckpoint(Vector3 point)
    {
        respawnPoint = point;
    }

    void Respawn()
    {
        controller.enabled = false;
        transform.position = respawnPoint;
        controller.enabled = true;
        health = maxHealth;
    }
    void Update()
    {
        if (safeLeft > 0f) safeLeft -= Time.deltaTime;
    }
    void ShowHealth()
    {
        if (healthText != null) healthText.text = "Health: " + health;
    }
}
