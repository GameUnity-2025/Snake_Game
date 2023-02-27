using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "SnakeBody":
                Debug.Log("Collision with snake body!");
                LevelManager.Instance.GameOver();
                break;
            case "Food":
                Destroy(col.gameObject);
                LevelManager.Instance.FoodConsumed();
                break;
            case "Walls":
                Debug.Log("Collided with wall!");
                LevelManager.Instance.GameOver();
                break;
            default: break;
        }
    }
}
