﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMonster : MonoBehaviour
{
    Vector3 pos; //현재위치
    float delta = 0.3f; // 좌(우)로 이동가능한 (x)최대값
    float speed = 3.0f; // 이동속도

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;
        v.x += -delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
