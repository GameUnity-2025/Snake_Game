using UnityEngine;
public enum PowerUpType
{
    Shield, Multiplier, SpeedBoost
}
public class PowerUpController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] public PowerUpType powerUpType;
    [SerializeField] Sprite shieldImg;
    [SerializeField] Sprite multiplierImg;
    [SerializeField] Sprite speedBoostImg;
    [SerializeField] Vector2 shieldScale = new Vector2(1.5f, 1.5f);
    [SerializeField] Vector2 multiplierScale = new Vector2(1.5f, 1.5f);
    [SerializeField] Vector2 speedBoostScale = new Vector2(1.5f, 1.5f);

    void Awake()
    {
        powerUpType = (PowerUpType)Random.Range(0, 3);
        switch (powerUpType)
        {
            case PowerUpType.Shield:
                spriteRenderer.sprite = shieldImg;
                transform.localScale = shieldScale;
                break;
            case PowerUpType.Multiplier:
                spriteRenderer.sprite = multiplierImg;
                transform.localScale = multiplierScale;
                break;
            case PowerUpType.SpeedBoost:
                spriteRenderer.sprite = speedBoostImg;
                transform.localScale = speedBoostScale;
                break;
        }
    }
}
