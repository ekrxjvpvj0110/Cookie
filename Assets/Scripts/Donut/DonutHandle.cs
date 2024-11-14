using System.Collections;
using UnityEngine;


public class DonutHandle : MonoBehaviour
{
    private Animator _animator;
    private Coroutine _coroutine;
    private float _waitTime= 0.21f;
    
    [Header("Donut Information")]
    public DonutSo donutInfo;
    private int _currentDonutHp;
    private bool _isDonutDestroyed;
    
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }


    private void Start()
    {
        _currentDonutHp = donutInfo.donutHp; 
    }


    public void OnClickedDonut() // 도넛 클릭시 실행
    {
        if (_isDonutDestroyed) return;
        
        _currentDonutHp--;
        
        AudioManager.Instance.DOPlaySfx(Audios.CookieClick);
        StartAnimation("Click", true);
        
        if (_currentDonutHp <= 0)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            
            ObjectPool.Instance.GetDonutObject();
            StartAnimation("Destroy", true);
            _isDonutDestroyed = true;
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(ResetClick());
            CheckBonusCoinCycle();
        }
    }
    
    
    private IEnumerator ResetClick()
    {
        yield return new WaitForSeconds(_waitTime);
        StartAnimation("Click", false);
    }


    private void CheckBonusCoinCycle() // donutInfo.autoClickedCycle 회 클릭시 마다 보너스 코인 생성
    {
        if (_currentDonutHp % donutInfo.autoClickedCycle == 0)
        {
            GiveReward(donutInfo.bonusCoinQuantity);
        }
    }


    private void GiveReward(int quantity) // 코인 생성
    {
        for (int i = 0; i < quantity; i++)
        {
            ObjectPool.Instance.GetCoinObject();
        }
        
        AudioManager.Instance.DOPlaySfx(Audios.CoinDrop);
    }


    #region Animation
    
    private void StartAnimation(string animName, bool state)
    {
        _animator.SetBool(animName,state);
    }
    
    
    public void OnDestroyDonut() // animation event
    {
        AudioManager.Instance.DOPlaySfx(Audios.CookieDestroy);
        GiveReward(donutInfo.rewardCoinQuantity);
        NotifyDestroyed();
        Destroy(this.gameObject);
    }
    

    private void NotifyDestroyed() // 새로운 도넛 생성
    {
        GameManager.Instance.MakeDonut();
    }
    #endregion
}