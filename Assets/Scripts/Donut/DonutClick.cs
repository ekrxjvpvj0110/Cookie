using UnityEngine;


public class DonutClick : MonoBehaviour
{
    private DonutHandle _donutHandle;
    

    private void Awake()
    {
        _donutHandle = GetComponent<DonutHandle>();
    }


    public void OnMouseDown()
    {
        OnClickDonut();
    }

    private void OnClickDonut()
    {
        _donutHandle.OnClickedDonut();
        AudioManager.Instance.DOPlaySfx(Audios.CookieClick);
    }
}