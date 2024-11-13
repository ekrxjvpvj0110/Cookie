using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class ObjectPool : ConvertSingleton<ObjectPool>
{
    [SerializeField] private GameObject _prefabs;
    private IObjectPool<GameObject> _pool;
    
    [SerializeField] private int _initialPoolSize = 10;
    [SerializeField] private int _maxSize = 20;

    protected override void Awake()
    {
        base.Awake();
        _pool = new ObjectPool<GameObject>(CreatePooledItem, OnGetObject, OnReleaseObject, OnDestroyObject, true, _initialPoolSize, _maxSize);
    }


    private GameObject CreatePooledItem()
    {
        GameObject obj = Instantiate(_prefabs);
        
        obj.GetComponent<ReleaseObject>().SetPool(this);
        return obj;
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


    public GameObject GetObject() // 사용자가 오브젝트 활성화
    {
        return _pool.Get();
    }


    public void ReleaseObject(GameObject obj) // 사용자가 오브젝트 반환
    {
        _pool.Release(obj);
    }
}