using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float maxScale = 2f;  // Kích thước tối đa của quả bóng
    public float growthRate = 0.1f;  // Tốc độ tăng kích thước
    private float initialScale;  // Kích thước ban đầu
    private bool isGrowing = false;  // Kiểm tra xem có đang phóng to không

    void Start()
    {
        initialScale = transform.localScale.x;  // Lấy kích thước ban đầu
    }

    void Update()
    {
        if (isGrowing && transform.localScale.x < maxScale)
        {
            // Tăng kích thước bóng
            transform.localScale += Vector3.one * growthRate * Time.deltaTime;
        }
        else if (!isGrowing && transform.localScale.x > initialScale)
        {
            // Thu nhỏ bóng về kích thước ban đầu
            transform.localScale -= Vector3.one * growthRate * Time.deltaTime;
        }
    }

    void OnMouseDown()
    {
        isGrowing = true;  // Bắt đầu phóng to khi nhấn chuột
    }

    void OnMouseUp()
    {
        isGrowing = false;  // Ngừng phóng to khi thả chuột
    }

    public float GetElasticForce()
    {
        return transform.localScale.x / initialScale;  // Tỷ lệ kích thước
    }
}
