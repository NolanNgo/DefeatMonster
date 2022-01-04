using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameWin : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5];
    public float coin;
    public Text CoinsText;
    public float healthPlayer;
    public float maxHealth;
    public float dame;
    public float coins;
    public PlayerData data;
    public PlayerController player0;
    public PlayerController player1;
    public PlayerController player2;
    public PlayerController player3;
    public PlayerController player4;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
        // Debug.Log(playerData.dame);
        // Debug.Log(playerData.maxHealth);
        // id Items
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        // Prices Items
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 30;
        shopItems[2, 3] = 35;
        shopItems[2, 4] = 40;

        // Count Items
        shopItems[3, 1] = 5;
        shopItems[3, 2] = 5;
        shopItems[3, 3] = 1;
        shopItems[3, 4] = 1;
    }

    public void Buy()
    {
        switch(data.id)
        {
            case 0:
                player = player0;
                break;
            case 1:
                player = player1;
                break;
            case 2:
                player = player2;
                break;
            case 3:
                player = player3;
                break;
            case 4:
                player = player4;
                break;
        }
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if ( player.coins >=0 && player.coins >= shopItems[2, ButtonRef.GetComponent<ItemsShop>().ItemID] && shopItems[3, ButtonRef.GetComponent<ItemsShop>().ItemID] > 0)
        {
            if(shopItems[1, ButtonRef.GetComponent<ItemsShop>().ItemID] ==1 && player.healthPlayer < player.maxHealth)
            {
                player.coins -= shopItems[2, ButtonRef.GetComponent<ItemsShop>().ItemID];
                shopItems[3, ButtonRef.GetComponent<ItemsShop>().ItemID]--;
                player.healthPlayer = data.healthPlayer += 1000;
                if(player.healthPlayer >= player.maxHealth)
                {
                    player.healthPlayer = player.maxHealth;
                }
                // CoinsText.text = "Coins: " + coin.ToString();
                ButtonRef.GetComponent<ItemsShop>().QuantityText.text = shopItems[3, ButtonRef.GetComponent<ItemsShop>().ItemID].ToString();        
            }
            if(shopItems[1, ButtonRef.GetComponent<ItemsShop>().ItemID] ==2){
                player.coins -= shopItems[2, ButtonRef.GetComponent<ItemsShop>().ItemID];
                shopItems[3, ButtonRef.GetComponent<ItemsShop>().ItemID]--;
                player.dame = data.dame*2;
                // CoinsText.text = "Coins: " + coin.ToString();
                ButtonRef.GetComponent<ItemsShop>().QuantityText.text = shopItems[3, ButtonRef.GetComponent<ItemsShop>().ItemID].ToString();
            }
            if(shopItems[1, ButtonRef.GetComponent<ItemsShop>().ItemID] ==3){
                player.coins -= shopItems[2, ButtonRef.GetComponent<ItemsShop>().ItemID];
                shopItems[3, ButtonRef.GetComponent<ItemsShop>().ItemID]--;
                player.maxHealth += 1000;
                // CoinsText.text = "Coins: " + coin.ToString();
                ButtonRef.GetComponent<ItemsShop>().QuantityText.text = shopItems[3, ButtonRef.GetComponent<ItemsShop>().ItemID].ToString();
            }
            if(shopItems[1, ButtonRef.GetComponent<ItemsShop>().ItemID] ==4){
                player.coins -= shopItems[2, ButtonRef.GetComponent<ItemsShop>().ItemID];
                shopItems[3, ButtonRef.GetComponent<ItemsShop>().ItemID]--;
                player.healthPlayer = data.maxHealth;
                // CoinsText.text = "Coins: " + coin.ToString();
                ButtonRef.GetComponent<ItemsShop>().QuantityText.text = shopItems[3, ButtonRef.GetComponent<ItemsShop>().ItemID].ToString();
            }
            // player.healthPlayer = data.healthPlayer;
            SaveSystem.SavePlayer(player);

        }

    }

    // Update is called once per frame
    void Update()
    {
        data = SaveSystem.LoadPlayer();
        CoinsText.text = "Coins: " + data.coins.ToString();
        // Debug.Log(data.healthPlayer);
    }
}
