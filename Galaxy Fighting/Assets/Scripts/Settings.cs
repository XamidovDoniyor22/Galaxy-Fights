using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Settings : MonoBehaviour
{
    public Dropdown resolutionDropDawn;
    public Dropdown qualityDropDawn;

    Resolution[] resolutions;

    private void Start()
    {
        resolutionDropDawn.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDawn.AddOptions(options);
        resolutionDropDawn.RefreshShownValue();
        //LoadSettings(currentresolutionIndex);

    }
    public void SetFullScreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }
    public void SetResolution(int reslutionIndex)
    {
        Resolution resolution = resolutions[reslutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void ExitSettings()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySettingsPreference", qualityDropDawn.value);
        PlayerPrefs.SetInt("ResolutionPrefence", resolutionDropDawn.value);
        PlayerPrefs.SetInt("FullscreenPrefence", System.Convert.ToInt32(Screen.fullScreen));
            
    }
    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingsPreference"))
        {
            qualityDropDawn.value = PlayerPrefs.GetInt("QualitySettingsPreference");
        }
        else qualityDropDawn.value = 3;

        if (PlayerPrefs.HasKey("ResolutionPrefence"))
        {
            resolutionDropDawn.value = PlayerPrefs.GetInt("ResolutionPrefence");
        }
        else resolutionDropDawn.value = currentResolutionIndex;

        if (PlayerPrefs.HasKey("FullscreenPrefence"))
        {
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPrefence"));
        }
        else Screen.fullScreen = true;
    }

}
