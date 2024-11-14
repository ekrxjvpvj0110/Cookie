using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UICoinPresenter : MonoBehaviour
{   
    private UICoinView _coinView;
    private UICoinModel _coinModel;

    private void Awake()
    {
        _coinView = GetComponent<UICoinView>();
        _coinModel = GetComponent<UICoinModel>();
    }

    public void AddCoin()
    {
        _coinModel.coinQuantity++;
        
        AudioManager.Instance.DOPlaySfx(Audios.CoinPickUp);

        UIRefresh();
    }


    private void UIRefresh()
    {
        _coinView.coinQuantityText.text = _coinModel.coinQuantity.ToString();

        _coinView.coinImage.rectTransform.DOScale(new Vector3(1.4f, 1.4f, 1), 0.1f).SetEase(Ease.OutBounce).OnComplete(
            () =>
            {
                _coinView.coinImage.rectTransform.DOScale(Vector3.one, 0.1f).SetEase(Ease.OutBounce);
            });
    }
}
