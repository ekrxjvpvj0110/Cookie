using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ObjectPool : ConvertSingleton<ObjectPool>
{
    [SerializeField] private GameObject _coinPrefabs;
    private IObjectPool<GameObject> _coinPool;

    [SerializeField] private GameObject _donutPrefabs;
    private IObjectPool<GameObject> _donutPool;

    [SerializeField] private int _initialPoolSize = 10;
    [SerializeField] private int _maxSize = 20;

    protected override void Awake()
    {
        base.Awake();
        _coinPool = new ObjectPool<GameObject>(() => CreatePooledItem(_coinPrefabs), OnGetObject, OnReleaseObject, OnDestroyObject, true, _initialPoolSize, _maxSize);
        _donutPool = new ObjectPool<GameObject>(() => CreatePooledItem(_donutPrefabs), OnGetObject, OnReleaseObject, OnDestroyObject, true, _initialPoolSize, _maxSize);
    }

    #region Unity에서 처리
    
    private GameObject CreatePooledItem(GameObject prefab)
    {
        GameObject obj = Instantiate(prefab);

        if (obj.TryGetComponent<ReleaseObjectCoin>(out ReleaseObjectCoin releaseObjectCoin))
        {
            releaseObjectCoin.SetPool(this);
            return obj;
        }

        if (obj.TryGetComponent<ReleaseObjectDonut>(out ReleaseObjectDonut releaseObjectDonut))
        {
            releaseObjectDonut.SetPool(this);
            return obj;
        }

        return null;
    }

    private void OnGetObject(GameObject obj) // 풀에서 알아서 활성화
    {
        obj.SetActive(true);
    }

    private void OnReleaseObject(GameObject obj) // 풀에서 알아서 반환
    {
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(false);
    }

    private void OnDestroyObject(GameObject obj) // 풀에서 제거
    {
        Destroy(obj);
    }
    #endregion
    

    
    public GameObject GetCoinObject() // 코인을 풀에서 가져옴
    {
        return _coinPool.Get();
    }

    
    public GameObject GetDonutObject() // 도넛을 풀에서 가져옴
    {
        return _donutPool.Get();
    }

    
    public void ReleaseCoinObject(GameObject obj) // 코인을 반환
    {
        _coinPool.Release(obj);
    }

    public void ReleaseDonutObject(GameObject obj) // 도넛을 반환
    {
        _donutPool.Release(obj);
    }
}