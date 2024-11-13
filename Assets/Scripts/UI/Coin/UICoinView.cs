using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UICoinView : MonoBehaviour
{
    private UICoinPresenter _presenter;
    
    public TextMeshProUGUI coinQuantityText; 
    public Image coinImage;


    private void Awake()
    {
        _presenter = GetComponent<UICoinPresenter>();
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            _presenter.AddCoin();

            if (other.gameObject.TryGetComponent<ReleaseObjectCoin>(out ReleaseObjectCoin releaseObject))
            {
                releaseObject.ReturnObject();
            }
        }
    }
}