using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [Space]
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] TMP_Dropdown qualityDropdown;
    [Space]
    [SerializeField] Slider mainVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;
    [Space]
    [SerializeField] Toggle fullscreenToogle;
    [Space]
    [SerializeField] PlayerInput pI;

    Resolution[] resolutions;

    private void Awake()
    {
        // GESTION DES CONTROLES
        ManageBindings.Load(pI);
    }

    private void Start()
    {
        // GESTION DES RESOLUTIONS
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // GESTION DES PARAMETRES ENREGISTRES
        // AUDIO
        float mainVolume = PlayerPrefs.GetFloat("MainVolume", 0);
        SetMainVolume(mainVolume);
        mainVolumeSlider.value = mainVolume;
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0);
        SetMusicVolume(musicVolume);
        musicVolumeSlider.value = musicVolume;
        float SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0);
        SetSFXVolume(SFXVolume);
        SFXVolumeSlider.value = SFXVolume;
        // VIDEO
        int qualityIndex = PlayerPrefs.GetInt("QualityLevel", 2);
        SetQuality(qualityIndex);
        qualityDropdown.value = qualityIndex;
        bool isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        SetFullscreen(isFullscreen);
        fullscreenToogle.isOn = isFullscreen;
        currentResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", currentResolutionIndex);
        SetResolution(currentResolutionIndex);

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // AUDIO SETTINGS
    public void SetMainVolume(float volume)
    {
        audioMixer.SetFloat("MainVolume", volume);
        PlayerPrefs.SetFloat("MainVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    // VIDEO SETTINGS
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex + 3);
        PlayerPrefs.SetInt("QualityLevel", qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
    }
}
