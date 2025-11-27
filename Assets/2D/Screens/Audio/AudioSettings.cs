using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public struct AudioSettingsData
{
    public int sfxVolume;
    public int musicVolume;
    public int masterVolume;
}

public class AudioSettings : MonoBehaviour
{
    [SerializeField] public Slider sfxSlider;
    [SerializeField] public Slider musicSlider;
    [SerializeField] public Slider masterSlider;

    [SerializeField] public AudioMixer audioMixer;

    [SerializeField] private PauseMenuController pauseMenuController;
    [SerializeField] private bool Game = false;

    const string settingsFilePath = "audio_settings.json";

    void Awake()
    {
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChange);
        musicSlider.onValueChanged.AddListener(OnMusicVolumeChange);
        masterSlider.onValueChanged.AddListener(OnMasterVolumeChange);
    }

    void Start()
    {
        LoadSettings();

        if (Game)
        {
            pauseMenuController.TogglePause();
        }
    }

    void LoadSettings()
    {
        if (File.Exists(settingsFilePath))
        {
            var fileContent = File.ReadAllText(settingsFilePath);
            AudioSettingsData data = JsonUtility.FromJson<AudioSettingsData>(fileContent);

            sfxSlider.value = data.sfxVolume;
            musicSlider.value = data.musicVolume;
            masterSlider.value = data.masterVolume;

            SetGroupVolume("SFXVolume", data.sfxVolume);
            SetGroupVolume("BGVolume", data.musicVolume);
            SetGroupVolume("MasterVolume", data.masterVolume);
        }
    }

    void SaveSettings()
    {
        AudioSettingsData data = new AudioSettingsData
        {
            sfxVolume = (int)sfxSlider.value,
            musicVolume = (int)musicSlider.value,
            masterVolume = (int)masterSlider.value
        };

        string jsonString = JsonUtility.ToJson(data);
        File.WriteAllText(settingsFilePath, jsonString);
    }

    void SetGroupVolume(string groupName, float volumeInPercentage)
    {
        float dbLevel = DecibelFromNormalizedVolume(volumeInPercentage / 100.0f);
        audioMixer.SetFloat(groupName, dbLevel);
    }

    float DecibelFromNormalizedVolume(float normalizedVolume)
    {
        return Mathf.Log10(Mathf.Max(normalizedVolume, 0.0001f)) * 20.0f;
    }

    void OnSFXVolumeChange(float value)
    {
        SetGroupVolume("SFXVolume", value);
        SaveSettings();
    }

    void OnMusicVolumeChange(float value)
    {
        SetGroupVolume("BGVolume", value);
        SaveSettings();
    }

    void OnMasterVolumeChange(float value)
    {
        SetGroupVolume("MasterVolume", value);
        SaveSettings();
    }
}