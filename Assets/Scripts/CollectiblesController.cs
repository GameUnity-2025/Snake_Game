using UnityEngine;
public class CollectiblesController : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] Transform LeftBorder;
    [SerializeField] Transform RightBorder;
    [SerializeField] Transform TopBorder;
    [SerializeField] Transform BottomBorder;
    float minX, minY, maxX, maxY;
    float newX, newY;
    bool unique;
    void Awake()
    {
        minX = LeftBorder.position.x + 0.5f;
        maxX = RightBorder.position.x - 0.5f;
        minY = BottomBorder.position.y + 0.5f;
        maxY = TopBorder.position.y - 0.5f;
    }
    void Start()
    {
        if (transform.childCount < 1)
            SpawnFood();
    }
    // Vector3 GetPosition(Transform[] list)
    // {
    //     unique = false;
    //     Vector3 newPos = new Vector3(0f, 0f, 0f);
    //     while (unique)
    //     {
    //         newX = Random.Range(minX, maxX);
    //         newY = Random.Range(minY, maxY);

    //         newX = Mathf.Round(newX * 2) / 2;
    //         newY = Mathf.Round(newY * 2) / 2;

    //         newPos = new Vector3(newX, newY, 0f);

    //         for (int i = 0; i < list.Length; i++)
    //         {
    //             if (list[i].position != newPos)
    //             {
    //                 unique = false;
    //             }
    //             else
    //             {
    //                 Debug.Log("Position already occupied by snake");
    //                 unique = true;
    //             }
    //         }
    //     }
    //     return newPos;
    // }
    public void SpawnFood()
    {
        newX = Random.Range(minX, maxX);
        newY = Random.Range(minY, maxY);

        newX = Mathf.Round(newX * 2) / 2;
        newY = Mathf.Round(newY * 2) / 2;

        Vector3 newPos = new Vector3(newX, newY, 0f);
        GameObject newFood = Instantiate(foodPrefab, newPos, Quaternion.identity);
    }
}
