using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameWin : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];
    public float coin;
    public Text CoinsText;
    // Start is called before the first frame update
    void Start()
    {
        CoinsText.text = "Coins: "+coin.ToString();
        // id Items
        shopItems[1,1] =1;
        shopItems[1,2] =2;
        shopItems[1,3] =3;
        shopItems[1,4] =4;

        // Prices Items
        shopItems[2,1] =60;
        shopItems[2,2] =350;
        shopItems[2,3] =300;
        shopItems[2,4] =400;

        // Count Items
        shopItems[3,1] =5;
        shopItems[3,2] =5;
        shopItems[3,3] =1;
        shopItems[3,4] =1;
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if(coin >= shopItems[2,ButtonRef.GetComponent<ItemsShop>().ItemID] && shopItems[3,ButtonRef.GetComponent<ItemsShop>().ItemID] >0 )
        {
            coin -= shopItems[2,ButtonRef.GetComponent<ItemsShop>().ItemID];
            shopItems[3,ButtonRef.GetComponent<ItemsShop>().ItemID]--;
            CoinsText.text = "Coins: "+coin.ToString();
            ButtonRef.GetComponent<ItemsShop>().QuantityText.text = shopItems[3,ButtonRef.GetComponent<ItemsShop>().ItemID].ToString();
             
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
