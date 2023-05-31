using UnityEngine;

public class AimController : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    private float smoothing;
    [SerializeField]
    private float lookDistance;
    Vector3 offset;
    private void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        #region MoveCamera
        Vector3 mousePos = gameObject.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition);
        Vector3 mouseOffset = new Vector3((Mathf.Clamp(mousePos.x, 0, 1) - 0.5f) * lookDistance, (Mathf.Clamp(mousePos.y, 0, 1) - 0.5f) * lookDistance);
        Vector3 targetCamPos = target.position + offset + mouseOffset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        #endregion
    }

    //Calculates the angle between two vector2 points in degrees.
    float AngleBetweenTwoPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
