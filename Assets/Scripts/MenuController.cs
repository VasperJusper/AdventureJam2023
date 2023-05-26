using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    enum menus
    {
        Pause,
        Upgrade,
        Envanter
    }

    bool gamePaused = false;

    Transform GeneralMenuBackground;

    Transform CurrentMenuIndicator;

    Transform PauseText;
    Transform EnvanterText;
    Transform UpgradesText;

    Transform PauseMenu;
    Transform EnvanterMenu;
    Transform UpgradesMenu;

    menus CurrentMenu = menus.Pause;

    private void Start()
    {
        GeneralMenuBackground = transform.Find("GeneralMenuBackground");

        CurrentMenuIndicator = GeneralMenuBackground.Find("CurrentMenuIndicator");

        PauseText = CurrentMenuIndicator.Find("PauseText");
        EnvanterText = CurrentMenuIndicator.Find("EnvanterText");
        UpgradesText = CurrentMenuIndicator.Find("UpgradesText");

        PauseMenu = GeneralMenuBackground.Find("PauseMenu");
        EnvanterMenu = GeneralMenuBackground.Find("EnvanterMenu");
        UpgradesMenu = GeneralMenuBackground.Find("UpgradesMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                gamePaused = false;

                Time.timeScale = 1;
                PauseMenu.gameObject.SetActive(false);
                GeneralMenuBackground.gameObject.SetActive(false);
            }
            else
            {
                gamePaused = true;

                Time.timeScale = 0;
                PauseMenu.gameObject.SetActive(true);
                GeneralMenuBackground.gameObject.SetActive(true);
            }
        }

        if(gamePaused)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log(1);
                ChangeMenu(false);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(2);
                ChangeMenu(true);
            }
        }
    }

    public void resume()
    {
        Time.timeScale = 1;
        transform.GetChild(0).gameObject.SetActive(false);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ChangeMenu(bool ToRight)
    {
        if(ToRight)
        {
            CurrentMenu++;
            if((int)CurrentMenu > 2)
            {
                CurrentMenu = 0;
            }
        }
        else
        {
            CurrentMenu--;
            if ((int)CurrentMenu < 0)
            {
                CurrentMenu = (menus)2;
            }
        }

        if(CurrentMenu == menus.Pause)
        {
            PositionIndicatorTexts(-1, EnvanterText);
            PositionIndicatorTexts(0, PauseText);
            PositionIndicatorTexts(1, UpgradesText);

            PauseMenu.gameObject.SetActive(true);
            UpgradesMenu.gameObject.SetActive(false);
            EnvanterMenu.gameObject.SetActive(false);
        }
        else if(CurrentMenu == menus.Upgrade)
        {
            PositionIndicatorTexts(-1, PauseText);
            PositionIndicatorTexts(0, UpgradesText);
            PositionIndicatorTexts(1, EnvanterText);

            PauseMenu.gameObject.SetActive(false);
            UpgradesMenu.gameObject.SetActive(true);
            EnvanterMenu.gameObject.SetActive(false);
        }
        else if(CurrentMenu == menus.Envanter)
        {
            PositionIndicatorTexts(-1, UpgradesText);
            PositionIndicatorTexts(0, EnvanterText);
            PositionIndicatorTexts(1, PauseText);

            PauseMenu.gameObject.SetActive(false);
            UpgradesMenu.gameObject.SetActive(false);
            EnvanterMenu.gameObject.SetActive(true);
        }
    }

    void PositionIndicatorTexts(int pos, Transform obj)
    {
        switch (pos)
        {
            case 0:
                obj.localPosition = Vector3.zero;
                obj.localScale = Vector3.one;
                obj.GetComponent<TextMeshProUGUI>().color = Color.white;
                break;
            case 1:
                obj.localPosition = new Vector3(420, 0, 0);
                obj.localScale = new Vector3(0.75f, 0.75f, 1);
                obj.GetComponent<TextMeshProUGUI>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                break;
            case -1:
                obj.localPosition = new Vector3(-420, 0, 0);
                obj.localScale = new Vector3(0.75f, 0.75f, 1);
                obj.GetComponent<TextMeshProUGUI>().color = new Color(0.5f, 0.5f, 0.5f, 1);
                break;
        }
    }
}
