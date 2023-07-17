using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMgr : MonoBehaviour
{
    public GameObject[] buckets;
    public GameObject[] balls;
    public int curCnt = 0;
    public int maxCnt = 0;
    public int correctCnt;
    public int insCorrectCnt;
    public int curLv = 1;
    public int maxLv = 4;
    public int maxStageCh = 10;

    public MapGenerator mapGenerator;
    public Text scoreText;
    public Text stageNumText;

    public int moveCount = 0;
    public Text Count;

    public GameObject option;

    public void SetBuckesAnsBalls()
    {
        StartCoroutine(FindBucketsAndBalls());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            option.SetActive(true);

        if (Application.platform == RuntimePlatform.Android)
            if (Input.GetKey(KeyCode.Escape))
                option.SetActive(true);
    }

    IEnumerator FindBucketsAndBalls()
    {
        yield return buckets = new GameObject[GameObject.FindGameObjectsWithTag("Bucket").Length];
        yield return balls = new GameObject[GameObject.FindGameObjectsWithTag("Ball").Length];

        buckets = GameObject.FindGameObjectsWithTag("Bucket");
        balls = GameObject.FindGameObjectsWithTag("Ball");
        curCnt = 0;
        maxCnt = balls.Length;

        scoreText.text = curCnt + " / " + maxCnt;
        stageNumText.text = "STAGE : " + curLv.ToString();
    }

    public void CheckBallPosition()
    {
        for (int i = 0; i < buckets.Length; i++)
        {
            for (int j = 0; j < balls.Length; j++)
            {
                if (buckets[i].transform.position == balls[j].transform.position)
                {
                    correctCnt++;
                    curCnt = correctCnt;
                }
            }
        }

        correctCnt = 0;
        scoreText.text = curCnt + " / " + maxCnt;

        if (curCnt == maxCnt)
        {
            curLv++;
            curCnt = 0;
            maxCnt = 0;
            if (curLv != maxLv)
            {
                moveCount = -1;
                mapGenerator.MapDestroy(curLv);
            }
            else{}
        }
    }
    public void ReTry()
    {        
        mapGenerator.MapDestroy(curLv);
        moveCount = 0;
    }

    public void ChangMapF()
    {
        //maxStageCh는 maxLv보다 1작게 입력하세요
        if (curLv != maxStageCh)
        {
            curLv = ++curLv;
            mapGenerator.MapDestroy(curLv);
        }
        else{ }
    }
    public void ChangMapB()
    {
        if(curLv != 1)
        {
            curLv = --curLv;
            mapGenerator.MapDestroy(curLv);
        }
        else{ }
    }
    public void PlayerMoveCount()
    {
        moveCount++;
        Count.text = moveCount.ToString();
    }
    public void Quit()
    {
        Application.Quit();
    }
}