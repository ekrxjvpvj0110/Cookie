using UnityEngine;


public class DonutHandle : MonoBehaviour
{
    private Animator _animator;
    
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
            ObjectPool.Instance.GetDonutObject();
            StartAnimation("Destroy", true);
            _isDonutDestroyed = true;
        }
        else
        {
            CheckBonusCoinCycle();
        }
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
    

    private void NotifyDestroyed() // 게임 매니저에 알려주어 새로운 도넛 생성
    {
        // 일정 시간 지난 후 새로운 도넛 생성
        // 카운트 올려주기
    }
    #endregion
}