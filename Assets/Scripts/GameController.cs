using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text restartText;
    public UnityEngine.UI.Text gameOverText;

    private int score;
    private bool gameOver;
    private bool restart;
    
   

     void Start()
    {
        gameOver = false;
        restart = false;
       
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine( SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (gameOver!=true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,
                spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    

    void Update()
    {

        


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }


        if (gameOver)
        {
            if (restart)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
    }

    public void GameOver()
    {
        restartText.text = "Press 'R' for Restart";
        restart = true;
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
}
