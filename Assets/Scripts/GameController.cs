using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    /** 生成的障碍物对象*/
    public GameObject hazard;
    /** 障碍物生成的位置*/
    public Vector3 spawnValue;

    public int hazardCount;
    /** 障碍物出现的时间间隔*/
    public float spawnWait;
    /** 障碍物开始出现的时间差*/
    public float startWait;

    private int score;
    public Text scoreText;

    public Text gameOverText;
    private bool gameOver;

    public Text restartText;
    private bool restart;

    private void Start()
    {
        score = 0;
        gameOverText.text = "";
        gameOver = false;
        restartText.text = "";
        restart = false;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void addScore(int value)
    {
        Debug.Log("GameController addScore： " + value);
        score += value;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "GameOver";
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x),
                                                             spawnValue.y,
                                                             spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
                if (gameOver)
                {
                    restart = true;
                    restartText.text = "Press 'R' to Restart";
                }
            }
        }
    }
}
