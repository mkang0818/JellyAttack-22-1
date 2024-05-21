using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1_1GameDirector : MonoBehaviour
{
    public int enemyCount1;
    public static int enemyCount; 

    public GameObject Star;

    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = enemyCount1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Star != null)
        {
            if (enemyCount == 0)
            {
                Star.SetActive(true);
            }
        }
        if (GameDirector.Star1Image == true)
        {
            Star1.SetActive(true);
        }
        if (GameDirector.Star2Image == true)
        {
            Star2.SetActive(true);
        }
        if (GameDirector.Star3Image == true)
        {
            Star3.SetActive(true);
        }

    }
}
