using UnityEngine;
public class BodyController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "SnakeBody":
                Debug.Log("Collision with snake body!");
                gameManager.GameOver();
                break;
            case "Food":
                Destroy(col.gameObject);
                gameManager.FoodConsumed();
                break;
            case "Walls":
                Debug.Log("Collided with wall!");
                gameManager.GameOver();
                break;
            default: break;
        }
    }
}
