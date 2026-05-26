using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    [Header("Volume")]
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public AudioMixer audioMixer;

    [Header("Screen")]
    public TMP_Dropdown screenDropdown;   // 
    public TMP_Dropdown resolutionDropdown;

    // --- Lưu tạm cài đặt chưa save ---
    private float tempMasterVolume;
    private float tempMusicVolume;
    private int tempScreenMode;
    private int tempResolutionIndex;

    private Resolution[] resolutions;

    void Start()
    {
        // ===== LOAD MASTER VOLUME =====
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        masterVolumeSlider.value = masterVolume;
        tempMasterVolume = masterVolume;
        AudioListener.volume = masterVolume;

        // ===== LOAD MUSIC VOLUME =====
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicVolumeSlider.value = musicVolume;
        tempMusicVolume = musicVolume;
        ApplyMusicVolume(musicVolume);

        // ===== SCREEN MODE =====
        screenDropdown.ClearOptions();
        screenDropdown.AddOptions(new List<string> { "Fullscreen", "Windowed" });
        int screenMode = PlayerPrefs.GetInt("ScreenMode", 0);
        screenDropdown.value = screenMode;
        tempScreenMode = screenMode;
        ApplyScreenMode(screenMode);

        // ===== RESOLUTION =====
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Ưu tiên chỉ số đã lưu, nếu có
        int savedResolution = PlayerPrefs.GetInt("Resolution", currentResolutionIndex);
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = savedResolution;
        resolutionDropdown.RefreshShownValue();
        tempResolutionIndex = savedResolution;
    }

    // =========================
    // CÁC HÀM CHỈ LƯU TẠM
    // (gắn vào OnValueChanged của từng UI)
    // =========================
    public void OnMasterVolumeChanged(float volume)
    {
        tempMasterVolume = volume;
        AudioListener.volume = volume; // Preview ngay
    }

    public void OnMusicVolumeChanged(float volume)
    {
        tempMusicVolume = volume;
        ApplyMusicVolume(volume);  // preview ngay khi kéo slider
    }


    public void OnScreenModeChanged(int mode)
    {
        tempScreenMode = mode;
        ApplyScreenMode(mode); // Preview ngay
    }

    public void OnResolutionChanged(int index)
    {
        tempResolutionIndex = index;
        // Preview ngay nếu muốn:
        // Resolution r = resolutions[index];
        // Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }

    // =========================
    // NÚT SAVE — ghi tất cả vào PlayerPrefs
    // (gắn hàm này vào Button Save)
    // =========================
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", tempMasterVolume);
        PlayerPrefs.SetFloat("MusicVolume", tempMusicVolume);
        PlayerPrefs.SetInt("ScreenMode", tempScreenMode);
        PlayerPrefs.SetInt("Resolution", tempResolutionIndex);
        PlayerPrefs.Save();

        // Áp dụng resolution khi save
        Resolution r = resolutions[tempResolutionIndex];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);

        Debug.Log("✅ Đã lưu cài đặt!");
    }

    // =========================
    // HÀM PHỤ TRỢ
    // =========================
    void ApplyMusicVolume(float volume)
{
    // Tìm trực tiếp AudioSource trên MusicManager
    GameObject musicObj = GameObject.Find("MusicManager");
    
    if (musicObj != null)
    {
        AudioSource music = musicObj.GetComponent<AudioSource>();
        if (music != null)
        {
            music.volume = volume;
            Debug.Log("✅ Đã set volume = " + volume);
        }
        else
        {
            Debug.LogError("❌ Không tìm thấy AudioSource!");
        }
    }
    else
    {
        Debug.LogError("❌ Không tìm thấy MusicManager!");
    }
}

    void ApplyScreenMode(int mode)
    {
        Screen.fullScreenMode = (mode == 0)
            ? FullScreenMode.FullScreenWindow
            : FullScreenMode.Windowed;
    }
}