﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    int enemylife = 3;


    Rigidbody2D rigid;
    public int nextMove;//다음 행동지표를 결정할 변수
    public int nextMoveY;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemylife -= 1;
            Destroy(collision.gameObject);
            if (enemylife == 0)
            {
                GameDirector.enemyCount -= 1;
                Room1_1GameDirector.enemyCount -= 1;
                Room1_2GameDirector.enemyCount -= 1;
                Destroy(this.gameObject);
            }
        }
    }

    void start()
    {
        Think();
    }
    // Start is called before the first frame update
    private void Awake()
    {

        rigid = GetComponent<Rigidbody2D>();
        Invoke("Think", 3); // 초기화 함수 안에 넣어서 실행될 때 마다(최초 1회) nextMove변수가 초기화 되도록함 
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
            rigid.velocity = new Vector2(nextMove, nextMoveY); //nextMove 에 0:멈춤 -1:왼쪽 1:오른쪽 으로 이동 
    }
    void Think()
    {//몬스터가 스스로 생각해서 판단 (-1:왼쪽이동 ,1:오른쪽 이동 ,0:멈춤  으로 3가지 행동을 판단)

        //Random.Range : 최소<= 난수 <최대 /범위의 랜덤 수를 생성(최대는 제외이므로 주의해야함)
        nextMove = Random.Range(-1, 2);
        nextMoveY = Random.Range(-1, 2);

        float time = Random.Range(2f, 5f);
        //Think(); : 재귀함수 : 딜레이를 쓰지 않으면 CPU과부화 되므로 재귀함수쓸 때는 항상 주의 ->Think()를 직접 호출하는 대신 Invoke()사용
        Invoke("Think", time); //매개변수로 받은 함수를 5초의 딜레이를 부여하여 재실행 
    }
   

}
