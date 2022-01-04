using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidePlayer : MonoBehaviour
{
    public GameObject player0;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    PlayerData data;
    // Start is called before the first frame update
    void Start()
    {
        data = SaveSystem.LoadPlayer();
        switch(data.id)
        {
            case 0:
                player1.SetActive(false);
                player2.SetActive(false);
                player3.SetActive(false);
                player4.SetActive(false);
                break;
            case 1:
                player0.SetActive(false);
                player2.SetActive(false);
                player3.SetActive(false);
                player4.SetActive(false);
                break;
            case 2:
                player1.SetActive(false);
                player0.SetActive(false);
                player3.SetActive(false);
                player4.SetActive(false);
                break;
            case 3:
                player1.SetActive(false);
                player2.SetActive(false);
                player0.SetActive(false);
                player4.SetActive(false);
                break;
            case 4:
                player1.SetActive(false);
                player2.SetActive(false);
                player3.SetActive(false);
                player0.SetActive(false);
                break;
        }
    }

}
