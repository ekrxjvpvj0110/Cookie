using System;
using UnityEngine;


[System.Serializable]
public class Sound<T>
{
    public T name;
    public AudioClip clip;
}


public class AudioManager : ConvertSingleton<AudioManager>
{
    [SerializeField] private AudioSource[] _sfxPlayer = null;
    [SerializeField] private Sound<Audios>[] _AudiosSFX = null;


    private void Start()
    {
        for (int i = 0; i < _sfxPlayer.Length; i++)
        {
            _sfxPlayer[i].volume = 0.2f;
        }
    }

    public void DOPlaySfx(Audios audiosEnum)
    {
        for (int i = 0; i < _AudiosSFX.Length; i++)
        {
            if (audiosEnum.Equals(_AudiosSFX[i].name))
            {
                for (int j = 0; j < _sfxPlayer.Length; j++)
                {
                    if (!_sfxPlayer[j].isPlaying)
                    {
                        _sfxPlayer[j].clip = _AudiosSFX[i].clip;
                        _sfxPlayer[j].Play();
                        return;
                    }
                }
                Debug.Log("모든 플레이어가 작동 중");
                return;
            }
        }
        Debug.Log(audiosEnum + "이라는 sfx가 없음" );
        return;
    }
}