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

        Vector3 worldPosition = new Vector3(0.0f, 0.0f, 0.0f); // 월드 좌표
        Camera mainCamera = Camera.main; // 사용할 카메라
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition); // 월드 좌표를 스크린 좌표로 변환

        Debug.Log($"WordPos:{worldPosition}, \n" +
                  $"ScreenPos:{screenPosition}");
    }
}
