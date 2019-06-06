using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer audioMixer;
    public Slider masterVolume, ambientNoise, effectNoise,backNoise;

    [Header("Res")]
    public Dropdown dropDownRes;
    Resolution[] resolutions;

    void Start()
    {
        //int qualityLevel = QualitySettings.GetQualityLevel();
        //Debug.Log(qualityLevel);

        masterVolume.value = PlayerPrefs.GetFloat("MasterVolumeMix", 0);
        ambientNoise.value = PlayerPrefs.GetFloat("AmbientNoise", 4);
        effectNoise.value = PlayerPrefs.GetFloat("EffectNiose", 0);

        resolutions = Screen.resolutions;

        dropDownRes.ClearOptions();
        List<string> vs = new List<string>();
        int curIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string options = resolutions[i].width + " X " + resolutions[i].height;
            vs.Add(options);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curIndex = i;
            }
        }
        dropDownRes.AddOptions(vs);
        dropDownRes.value = curIndex;
        dropDownRes.RefreshShownValue();
    }

    public void SwitchRes(int witch)
    {
        Resolution resol = resolutions[witch];
        Screen.SetResolution(resol.width, resol.height, Screen.fullScreen);
    }

    public void FullScreenToggle(bool tog)
    {
        Screen.fullScreen = tog;
    }

    public void CoppleMasterVolume(float amount)
    {
        audioMixer.SetFloat("MasterVolumeMix", amount);
    }

    public void CoppleAmbientNoiseVolume(float amount)
    {
        audioMixer.SetFloat("AmbientNoise", amount);
    }
    public void CoppleEffectNoiseVolume(float amount)
    {
        audioMixer.SetFloat("EffectNiose", amount);
    }
    public void CoppleBackGroundNoiseVolume(float amount)
    {
        audioMixer.SetFloat("BackGroundNiose", amount);
    }

    public void SetGraphics(int dropDown)
    {
        //QualitySettings.SetQualityLevel(dropDown);
        QualitySettings.SetQualityLevel(dropDown, true);
        Debug.Log(dropDown);
    }

}
