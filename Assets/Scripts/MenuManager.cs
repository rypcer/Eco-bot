using System.Collections;
using UnityEngine;

/// <summary>
/// Code by Ajmal
/// </summary>
public class MenuManager : MonoBehaviour
{

    int currentWindow;
    int lastWindow;
    public GameObject[] windows;
    private Animator anim;
    private Animator anim2;
    void Start()
    {
        lastWindow = 0;
    }


    public void changecurrentw(int ne) {
        StartCoroutine(DisplayWindow(ne));
    }



    public IEnumerator DisplayWindow(int index) {
        currentWindow = index;
        anim = windows[currentWindow].gameObject.GetComponent<Animator>();
        anim2 = windows[lastWindow].gameObject.GetComponent<Animator>();

        if (lastWindow > 0)
            anim2.SetTrigger("SlideOut");

        windows[currentWindow].SetActive(true);
        anim.Update(0); // Skips Entry State Delay
        anim.SetTrigger("SlideIn");
        lastWindow = currentWindow;
        yield return null;
    }
}
