using UnityEngine;

public class DraggableBouncyObject : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isDragging = false;
    private Vector3 offset;
    public Bubble bubble;

    [SerializeField] private float dragSpeed = 10f; // Tốc độ kéo thả
    public bool isMoving = false; // Biến kiểm tra xem đối tượng có đang di chuyển không
    [SerializeField] private float velocityThreshold = 0.1f; // Ngưỡng vận tốc để xác định đối tượng có di chuyển hay không

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // Tránh đi xuyên vật thể
    }

    private void Update()
    {
        // Kiểm tra vận tốc để xác định đối tượng có đang di chuyển không
        isMoving = rb.velocity.magnitude > velocityThreshold;
    }

    private void OnMouseDown()
    {
        // Kích hoạt kéo thả
        isDragging = true;
        rb.isKinematic = true; // Tạm thời tắt lực vật lý
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 targetPosition = GetMouseWorldPosition() + offset;

            // Di chuyển đối tượng bằng vận tốc
            Vector2 newVelocity = (targetPosition - transform.position) * dragSpeed;
            rb.velocity = newVelocity;
        }
    }

    private void OnMouseUp()
    {
        // Kích hoạt lại lực vật lý khi thả
        isDragging = false;
        rb.isKinematic = true;

        rb.velocity = Vector2.zero; // Xóa vận tốc hiện tại
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
