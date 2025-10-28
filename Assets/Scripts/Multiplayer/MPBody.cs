using UnityEngine;
public class MPBody : MonoBehaviour
{
    [SerializeField] MultiplayerManager gameManager;
    [SerializeField] Player player;
    bool shielding = false;
    public void TriggerShield()
    {
        shielding = !shielding;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "SnakeBody":
                if (!shielding)
                {
                    Debug.Log("Collision with snake body!");
                    gameManager.GameOver(player);
                }
                break;
            case "Food":
                gameManager.FoodConsumed(player, col.GetComponent<FoodController>().foodType);
                Destroy(col.gameObject);
                break;
            case "PowerUp":
                PowerUpType powerUpType = col.GetComponent<PowerUpController>().powerUpType;
                if (powerUpType == PowerUpType.Boom)
                {
                    Debug.Log("Boom powerup hit! Game Over!");
                    gameManager.GameOver(player);
                }
                else
                {
                    gameManager.PowerUpConsumed(player, powerUpType);
                }
                Destroy(col.gameObject);
                break;
            default: break;
        }
    }
}
