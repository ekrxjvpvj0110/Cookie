using UnityEngine;


public class DonutHandle : MonoBehaviour
{
    private Animator _animator;
    
    [Header("Donut Information")]
    public DonutSo donutInfo;
    private int _currentDonutHp;
    private bool _isDonutDestroyed;
    
    [Header("Reword")]
    public GameObject coinPrefab;
    
    
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }


    private void Start()
    {
        _currentDonutHp = donutInfo.donutHp; 
    }


    public void OnClickedDonut()
    {
        if (_isDonutDestroyed) return;
        
        StartAnimation("Click", true);
        _currentDonutHp--;
        
        if (_currentDonutHp <= 0)
        {
            StartAnimation("Destroy", true);
            _isDonutDestroyed = true;
        }
        else
        {
            CheckBonusCoinCycle();
        }
    }


    private void CheckBonusCoinCycle()
    {
        if (_currentDonutHp % donutInfo.autoClickedCycle == 0)
        {
            GiveReward(donutInfo.bonusCoinQuantity);
        }
    }


    private void GiveReward(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
            // 오브젝트 풀링으로 개선
        }
    }


    #region Animation
    
    private void StartAnimation(string animName, bool state)
    {
        _animator.SetBool(animName,state);
    }
    
    
    public void OnDestroyDonut() // animation event
    {
        GiveReward(donutInfo.rewardCoinQuantity);
        NotifyDestroyed();
        Destroy(this.gameObject);
    }
    

    private void NotifyDestroyed()
    {
        // 일정 시간 지난 후 새로운 도넛 생성
        // 카운트 올려주기
    }
    #endregion
}