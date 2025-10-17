using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceSingleton : MonoBehaviour
{
    #region Singleton

    private static AudioSourceSingleton _instance;
    public static AudioSourceSingleton Instance;
    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region AudioLogic
    [SerializeField] private AudioSource _audioSource;
    public void SetVolume(float value)
    {
        _audioSource.volume = value;
    }
    #endregion
}
