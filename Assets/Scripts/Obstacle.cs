using UnityEngine;

public class Bird : MonoBehaviour
{
    public Transform startPoint; // Điểm bắt đầu
    public Transform finishPoint; // Điểm kết thúc
    public float speed = 2f; // Tốc độ di chuyển

    private float targetX; // Tọa độ X mục tiêu hiện tại
    private float fixedY; // Tọa độ Y cố định
    private float fixedZ; // Tọa độ Z cố định
    private bool movingToFinish; // Trạng thái di chuyển (true: về điểm kết thúc, false: về điểm bắt đầu)

    private void Start()
    {
        // Lưu giá trị Y và Z cố định
        fixedY = transform.position.y;
        fixedZ = transform.position.z;

        // Bắt đầu tại startPoint
        transform.position = new Vector3(startPoint.position.x, fixedY, fixedZ);
        targetX = finishPoint.position.x;
        movingToFinish = true;
    }

    private void Update()
    {
        // Di chuyển GameObject dọc theo trục X về phía tọa độ mục tiêu
        float newX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        transform.position = new Vector3(newX, fixedY, fixedZ);

        // Kiểm tra nếu đã chạm đến điểm đích
        if (Mathf.Abs(transform.position.x - targetX) < 0.1f)
        {
            // Đổi hướng mục tiêu
            if (movingToFinish)
            {
                targetX = startPoint.position.x; // Quay về điểm bắt đầu
            }
            else
            {
                targetX = finishPoint.position.x; // Quay về điểm kết thúc
            }
            movingToFinish = !movingToFinish; // Đảo trạng thái

            // Quay đầu 180 độ
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
