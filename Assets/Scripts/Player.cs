using UnityEngine;

public class Player : MonoBehaviour
{
    public float bounceMultiplier = 10f;  // Lực đàn hồi
    private bool isBouncing = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            // Lấy thông tin về quả bóng
            Bubble ball = collision.gameObject.GetComponent<Bubble>();

            if (ball != null)
            {
                // Tính toán góc phản lực
                Vector2 contactPoint = collision.contacts[0].point;
                Vector2 ballCenter = collision.gameObject.transform.position;
                Vector2 forceDirection = (contactPoint - ballCenter).normalized;

                // Áp dụng lực đàn hồi
                float force = ball.GetElasticForce() * bounceMultiplier;
                GetComponent<Rigidbody2D>().AddForce(forceDirection * force, ForceMode2D.Impulse);
                isBouncing = true;
            }
        }
    }

    void Update()
    {
        // Kiểm tra nếu nhân vật rơi ra ngoài màn hình
        if (transform.position.y < -10f && !isBouncing)
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);  // Load lại Scene hiện tại
    }
}
