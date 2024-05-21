using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public int Bosslife ;
    Rigidbody2D rigid;

    public GameObject BossStar;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bosslife -= 1;
            Destroy(collision.gameObject);
            if (Bosslife == 0)
            {
                GameDirector.enemyCount -= 1;
                Room1_1GameDirector.enemyCount -= 1;
                Room1_2GameDirector.enemyCount -= 1;
                Destroy(this.gameObject);
                BossStar.SetActive(true);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
