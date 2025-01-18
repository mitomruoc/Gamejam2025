using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab quả bóng
    public int maxBalls = 3;      // Số lượng bóng tối đa
    private int currentBallCount = 0;
    private GameObject selectedBall = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click trái để tạo bóng
        {
            if (currentBallCount < maxBalls)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject newBall = Instantiate(ballPrefab, mousePosition, Quaternion.identity);
                currentBallCount++;
            }
        }

        if (Input.GetMouseButtonDown(1) && selectedBall != null) // Click phải để giảm kích thước
        {
            Vector3 scale = selectedBall.transform.localScale;
            if (scale.x > 0.5f) // Kích thước tối thiểu
            {
                selectedBall.transform.localScale -= Vector3.one * 0.1f;
            }
        }
    }

    void OnMouseDown()
    {
        // Chọn bóng hiện tại
        if (selectedBall == null)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Bubble"))
            {
                selectedBall = hit.collider.gameObject;
            }
        }
    }

    void OnMouseUp()
    {
        selectedBall = null; // Bỏ chọn bóng khi thả chuột
    }
}
