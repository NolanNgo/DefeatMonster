using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public float EnemySpeed;
    public bool moveleft = true;
    public float dame ;
    public float healthEnemy;
    public PlayerData data;
    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 Dichuyen = transform.localPosition;
        if (moveleft) Dichuyen.x -= EnemySpeed * Time.deltaTime;
        else Dichuyen.x += EnemySpeed * Time.deltaTime;
        transform.localPosition = Dichuyen;
    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.tag == "Player")
    //     {
    //         Debug.Log("Chammmmmmmmmmmmmmmmm");
    //     }
    // } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if(collision.gameObject.tag == "Player")
        // {
        //     healthEnemy -= data.dame;
        //     if(healthEnemy<=0)
        //     {
        //         Destroy(this);
        //         Debug.Log("Enemy Destroy");
        //     }
        //     // Debug.Log("Dame: "+data.dame.ToString());
        //     // Debug.Log("Enemy");
        // }
        if (collision.contacts[0].normal.x > 0)
        {
            Flip();
            moveleft = false;
            
        }
        else 
        {
            Flip();
            moveleft = true;
            
        }
        
    }
    public void Hit(float _damage) {
        healthEnemy -= _damage;
    }
    void Flip()
    {
        moveleft = !moveleft;
        Vector2 huong = transform.localScale;
        huong.x *= -1;
        transform.localScale = huong;
    }
    void Update()
    {
        data = SaveSystem.LoadPlayer();
    }

}
