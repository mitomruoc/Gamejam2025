using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Nhân vật mà camera sẽ theo dõi
    public GameObject startPoint; // Điểm bắt đầu
    public GameObject finishPoint; // Điểm kết thúc
    public float moveSpeed = 5f; // Tốc độ di chuyển camera khi sử dụng phím mũi tên
    private bool followPlayer = true; // Trạng thái theo dõi nhân vật
    private Vector3 initPosition; // Vị trí mặc định của camera
    private Quaternion initRotation; // Góc nhìn mặc định của camera

    private void Start()
    {
        // Lưu vị trí và góc nhìn mặc định
        initPosition = transform.position;
        initRotation = transform.rotation;
    }

    private void Update()
    {
        // Di chuyển camera thủ công bằng phím mũi tên
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            followPlayer = false; // Ngừng theo dõi nhân vật khi di chuyển thủ công
            Vector3 newPosition = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

            // Giới hạn vị trí camera
            float minX = startPoint.transform.position.x;
            float maxX = finishPoint.transform.position.x;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            transform.position = newPosition;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            followPlayer = false; // Ngừng theo dõi nhân vật khi di chuyển thủ công
            Vector3 newPosition = transform.position + Vector3.right * moveSpeed * Time.deltaTime;

            // Giới hạn vị trí camera
            float minX = startPoint.transform.position.x;
            float maxX = finishPoint.transform.position.x;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            transform.position = newPosition;
        }

        // Khi nhấn phím Space, camera quay về vị trí mặc định và theo dõi nhân vật
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = initPosition; // Đưa camera về vị trí mặc định
            transform.rotation = initRotation; // Đưa camera về góc nhìn mặc định
            followPlayer = true; // Bắt đầu theo dõi nhân vật
        }
    }

    private void LateUpdate()
    {
        // Camera theo dõi nhân vật trên trục X nếu trạng thái followPlayer là true
        if (followPlayer && player != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = player.position.x;

            // Giới hạn vị trí camera trong khoảng từ StartPoint đến FinishPoint
            float minX = startPoint.transform.position.x;
            float maxX = finishPoint.transform.position.x;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

            transform.position = newPosition;
        }
    }
}
