using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveMovement : MonoBehaviour
{
    [Header("Configurações:")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minMoveTime;
    [SerializeField] private float maxMoveTime;
    [SerializeField] private float horizontalDirTime;

    private bool _canMove = true;

    private float _horizontalDir = 1f;

    [HideInInspector] public FisherMovement FisherObj;

    private void Start() => Invoke("EndMovement", Random.Range(minMoveTime, maxMoveTime));

    private void FixedUpdate()
    {
        if (_canMove)
            transform.position += Vector3.down * moveSpeed * Time.fixedDeltaTime;
        else
            transform.position += new Vector3(_horizontalDir * moveSpeed * 0.05f * Time.fixedDeltaTime, 0, 0);
    } 

    private void EndMovement()
    {
        _canMove = false;
        StartCoroutine(ChangeHorizontalDir(horizontalDirTime));
    }

    private IEnumerator ChangeHorizontalDir(float t)
    {
        yield return new WaitForSeconds(t);
        _horizontalDir *= -1f;

        StartCoroutine(ChangeHorizontalDir(horizontalDirTime));
    }
}
