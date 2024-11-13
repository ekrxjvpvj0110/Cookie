using UnityEngine;


[CreateAssetMenu(fileName = "DonutSO_", menuName = "DonutSO/DonutSO", order = 0)]
public class DonutSo : ScriptableObject
{
    [Header("Donut state")]
    public int donutHp;
    public float autoClickedCycle;

    [Header("Donut Destroy reward")]
    public int rewardCoinQuantity;
    
    [Header("Donut bonus reward")]
    public int bonusCoinQuantity;
}