using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        cam.orthographicSize = 10;

        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        Debug.Log($"ScreenWH : {screenWidth}, {screenHeight}");

        Vector3 worldPosition = new Vector3(0.0f, 0.0f, 0.0f); // ���� ��ǥ
        Camera mainCamera = Camera.main; // ����� ī�޶�
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition); // ���� ��ǥ�� ��ũ�� ��ǥ�� ��ȯ

        Debug.Log($"WordPos:{worldPosition}, \n" +
                  $"ScreenPos:{screenPosition}");
    }
}
