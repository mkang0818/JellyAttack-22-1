using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemeyFollow : MonoBehaviour
{
    Transform target;
    Rigidbody2D rigid;

    [Header("???")]
    [SerializeField] [Range(1f, 4f)] float moveSpeed = 3f;

    [Header("?")]
    [SerializeField] [Range(0f, 5f)] float ContactDistance = 1f;

    public float moveScale;

    bool follow = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            
    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        follow = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
    }

    void Update()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
            if (Vector2.Distance(transform.position, target.position) < moveScale)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
            else
                rigid.velocity = Vector2.zero;
        
    }
}
