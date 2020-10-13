﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// code by Ajmal
/// </summary>
public class ImageFade : MonoBehaviour
{

    // the image you want to fade, assign in inspector
    public Image img;

    public void ImageFades(bool con)
    {
        // fades the image out when you click
        StartCoroutine(FadeImage(con));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}