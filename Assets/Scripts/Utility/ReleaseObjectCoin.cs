using UnityEngine;


public class ReleaseObjectCoin : MonoBehaviour
{
    private ObjectPool _objectPool;


    public void SetPool(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }

    
    public void ReturnObject()
    {
        _objectPool.ReleaseCoinObject(gameObject);
    }
}