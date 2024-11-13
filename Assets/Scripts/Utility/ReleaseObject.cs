using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseObject : MonoBehaviour
{
    private ObjectPool _objectPool;
    private Coroutine _coroutine;
    private int _retrunTime = 1;


    public void SetPool(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }


    private void OnEnable()
    {
        _coroutine = StartCoroutine(ReturnObject());
    }


    private IEnumerator ReturnObject()
    {
        yield return new WaitForSeconds(_retrunTime);

        _objectPool.ReleaseObject(gameObject);
    }


    private void OnDisable()
    {
        if (_coroutine == null)
        {
            return;
        }

        StopCoroutine(_coroutine);
    }
}