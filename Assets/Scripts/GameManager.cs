using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float obstacleInterval = 1;
    public float obstacleSpeed = 5;
    public float obstacleOffSetX = 0;
    public Vector2 obstacleOffSetY = new Vector2(0, 0);
    [FormerlySerializedAs("prefabs")]
    public List<GameObject> obstaclePrefabs;
    [HideInInspector]
    public int score;
    private bool isGameOver = false;

    private void Awake()
    {
        //Singleton
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public bool IsGameActive()
    {
        return !isGameOver;
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public void EndGame()
    {
        isGameOver = true;
        Debug.Log("GameOver. Your score was: " + score);

        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay)
    {
        // wait 2 seconds(delay)
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(0);
    }

}
