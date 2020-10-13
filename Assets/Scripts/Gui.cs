using UnityEngine;
using UnityEngine.EventSystems;

public class Gui : MonoBehaviour
{
    public static Gui instance;

    private ControlsManager inputActions;

    public GameObject levelClearedMenu;
    public GameObject pauseMenu;

    public GameObject resumeBtn;
    public GameObject nextLevelBtn;

    private void Awake()
    {
        instance = this;
        inputActions = new ControlsManager();
        inputActions.Controls.PauseMenu.started += context => TogglePauseMenu();
    }

    //show level cleared menu
    public void ActivateLevelClearedMenu()
    {
        EventSystem.current.SetSelectedGameObject(nextLevelBtn);
        levelClearedMenu.SetActive(true);
        pauseMenu.SetActive(false);
        PlayerControl.instance.TogglePlayerInput(true);
        CameraControl.instance.ToggleCameraRotation(true);
    }

    //show/hide pause menu
    public void TogglePauseMenu()
    {
        if (levelClearedMenu.activeInHierarchy)
            return;
        bool pauseGame = !pauseMenu.activeInHierarchy;
        EventSystem.current.SetSelectedGameObject(resumeBtn);
        pauseMenu.SetActive(pauseGame);
        CameraControl.instance.ToggleCameraRotation(pauseGame);
        PlayerControl.instance.TogglePlayerInput(pauseGame);
    }

    private void OnEnable()
    {
        inputActions.Controls.Enable();
    }

    private void OnDisable()
    {
        inputActions.Controls.Disable();
    }

}
