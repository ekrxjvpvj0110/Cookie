using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIScorePresenter : MonoBehaviour
{
    private UIScoreView _scoreView;
    private UIScoreModel _scoreModel;

    private void Awake()
    {
        _scoreView = GetComponent<UIScoreView>();
        _scoreModel = GetComponent<UIScoreModel>();
    }

    public void AddScore()
    {
        _scoreModel.scoreQuantity++;

        UIRefresh();
    }


    private void UIRefresh()
    {
        _scoreView.scoreQuantityText.text = _scoreModel.scoreQuantity.ToString();

        _scoreView.scoreImage.rectTransform.DOScale(new Vector3(1.4f, 1.4f, 1), 0.1f).SetEase(Ease.OutBounce).OnComplete(
            () =>
            {
                _scoreView.scoreImage.rectTransform.DOScale(Vector3.one, 0.1f).SetEase(Ease.OutBounce);
            });
    }
}
