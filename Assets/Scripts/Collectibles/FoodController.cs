using UnityEngine;

public enum FoodType
{
    Gainer,
    Burner
}

public class FoodController : MonoBehaviour
{
    [SerializeField] public FoodType foodType;

    // Optional: assign sprites or colors in the Inspector to distinguish types
    [Header("Optional visuals (set one)")]
    [Tooltip("If set, this sprite will be used for Gainer food")]
    public Sprite gainerSprite;
    [Tooltip("If set, this sprite will be used for Burner food")]
    public Sprite burnerSprite;

    [Tooltip("If sprites are not provided, these colors will tint the SpriteRenderer")]
    public Color gainerColor = Color.red;
    public Color burnerColor = Color.green;

    SpriteRenderer spriteRenderer;

    void Awake()
    {
        // Randomly pick a food type (50/50)
        foodType = (FoodType)Random.Range(0, 2);

        // Try to get the SpriteRenderer on this prefab
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        // Apply visuals so player can distinguish Gainer vs Burner
        ApplyVisuals();
    }

    public void ApplyVisuals()
    {
        if (spriteRenderer == null) return;

        switch (foodType)
        {
            case FoodType.Gainer:
                if (gainerSprite != null)
                    spriteRenderer.sprite = gainerSprite;
                else
                    spriteRenderer.color = gainerColor;
                break;
            case FoodType.Burner:
                if (burnerSprite != null)
                    spriteRenderer.sprite = burnerSprite;
                else
                    spriteRenderer.color = burnerColor;
                break;
            default:
                break;
        }
    }
}
