using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    public int speed;
    Rigidbody2D rigid;
    float h, v;
    SpriteRenderer rend;

    int life = 6;
    GameObject life3;
    GameObject life2;

    
    public static int Stage1;
    public static int Stage2;
    SpriteRenderer spriteRenderer;

    bool noDamaged= false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        life3 = GameObject.Find("life3");
        life2 = GameObject.Find("life2");
        
        
      
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        if (h > 0) rend.flipX = false;
        else rend.flipX = true;
        v = Input.GetAxisRaw("Vertical");

        rigid.velocity = new Vector2(h, v);


    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v) * speed;
    }


    void OnDamaged(Vector2 targetPos)
    {
        
        gameObject.layer = 8;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        noDamaged = true;
        GetComponent<AudioSource>().Play();
        Invoke("OffDamaged", 2);
    }
    void OffDamaged()
    {
        noDamaged = false;
        gameObject.layer = 7;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(GameDirector.stageCount==0)
        {
            if (collision.transform.tag == "1Star")
            {
                GameDirector.Star1Image = true;
                GameDirector.stageCount += 1;
                GameDirector.Point += 1;
                SceneManager.LoadScene("Stage1");
                Destroy(collision.gameObject);
            }
        }
        if (collision.transform.tag == "1_1Star")
        {
            GameDirector.Point += 1;
            GameDirector.room1Count += 1;
            GameDirector.Star2Image=true;
            SceneManager.LoadScene("Stage1");
        }
        if (collision.transform.tag == "1_2Star")
        {
            GameDirector.Star3Image = true;
            GameDirector.Point += 1;
            GameDirector.room2Count += 1;
            SceneManager.LoadScene("Stage1");
        }
        //////////stage1 star///////////////
        if(collision.transform.tag=="BossStar")
        {
            SceneManager.LoadScene("GameClearScene");
        }
            if (collision.transform.tag == "enemy" || collision.transform.tag == "Cactus"|| collision.transform.tag == "enemyBullet")
            {
                if (noDamaged == false)
                 {
                   life -= 1;
                 }
                if (life == 4)
                {
                   Destroy(life3);
                   OnDamaged(collision.transform.position);
                  
                }
                else if (life == 2)
                {
                   Destroy(life2);
                   OnDamaged(collision.transform.position);
                  
                }
                else if (life == 0)
                {
                    SceneManager.LoadScene("GameOverScene");
                }
            }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GameDirector.room1Count == 0)
        {
            if (collision.transform.tag == "Stage1_1")
            {
                if (Input.GetKey(KeyCode.X))
                {
                    GameDirector.room1Count += 1;
                    SceneManager.LoadScene("Stage1_1");
                }
            }
        }
        if (GameDirector.room2Count == 0)
        {
            if (collision.transform.tag == "Stage1_2")
            {
                if (Input.GetKey(KeyCode.X))
                {
                    GameDirector.room2Count += 1;
                    SceneManager.LoadScene("Stage1_2");
                }
            }
        }
    }
}
