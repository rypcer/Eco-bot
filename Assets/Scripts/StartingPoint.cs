using System.Collections;
using UnityEngine;


public class StartingPoint : MonoBehaviour
{
    #region DECLARATIONS
    private ParticleSystem p;
    private Color32 c_green;
    private Color32 c_lightBlue;
    private Gradient grad;
    public static StartingPoint instance;
    bool stopCoroutine;
    #endregion

    void Start()
    {
        grad = new Gradient();
        c_green = new Color32(0xB3, 0xFF, 0x10, 0xFF);
        c_lightBlue = new Color32(0x10, 0xA4, 0xFF, 0xFF);
         p = gameObject.GetComponent<ParticleSystem>();
        instance = this;
        stopCoroutine = false;
    }

    public void FinalParticleEffect()
    {
        ParticleSystem.ColorOverLifetimeModule col = p.colorOverLifetime;
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(c_green, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 0.0f) });
        col.color = grad;

        ParticleSystem.MainModule main = p.main;
        main.startSize = 0.06f;
        AudioManager.instance.Play("nextlevel");
        stopCoroutine = true;
        StartCoroutine(ScaleStartPoint(2, 0.02f));
    }

    public void InitialParticleEffect()
    {
        ParticleSystem.ColorOverLifetimeModule col = p.colorOverLifetime;
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(c_lightBlue, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 0.0f) });
        col.color = grad;

        ParticleSystem.MainModule main = p.main;
        main.startSize = 0.03f;
        stopCoroutine = true;
        StartCoroutine(ScaleStartPoint(1, 0.02f));
    }

    private IEnumerator ScaleStartPoint(float endScale_Y, float smoothFactor)
    {
        yield return null;
        stopCoroutine = false;
        while (Mathf.Abs(transform.localScale.y - endScale_Y)>0.001f && !stopCoroutine)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, endScale_Y, 1), smoothFactor);
            yield return null;
        }
        transform.localScale = new Vector3(transform.localScale.x, endScale_Y, transform.localScale.z);
        yield return null;
    }
}
