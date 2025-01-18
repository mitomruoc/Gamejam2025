using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float maxScale = 10f;  // Kích thước tối đa của quả bóng
    public float growthRate = 0.01f;  // Tốc độ tăng kích thước
    private float initialScale;  // Kích thước ban đầu
    public bool isGrowing = false;  // Kiểm tra xem có đang phóng to không
    public bool isShrinking = false;
    public float minScale = 0.059f;
    public DraggableBouncyObject dragg;

    void Start()
    {
        initialScale = transform.localScale.x;  // Lấy kích thước ban đầu
    }

    void Update()
    {
        // Phóng to khi đang giữ chuột trái
        if (isGrowing && transform.localScale.x < maxScale)
        {
            transform.localScale += Vector3.one * growthRate * Time.deltaTime;
        }
        // Thu nhỏ khi đang giữ chuột phải
        else if (isShrinking && transform.localScale.x > 0)
        {
            transform.localScale -= Vector3.one * growthRate * Time.deltaTime;
        }
    }

    void OnMouseOver()
    {
        // Nhấn giữ chuột trái để phóng to
        if (Input.GetMouseButton(0))
        {
            if (dragg.isMoving == false)
            {
                isGrowing = true;
                isShrinking = false;
            }
            else
            {
                isGrowing = false;
                isShrinking = false;
            }
            
        }
        // Nhấn giữ chuột phải để thu nhỏ
        else if (Input.GetMouseButton(1))
        {
            isGrowing = false;
            isShrinking = true;
        }
        else if (Input.GetMouseButton(2))
        {
            Destroy(this.gameObject);
        }
        else
        {
            isGrowing = false;
            isShrinking = false;
        }
    }

    //void OnMouseExit()
    //{
    //    // Ngừng phóng to/thu nhỏ khi chuột không còn ở trên bóng
    //    isGrowing = false;
    //    isShrinking = false;
    //}

    public float GetElasticForce()
    {
        return transform.localScale.x / initialScale;  // Tỷ lệ kích thước
    }
}
