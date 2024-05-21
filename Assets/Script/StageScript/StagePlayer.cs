using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagePlayer : MonoBehaviour
{
    public int speed = 2;
    Rigidbody2D rigid;
    SpriteRenderer rend;
    float h, v;

    public GameObject DialogWindow;
    public GameObject Stage1Button;
    public GameObject Stage2Button;
    public GameObject xx;

    public GameObject option;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        if (h > 0) rend.flipX = false;
        else rend.flipX = true;
        v = Input.GetAxisRaw("Vertical");
        rigid.velocity = new Vector2(h, v);

        if(Input.GetKey(KeyCode.Escape))
        {
            option.SetActive(true);
            Time.timeScale = 1;
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(h, v) * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.gameObject.CompareTag("StageBox"))
        {
            xx.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stage1"))
        {
            DialogWindow.SetActive(true);
            Stage1Button.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Stage2"))
        {
            DialogWindow.SetActive(true);
            Stage2Button.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("StageBox"))
        {
            xx.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stage1"))
        {
            DialogWindow.SetActive(false);
            Stage1Button.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Stage2"))
        {
            DialogWindow.SetActive(false);
            Stage2Button.SetActive(false);
        }
    }
}