using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int startingGold = 0;
    private int startingDamage = 5;
    private int startingHealth = 500;
    private float startingRange = 7f;
    private float startingBulletSpeed = 13f;
    private float startingShootingFrequency = 0.7f;

    [Header("Player Stats"), Space (10f)]
    public int playerGold;
    public int playerDamage;
    public int playerMaxHealth;
    public float playerRange;
    public float playerBulletSpeed;
    public float playerShootingFrequency;

    public ArenaState arenaState;
    public ChangeScene changeScene;
    private string menuSceneName = "MenuScene";

    public void Start()
    {
        ResetValues();
        changeScene = GetComponent<ChangeScene>();
    }

    public void ResetValues()
    {
        playerGold = startingGold;
        playerDamage = startingDamage;
        playerMaxHealth = startingHealth;
        playerRange = startingRange;
        playerBulletSpeed = startingBulletSpeed;
        playerShootingFrequency = startingShootingFrequency;
    }

    public void ResetGame()
    {
        ResetValues();
        ResetUpgrades();
        changeScene.LoadScene(menuSceneName);
    }

    public void ResetUpgrades()
    {
        Upgrade[] upgrades = FindObjectsOfType<Upgrade>();

        foreach (Upgrade upgrade in upgrades)
        {
            upgrade.ResetUpgrade();
        }

        Debug.Log("(PlayerData) All upgrades have been reset to level 1.");
    }

}
