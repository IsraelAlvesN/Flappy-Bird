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
        //move object
        float x = GameManager.Instance.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        //Destroy object
        if(transform.position.x <= -GameManager.Instance.obstacleOffSetX)
        {
            Destroy(gameObject);
        }
    }
}
