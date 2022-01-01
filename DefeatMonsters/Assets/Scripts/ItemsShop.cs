using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsShop : MonoBehaviour
{
    public int ItemID;
    public Text PriceText;
    public Text QuantityText;
    public GameObject ShopManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PriceText.text = "Prices: $ "+ShopManager.GetComponent<GameWin>().shopItems[2, ItemID].ToString();
        QuantityText.text = ShopManager.GetComponent<GameWin>().shopItems[3, ItemID].ToString();
    }
}
