using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCharacter : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    public GameObject obstacle5;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Debug.Log(data.id);
        if (data.id == 0) { GameObject newObstacle = Instantiate(obstacle1); }
        if (data.id == 1) { GameObject newObstacle = Instantiate(obstacle2); }
        if (data.id == 2) { GameObject newObstacle = Instantiate(obstacle3); }
        if (data.id == 3) { GameObject newObstacle = Instantiate(obstacle4); }
        if (data.id == 4) { GameObject newObstacle = Instantiate(obstacle5); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
