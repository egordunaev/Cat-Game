using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

    public Dropdown resolutionDropdown;

    public AudioMixer audioMixer;
    Resolution[] resolutions;
    /// <summary>
    /// При запуске считывает все возможные разрешения экрана и выводит их списком для настроек.
    /// </summary>
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();
        for (int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width==Screen.currentResolution.width && resolutions[i].height==Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    /// <summary>
    /// Метод, который устанавливает выбранное разрешение экрана.
    /// </summary>
    /// <param name="resolutionIndex">Индекс устанавливаемого разрешения экрана.</param>
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    /// <summary>
    /// Управление громкостью.
    /// </summary>
    /// <param name="volume">Громкость</param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        Debug.Log("Volume check: " + volume);
    }
    /// <summary>
    /// Метод полноэкранного режима.
    /// </summary>
    /// <param name="isFullscreen">Статус полноэкранного режима</param>
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
