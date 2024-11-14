using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


public class MoveObject : MonoBehaviour
{
    public UIPositionSO uiPositionSo;
    
    private Tween _moveTween;

    
    private void OnEnable()
    {
        transform.position += new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
        MoveTargetUI();
    }


    private void MoveTargetUI()
    {
        _moveTween = transform.DOMove(uiPositionSo.positon, 1f).SetDelay(1f);
    }


    private void OnDisable()
    {
        _moveTween?.Kill();
        gameObject.transform.position = new Vector3(0,0,0);
    }
}