using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject VictoryScreen;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Chiến thắng!");
            // Hiển thị UI chiến thắng hoặc chuyển cảnh
            VictoryScreen.SetActive(true);
        }
    }
}
