using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SettingsManager : MonoBehaviour
{
    [Header("Volume")]
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;

    [Header("Screen")]
    public TMP_Dropdown screenDropdown;
    public TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;

    void Start()
    {
        // ===== LOAD MASTER VOLUME =====
        float masterVolume =
            PlayerPrefs.GetFloat("MasterVolume", 1f);

        masterVolumeSlider.value = masterVolume;

        AudioListener.volume = masterVolume;

        // ===== LOAD MUSIC VOLUME =====
        float musicVolume =
            PlayerPrefs.GetFloat("MusicVolume", 1f);

        musicVolumeSlider.value = musicVolume;
        GameObject musicObj = GameObject.Find("MusicManager");

        if (musicObj != null)
        {
            AudioSource music = musicObj.GetComponent<AudioSource>();
            music.volume = musicVolume;
        }

        // ===== SCREEN MODE =====
        screenDropdown.ClearOptions();

        screenDropdown.AddOptions(
            new System.Collections.Generic.List<string>()
            {
                "Fullscreen",
                "Windowed"
            }
        );

        int screenMode =
            PlayerPrefs.GetInt("ScreenMode", 0);

        screenDropdown.value = screenMode;

        ApplyScreenMode(screenMode);
        // ===== RESOLUTION =====
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option =
                resolutions[i].width + " x " +
                resolutions[i].height;

            options.Add(option);

            if (resolutions[i].width ==
                Screen.currentResolution.width &&
                resolutions[i].height ==
                Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);

        resolutionDropdown.value = currentResolutionIndex;

        resolutionDropdown.RefreshShownValue();

    }


    // =========================
    // MASTER VOLUME
    // =========================
    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;

        PlayerPrefs.SetFloat(
            "MasterVolume",
            volume
        );
        PlayerPrefs.Save();
    }

    // =========================
    // MUSIC VOLUME
    // =========================
    public void SetMusicVolume(float volume)
    {
        GameObject musicObj =
            GameObject.Find("MusicManager");

        if (musicObj != null)
        {
            AudioSource music =
                musicObj.GetComponent<AudioSource>();

            music.volume = volume;
        }

        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    // =========================
    // SCREEN MODE
    // =========================
    public void SetScreenMode(int mode)
    {
        ApplyScreenMode(mode);

        PlayerPrefs.SetInt(
            "ScreenMode",
            mode
        );
        PlayerPrefs.Save();
    }

    void ApplyScreenMode(int mode)
    {
        if (mode == 0)
        {
            // Fullscreen
            Screen.fullScreenMode =
                FullScreenMode.FullScreenWindow;
        }
        else
        {
            // Windowed
            Screen.fullScreenMode =
                FullScreenMode.Windowed;
        }
        PlayerPrefs.Save();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution =
            resolutions[resolutionIndex];

        Screen.SetResolution(
            resolution.width,
            resolution.height,
            Screen.fullScreen
        );

        PlayerPrefs.SetInt(
            "Resolution",
            resolutionIndex
        );

        PlayerPrefs.Save();
    }
}