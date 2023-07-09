using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFadeOut : MonoBehaviour
{
    [SerializeField] private float speed;
    
    // Components
    private SpriteRenderer _spr;

    private void Start()
    {
        _spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ApplyFade();
    }

    private void ApplyFade()
    {
        var color = _spr.color;

        var alpha = color.a;

        if (alpha > 0.0f)
        {
            alpha -= speed * Time.deltaTime;
            color.a = alpha;
            _spr.color = color;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
