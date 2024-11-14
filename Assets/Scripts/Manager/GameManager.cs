using System;
using System.Collections;
using UnityEngine;


public class GameManager : ConvertSingleton<GameManager>
{
    public GameObject donutPrefab;
    private readonly float _waitTime = 1.5f;
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        Instantiate(donutPrefab, Vector3.zero, Quaternion.identity);
    }


    public void MakeDonut()
    {
        StartCoroutine(MakeDonuts());
    }


    private IEnumerator MakeDonuts() 
    {
        yield return new WaitForSeconds(_waitTime);
        Instantiate(donutPrefab, Vector3.zero, Quaternion.identity);
    }
}