using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 newDirection;
    Vector3 playerPos;
    [SerializeField] float speed = 0.5f;
    [SerializeField] float step = 0.5f;
    void Awake()
    {
        playerPos = transform.position;
    }
    void Start()
    {
        newDirection = Vector3.right;
        StartCoroutine(MovePlayer());
    }
    IEnumerator MovePlayer()
    {
        while (true)
        {
            playerPos += new Vector3(step * newDirection.x, step * newDirection.y, 0);
            transform.position = playerPos;
            yield return new WaitForSeconds(speed);
        }
    }
    void Update()
    {
        playerPos = transform.position;
        if (Input.GetKeyDown(KeyCode.W))
        {
            newDirection = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            newDirection = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            newDirection = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            newDirection = Vector3.right;
        }
    }

}
