using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    void Start()
    {
        
    }

    //This will update with a fixed frame rate, according the game physics
    void FixedUpdate()
    {
        //get gameManager
        var gameManager = GameManager.Instance;
        //ignore if game is over
        if (gameManager.IsGameOver())
        {
            return;
        }

        //move object
        float x = gameManager.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        //Destroy object
        if(transform.position.x <= -gameManager.obstacleOffSetX)
        {
            Destroy(gameObject);
        }
    }
}
