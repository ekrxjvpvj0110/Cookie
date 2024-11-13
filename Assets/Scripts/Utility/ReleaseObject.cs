using UnityEngine;


public class ReleaseObject : MonoBehaviour
{
    private ObjectPool _objectPool;


    public void SetPool(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }

    
    public void ReturnObject()
    {
        _objectPool.ReleaseObject(gameObject);
    }
}