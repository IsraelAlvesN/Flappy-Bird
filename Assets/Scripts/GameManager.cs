using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float obstacleInterval = 1;
    public float obstacleSpeed = 5;
    public float obstacleOffSetX = 0;
    public Vector2 obstacleOffSetY = new Vector2(0, 0);
    [FormerlySerializedAs("prefabs")]
    public List<GameObject> obstaclePrefabs;

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

}
