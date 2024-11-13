using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIScoreView : MonoBehaviour
{
    private UIScorePresenter _presenter;
    
    public TextMeshProUGUI scoreQuantityText; 
    public Image scoreImage;


    private void Awake()
    {
        _presenter = GetComponent<UIScorePresenter>();
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Donut"))
        {
            _presenter.AddScore();

            if (other.gameObject.TryGetComponent<ReleaseObjectDonut>(out ReleaseObjectDonut releaseObject))
            {
                releaseObject.ReturnObject();
            }
        }
    }
}
