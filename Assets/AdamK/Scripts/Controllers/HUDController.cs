using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    [Header("UI Elements")]
    public Slider healthBar;
    public Slider shieldBar;
    public Slider bossHealthBar;
    public Slider bossAttackBar;
    public TMP_Text enemiesKilledCounter;

    [Header("Player Inputs")]
    public float currentHealth;
    public float currentShields;
    public float enemiesKilled;
    public float bossHealth;
    public float bossWeapon;

    [Header("Tutorial Messages")]
    public GameObject shootText;
    public GameObject shieldText;
    public GameObject containerBoss;
    public GameObject containerEnemies;
    public GameObject containerMiddle;
    public GameObject containerWin;
    public GameObject containerLose;

    public bool shieldsReady;

    public PlayerTurret playerTurret;
    public LevelManager levelManager;
    public BossTurret bossTurret;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
        
    }

    // Update is called once per frame
    void Update()
    {
        OnHealthChanged();
        OnShieldChanged();
        OnBossChanged();
        OnBossWeapon();
        enemiesKilledCounter.text = enemiesKilled.ToString();
        enemiesKilled = levelManager.enemiesKilled;
    }

    public void Setup()
    {
        OnHealthChanged();
        OnShieldChanged();
        OnBossChanged();
        OnBossWeapon();
        enemiesKilledCounter.text = enemiesKilled.ToString();
        enemiesKilled = levelManager.enemiesKilled;
        containerMiddle.SetActive(true);
        containerWin.SetActive(false);
        containerLose.SetActive(false);
    }

    public void BossFight()
    {
        containerBoss.SetActive(true);
        containerEnemies.SetActive(false);
    }

    public void OnBossChanged()
    {
        bossHealth = bossTurret.health / bossTurret.maxHealth;
        bossHealthBar.value = bossHealth;
    }

    public void OnBossWeapon()
    {
        bossWeapon = bossTurret.weaponChargeTimer / 5;
        bossAttackBar.value = 1 - bossWeapon;
    }

    public void OnHealthChanged()
    {
        currentHealth = playerTurret.health / playerTurret.maxHealth;
        healthBar.value = currentHealth;
    }

    public void OnShieldChanged()
    {
        currentShields = playerTurret.shieldTimer / playerTurret.shieldCooldown;
        shieldBar.value = 1 - currentShields;
    }
    
    public void Win()
    {
        containerWin.SetActive(true);
        containerMiddle.SetActive(false);
    }

    public void Lose()
    {
        containerLose.SetActive(true);
        containerMiddle.SetActive(false);
    }

}
