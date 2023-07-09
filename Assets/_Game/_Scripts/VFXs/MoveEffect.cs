using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : MonoBehaviour
{
    [Header("Configurações:")]
    [SerializeField] private Color effectColor;
    [SerializeField] private GameObject moveEffectPrefab;

    private void Start()
    {
        StartCoroutine(ApplyEffect(0.01f));
    }

    private IEnumerator ApplyEffect(float t)
    {
        yield return new WaitForSeconds(t);
        var effect = Instantiate(moveEffectPrefab, transform.position, Quaternion.identity);
        var effectSpr = effect.GetComponent<SpriteRenderer>();
        effect.transform.localScale = transform.localScale;
        effectSpr.sprite = GetComponent<SpriteRenderer>().sprite;
        effectSpr.flipX = GetComponent<SpriteRenderer>().flipX;
        effectSpr.color = effectColor;
        StartCoroutine(ApplyEffect(0.04f));
    }
}
