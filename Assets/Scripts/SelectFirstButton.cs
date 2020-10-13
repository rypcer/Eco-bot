using UnityEngine;
using UnityEngine.EventSystems;

public class SelectFirstButton : MonoBehaviour
{
    //make the speified button "selected"
    public void SelectButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(button);
    }
}
