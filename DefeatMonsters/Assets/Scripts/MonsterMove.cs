using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public float EnemySpeed;
    public bool moveleft = true;
    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 Dichuyen = transform.localPosition;
        if (moveleft) Dichuyen.x -= EnemySpeed * Time.deltaTime;
        else Dichuyen.x += EnemySpeed * Time.deltaTime;
        transform.localPosition = Dichuyen;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
    void Flip()
    {
        moveleft = !moveleft;
        Vector2 huong = transform.localScale;
        huong.x *= -1;
        transform.localScale = huong;
    }


}
