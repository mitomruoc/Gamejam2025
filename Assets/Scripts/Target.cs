using UnityEngine;

public class Target : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Chiến thắng!");
            // Hiển thị UI chiến thắng hoặc chuyển cảnh
        }
    }
}
