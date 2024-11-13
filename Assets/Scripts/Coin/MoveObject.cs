using System;
using DG.Tweening;
using UnityEngine;


public class MoveObject : MonoBehaviour
{
    public UIPositionSO uiPositionSo;

    
    private void Start()
    {
        MoveTargetUI();
    }


    private void MoveTargetUI()
    {
        transform.DOMove(uiPositionSo.positon, 1f).SetDelay(1f);
    }
}