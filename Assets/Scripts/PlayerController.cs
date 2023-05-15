using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody myRB;
    public float jumpPower = 10;
    public float jumpInterval = 0.5f;
    public float jumpCooldown = 0;

    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        jumpCooldown -= Time.deltaTime;
        bool canJump = jumpCooldown <= 0;

        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        jumpCooldown = jumpInterval;

        myRB.velocity = Vector3.zero;
        myRB.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }

    private void OnCustomCollisionEnter(GameObject other)
    {
        bool isSensor = other.CompareTag("PointSensor");
        if (isSensor)
        {
            //increase point
            Debug.Log("Point");
        }
        else
        {
            //gameOver
            Debug.Log("GameOver");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }
}
