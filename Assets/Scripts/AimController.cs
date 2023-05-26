using UnityEngine;

public class AimController : MonoBehaviour
{
    Camera MainCam;

    void Start()
    {
        MainCam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePosition = MainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = (mousePosition - transform.position);

        #region Rotate
        float angle = AngleBetweenTwoPoints(transform.position, mousePosition);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90));
        #endregion

        #region CameraMover
        Vector2 CamPos = (Vector2)transform.position + (mouseDirection / 3.5f);
        MainCam.transform.position = new Vector3(CamPos.x, CamPos.y, -10);
        #endregion
    }

    //Calculates the angle between two vector2 points in degrees.
    float AngleBetweenTwoPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
