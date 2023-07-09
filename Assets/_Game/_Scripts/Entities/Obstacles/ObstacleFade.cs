using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFade : MonoBehaviour
{
    [SerializeField] private float fadeSpeed;

    // Components
    private SpriteRenderer _spr;

    [HideInInspector] public bool CanFade = false;

    private void Start()
    {
        _spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (CanFade)
            ApplyFade();
    }

    private void ApplyFade()
    {
        var a = _spr.color.a;
        a -= fadeSpeed * Time.deltaTime;

        _spr.color = new Color(_spr.color.r, _spr.color.g, _spr.color.b, a);

        if (_spr.color.a <= 0f)
            Destroy(gameObject);
    }
}
