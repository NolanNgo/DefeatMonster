using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int id;
    public float healthPlayer;
    public float maxHealth;
    public float dame;
    public float coins;

    public PlayerData (PlayerController player)
    {
        id = player.id;
        healthPlayer = player.healthPlayer;
        maxHealth = player.maxHealth;
        dame = player.dame;
        coins = player.coins;
    }
}
