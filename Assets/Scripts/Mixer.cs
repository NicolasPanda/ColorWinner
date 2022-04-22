using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

namespace YB
{

    public class Mixer : MonoBehaviour
    {
        public AudioMixer audioMixer;


        public void SetVolume(float masterVolume)
        {
            audioMixer.SetFloat("MasterVolume", masterVolume);
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }



        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }
    }
}
