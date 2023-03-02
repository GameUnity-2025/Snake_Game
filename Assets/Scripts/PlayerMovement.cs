using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 newDirection;
    Vector3 headPos;
    Vector3 oldHeadPos;
    [SerializeField] float speed = 0.5f;
    [SerializeField] float step = 0.5f;
    [SerializeField] GameObject bodyPrefab;
    [SerializeField] Transform[] bodies;
    bool changeVal;
    int length;
    int count;
    void Awake()
    {
        length = -1;
    }
    void Start()
    {
        newDirection = Vector3.right;
        bodies = GetComponentsInChildren<Transform>();
        if (bodies.Length < 1)
        {
            Debug.LogError("No body segments found");
            return;
        }
        count = 1;
        StartCoroutine(MoveHead());
    }
    IEnumerator MoveHead()
    {
        while (true)
        {
            Vector3[] oldPositions = new Vector3[bodies.Length];
            Debug.Log("Updating Values!");
            for (int i = 0; i < bodies.Length; i++)
            {
                oldPositions[i] = bodies[i].position;
            }

            headPos = oldPositions[1];
            headPos += new Vector3(step * newDirection.x, step * newDirection.y, 0);
            bodies[1].position = headPos;

            for (int i = 2; i < bodies.Length; i++)
            {
                if (bodies[i] != null && oldPositions[i - 1] != null)
                    MoveBody(i, oldPositions[i - 1]);
            }
            yield return new WaitForSeconds(speed);
        }
    }
    void MoveBody(int index, Vector3 prevPos)
    {
        Debug.Log("Index: " + index + " Current position : " + bodies[index].transform.position + " New position : " + prevPos);
        bodies[index].transform.position = prevPos;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && newDirection != Vector3.down)
        {
            newDirection = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && newDirection != Vector3.up)
        {
            newDirection = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && newDirection != Vector3.right)
        {
            newDirection = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && newDirection != Vector3.left)
        {
            newDirection = Vector3.right;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided!");
    }
}
