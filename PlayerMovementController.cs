using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementController : MonoBehaviour
{
    Transform Canvas;

    bool CanMove = true;
    float Speed = 15;
    float CurrentDePosition = 0;

    bool isDashing = false;
    bool CanDash = true;
    float DashStopWatch = 0;
    float DashDuration = 0.1f;
    float DashCoolDown = 3;
    float DashMultiplier = 6.25f;
    Vector2 InputForDash = Vector2.zero;

    Transform DashImage;
    Image DashUIBlocker;
    Text DashCDText;
    Color DefaultCoolDownColor;

    private void Start()
    {
        DefaultCoolDownColor = new Color(0, 0, 0, 0.55f);

        Canvas = GameObject.Find("Canvas").transform;
        DashImage = Canvas.Find("DashImage").transform;
        DashUIBlocker = DashImage.Find("DashBlocker").gameObject.GetComponent<Image>();
        DashCDText = DashUIBlocker.transform.Find("DashText").gameObject.GetComponent<Text>();
    }

    void Update()
    {
        CurrentDePosition = Speed * Time.deltaTime;

        #region Taking inputs for basic movement

        bool Right = Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.RightArrow);

        bool Left = Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.LeftArrow);

        bool Up = Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.UpArrow);

        bool Down = Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.DownArrow);
        #endregion

        #region Movement

        if(CanMove)
        {
            if ((Up || Down) && (Left || Right))//walking diagonaly
            {
                //will make the speed roughly equal to what it would be if it was walking only horizontally or vertically
                CurrentDePosition *= 0.7f;
            }

            if (Right)
            {
                if (!Left)
                {
                    InputForDash = new Vector2(CurrentDePosition, InputForDash.y);
                }
                else
                {
                    InputForDash = new Vector2(0, InputForDash.y);
                }
            }
            else if (Left)
            {
                InputForDash = new Vector2(-CurrentDePosition, InputForDash.y);
            }
            else
            {
                InputForDash = new Vector2(0, InputForDash.y);
            }

            if (Up)
            {
                if (!Down)
                {
                    InputForDash = new Vector2(InputForDash.x, CurrentDePosition);
                }
                else
                {
                    InputForDash = new Vector2(InputForDash.x, 0);
                }
            }
            else if (Down)
            {
                InputForDash = new Vector2(InputForDash.x, -CurrentDePosition);
            }
            else
            {
                InputForDash = new Vector2(InputForDash.x, 0);
            }
        }

        if (isDashing)
        {
            if(InputForDash == Vector2.zero)
            {
                InputForDash = new Vector2(CurrentDePosition, 0);
            }
            transform.position += (Vector3)(InputForDash * DashMultiplier);
        }
        else
        {
            transform.position += (Vector3)(InputForDash);
        }
        #endregion

        #region Rotation
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 perpendicular = Vector3.Cross(transform.position - mousePos, Vector3.forward);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
        #endregion

        #region Dash
        if (Input.GetKeyDown(KeyCode.Space))
            Dash();

        if (!CanDash)
        {
            DashStopWatch += Time.deltaTime;

            float RemainingTime = DashCoolDown - DashStopWatch;
            if(RemainingTime < 1)
            {
                DashCDText.text = (RemainingTime * 100).ToString("f0") + "<size=25>ms</size>";
            }
            else
            {
                DashCDText.text = RemainingTime.ToString("f1");
            }

            DashUIBlocker.fillAmount = RemainingTime / DashCoolDown;

            if (DashStopWatch > DashDuration)
            {
                DashCancel();
            }
            if (DashStopWatch > DashCoolDown)
            {
                DashUIBlocker.fillAmount = 1;
                DashUIBlocker.color = new Color(0, 0, 0, 0);
                DashCDText.text = "";

                CanDash = true;
                DashStopWatch = 0;
            }
        }
        #endregion
    }

    //Activates dash's boost, color change and activates relevant cooldown.
    public void Dash()
    {
        if (CanDash)
        {
            CanMove = false;
            isDashing = true;

            DashUIBlocker.color = DefaultCoolDownColor;
            CanDash = false;
        }
    }
    //Cancels dash's boost.
    void DashCancel()
    {
        CanMove = true;
        isDashing = false;
    }
}