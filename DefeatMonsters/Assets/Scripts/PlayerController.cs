using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int id;
    public float healthPlayer;
    public float maxHealth;
    public float dame;
    public float coins;
    public Image healthBar;
    public Text CoinsText;
    public bool chkDie = false;
    public int playerSpeed =10 ;
    private bool facingRight = true;
    public int playerJumpPower = 1250;
    public GameManager gameManager;
    private float moveX;
    private float moveY;
    private MonsterMove Enemy;
    private Player_Animation_Controller animation_Controller;

    int maxJump = 2;
    int jumps = 0;
    PlayerData data;
    // Start is called before the first frame update
    void Start()
    {
        data = SaveSystem.LoadPlayer();
        id = data.id;
        healthPlayer = data.healthPlayer;
        maxHealth = data.maxHealth;
        dame = data.dame;
        coins = data.coins;

        animation_Controller = GetComponent<Player_Animation_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 2) 
        {
            
            CoinsText.text = "COIN: " + coins.ToString();
            healthBar.fillAmount = healthPlayer / maxHealth;
            if (!chkDie)
            {
                PlayerMove();
            }
            if (healthPlayer <= 0) 
            {
                StartCoroutine(Die());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        jumps = 0;
        if(other.gameObject.tag == "Enemy")
        {
            // animation_Controller.Attack();
            // dameTest = GameObject.FindGameObjectWithTag("Enemy");
            Enemy = other.gameObject.GetComponent<MonsterMove>();
            Enemy.Hit(dame);
            Hit(Enemy.dame);
            if(Enemy.healthEnemy <= 0){
                 Destroy(other.gameObject);
            }
            // Debug.Log(Enemy.healthEnemy);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.tag == "Enemy")
        // {
        //     Debug.Log("chammmmmmmmm");
        // }
        if(collision.tag == "WIN")
        {
            SaveSystem.SavePlayer(this);
            gameManager.GameWin();
        }

        if(collision.tag == "coins")
        {
            coins += 5;
            Destroy(collision.gameObject);
        }

        if(collision.tag == "traps")
        {
            Hit(1000);
        }

        if(collision.tag == "die")
        {
            StartCoroutine(Die());
        }
    }

    public void Hit(float _damage) {
        healthPlayer -= _damage;
    }

    IEnumerator Die()
    {
        chkDie = true;
        animation_Controller.Death();
        yield return new WaitForSeconds(1);
        gameManager.GameOver();
    }

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        if(moveX == 0) {
            animation_Controller.Idle();
        }
        else
        {
            animation_Controller.Run();
        }
        if(moveY == 1 ){
            animation_Controller.Stun();
        }
        //test attack 
        if (Input.GetKeyUp(KeyCode.Z))
        {
            animation_Controller.Attack();
        }
        //test stun
        if (Input.GetKeyDown(KeyCode.C))
        {
            animation_Controller.Stun();
        }
        if (Input.GetButtonDown("Jump") && (jumps < maxJump))
        {
            Jump();
            jumps++;
        }
        if(moveX<0.0f && facingRight == true)
        {
            FlipPlayer();

        }
        else if(moveX>0.0f && facingRight == false)
        {
            FlipPlayer(); 
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
    }
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
