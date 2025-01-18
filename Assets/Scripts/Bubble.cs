using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float maxScale = 10f;      // Kích thước tối đa của quả bóng
    public float growthRate = 1f;    // Hệ số tăng/giảm kích thước
    public float minScale = 0.059f;  // Kích thước tối thiểu của quả bóng
    private float initialScale;      // Kích thước ban đầu
    public DraggableBouncyObject dragg;
    
    void Start()
    {
        initialScale = transform.localScale.x;  // Lấy kích thước ban đầu
    }

    void Update()
    {
        
    }

    void OnMouseOver()
    {
        // Lấy giá trị từ bánh xe cuộn chuột
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Thay đổi kích thước dựa trên giá trị cuộn
        if (scroll != 0f && (dragg == null || !dragg.isMoving))
        {
            float scaleChange = scroll * growthRate;
            Vector3 newScale = transform.localScale + Vector3.one * scaleChange;

            // Giới hạn kích thước trong khoảng [minScale, maxScale]
            newScale = Vector3.Max(Vector3.one * minScale, Vector3.Min(Vector3.one * maxScale, newScale));

            transform.localScale = newScale;
        }
        // Hủy đối tượng nếu nhấn chuột phải
        if (Input.GetMouseButton(1))
        {
            Spawn.Instance.currentBallCount--;
            Destroy(this.gameObject);
        }
    }

    public float GetElasticForce()
    {
        return transform.localScale.x / initialScale;  // Tỷ lệ kích thước
    }
}
