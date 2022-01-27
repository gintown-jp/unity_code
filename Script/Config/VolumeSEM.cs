using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeSEM : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] Slider SoundSlider;
    public static float volumeSE;//シーン間共有:SEのボリューム
    public static bool startVolumeSE = true;//最初のシーンか判定

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        if (startVolumeSE)
        {
            SoundSlider.GetComponent<Slider>().normalizedValue = this.audioSource.volume;//このオブジェクトのaudioSourceの値をスライダーの値に設定
            startVolumeSE = false;
            return;
        }
        else
        {
            audioSource.volume = volumeSE;
            SoundSlider.GetComponent<Slider>().normalizedValue = volumeSE;
        }

    }

    public void OnSEChangedSlider()//sliderオブジェクトのイベントから呼び出し:SE
    {
        audioSource.volume = SoundSlider.GetComponent<Slider>().normalizedValue;//正規化されたスライダーの値
        volumeSE = audioSource.volume;
    }
}
