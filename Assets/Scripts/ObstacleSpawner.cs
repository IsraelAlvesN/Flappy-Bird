using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float cooldown = 0;

    void Start()
    {
        
    }
    void Update()
    {
        //get gameManager
        var gameManager = GameManager.Instance;
        //ignore if game is over
        if (gameManager.IsGameOver())
        {
            return;
        }

        cooldown -= Time.deltaTime;
        if(cooldown <= 0f)
        {
            cooldown = gameManager.obstacleInterval;

            //Spawn Obstacle
            int prefabIndex = Random.Range(0, gameManager.obstaclePrefabs.Count);
            GameObject prefab = gameManager.obstaclePrefabs[prefabIndex];

            float x = gameManager.obstacleOffSetX;
            float y = Random.Range(gameManager.obstacleOffSetY.x, gameManager.obstacleOffSetY.y);
            Vector3 position = new Vector3(x, y, -0.26f);

            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, rotation);
        }
    }
}
