using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public int enemyCount1; // 이쪽에 적군 숫자 넣
    public static int enemyCount;

    public int Point1;
    public static int Point;

    public static int stageCount = 0;
    public static int room1Count = 0;
    public static int room2Count = 0;

    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public static bool Star1Image;
    public static bool Star2Image;
    public static bool Star3Image;

    public float DestroyTime = 3.0f;
    public GameObject StarPos;
    public GameObject star;

    public GameObject Option;

    // Start is called before the first frame update
    void Start()
    {
        Point = Point1;
        enemyCount = enemyCount1;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Option.SetActive(true);
            Time.timeScale = 0;
        }

        if (star != null)
        {
            if (enemyCount == 0)
            {
                //생성안되서 생성 따로 해야할듯
                if(stageCount==0)
                {
                    star.SetActive(true);
                    StarPos.SetActive(true);
                    Destroy(StarPos, DestroyTime);
                }
            }
        }
        if (Point == 1)
        {
            Point1 += 1;
        }
        if (Point == 2)
        {
            Point1 += 1;
        }

        if(Point1 == 3)
        {
            if (stageCount==1)
            {
                SceneManager.LoadScene("GameClearScene");
                Destroy(gameObject);

            }
            else if (room1Count == 1)
            {
                SceneManager.LoadScene("GameClearScene");
                Destroy(gameObject);
            }
            else if (room2Count == 1)
            {
                SceneManager.LoadScene("GameClearScene");
                Destroy(gameObject);
            }
        }
        if (Star1Image == true)
        {
            Star1.SetActive(true);
        }
        if (Star2Image == true)
        {
            Star2.SetActive(true);
        }
        if (Star3Image == true)
        {
            Star3.SetActive(true);
        }
    }
    public void OptionClose()
    {
        Option.SetActive(false);
        Time.timeScale = 1;
    }
    public void Loading3()
    {
        SceneManager.LoadScene("Stage2Loading");
        Time.timeScale = 1;
    }
    public void Loading2()
    {
        SceneManager.LoadScene("StageLoading");
        Time.timeScale = 1;
    }
    public void Loading()
    {
        SceneManager.LoadScene("LoadingScene");
        Time.timeScale = 1;
    }
    public void GoGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GoStage()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        SceneManager.LoadScene("StageScene");
    }
    public void GoMain()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        SceneManager.LoadScene("MainScene");
    }
    public void GoStage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void GoStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void OptionTime()
    {
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Time.timeScale = 0f;
        Application.Quit();
    }
}
