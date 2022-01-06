using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterFreeze : MonoBehaviour
{
    public float dame ;
    public float healthEnemy;
    public float maxHealthEnemy;
    public Image healthBar;
    public PlayerData data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void Hit(float _damage) {
        healthEnemy -= _damage;
        healthBar.fillAmount = healthEnemy / maxHealthEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        data = SaveSystem.LoadPlayer();
    }
}
