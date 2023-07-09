using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour
{
    [Header("Configuraç?es:")]
    [SerializeField] private FadeType type;
    [SerializeField] private float fadeInSpeed;
    [SerializeField] private float fadeOutSpeed;
    [SerializeField] private bool enableOnStart;

    [HideInInspector] public bool isFading = false;

    public enum FadeType
    {
        FadeOut,
        FadeIn
    }

    // Components
    private RawImage _rawImage;

    private void Start()
    {
        _rawImage = GetComponent<RawImage>();

        if (enableOnStart)
            StartFade(type);
    }

    private void Update()
    {
        if (isFading)
        {
            ApplyFade();
            if (type == FadeType.FadeIn)
                AudioListener.volume += 0.01f * Time.deltaTime;
            else
                AudioListener.volume -= 0.01f * Time.deltaTime;
        }
    }

    public void StartFade(FadeType t)
    {
        type = t;
        isFading = true;
    }

    private void ApplyFade()
    {
        var color = _rawImage.color;
        var alpha = color.a;

        if (type == FadeType.FadeOut)
        {
            if (alpha > 0.0f)
            {
                alpha -= fadeOutSpeed * Time.deltaTime;
                color.a = alpha;
                _rawImage.color = color;
            }
            else
            {
                isFading = false;
                Destroy(gameObject);
            }
        }
        else
        {
            if (alpha < 1.0f)
            {
                alpha += fadeInSpeed * Time.deltaTime;
                color.a = alpha;
                _rawImage.color = color;
            }
            else
            {
                isFading = false;
            }
        }
    }
}
