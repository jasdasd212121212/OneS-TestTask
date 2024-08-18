using UnityEngine;

public class ScreenBordersClamper : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _leftBorder;
    [SerializeField] private BoxCollider2D _rightBorder;
    [SerializeField] private BoxCollider2D _downBorder;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        SetBorder(_leftBorder, Vector3.left, 0);
        SetBorder(_rightBorder, Vector3.right, 1);
        SetBorder(_downBorder, -Vector3.up, 2);
    }

    private void SetBorder(BoxCollider2D border, Vector3 direction, int planeIndex)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

        Ray ray = new Ray(_camera.transform.position, direction);
        planes[planeIndex].Raycast(ray, out float distance);

        Transform borderTransform = border.transform;

        borderTransform.position = _camera.transform.position;
        borderTransform.position = borderTransform.position + direction * distance;
    }
}