using UnityEngine;

public enum PowerUpType
{
    Shield, Multiplier, SpeedBoost, Boom
}

public class PowerUpController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] public PowerUpType powerUpType;
    [SerializeField] Sprite shieldImg;
    [SerializeField] Sprite multiplierImg;
    [SerializeField] Sprite speedBoostImg;
    [SerializeField] Sprite boomImg;
    [SerializeField] Vector2 shieldScale = new Vector2(1.5f, 1.5f);
    [SerializeField] Vector2 multiplierScale = new Vector2(1.5f, 1.5f);
    [SerializeField] Vector2 speedBoostScale = new Vector2(1.5f, 1.5f);
    [SerializeField] Vector2 boomScale = new Vector2(1.5f, 1.5f);

    void Awake()
    {
        int enumCount = System.Enum.GetValues(typeof(PowerUpType)).Length;
        powerUpType = (PowerUpType)Random.Range(0, enumCount); 


        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) return;

        switch (powerUpType)
        {
            case PowerUpType.Shield:
                spriteRenderer.sprite = shieldImg;
                transform.localScale = new Vector3(shieldScale.x, shieldScale.y, transform.localScale.z);
                break;
            case PowerUpType.Multiplier:
                spriteRenderer.sprite = multiplierImg;
                transform.localScale = new Vector3(multiplierScale.x, multiplierScale.y, transform.localScale.z);
                break;
            case PowerUpType.SpeedBoost:
                spriteRenderer.sprite = speedBoostImg;
                transform.localScale = new Vector3(speedBoostScale.x, speedBoostScale.y, transform.localScale.z);
                break;
            case PowerUpType.Boom:
                spriteRenderer.sprite = boomImg;
                transform.localScale = new Vector3(boomScale.x, boomScale.y, transform.localScale.z);
                break;
        }
    }
}