using UnityEngine;


public class ReleaseObjectDonut : MonoBehaviour
{
    private ObjectPool _objectPool;


    public void SetPool(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }

    
    public void ReturnObject()
    {
        _objectPool.ReleaseDonutObject(gameObject);
    }
}
