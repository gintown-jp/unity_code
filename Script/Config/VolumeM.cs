using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeM : MonoBehaviour//BGMと音全体の管理
{
    AudioSource audioSource;
    [SerializeField] Slider SoundSlider;//BGMスライダー
    public static float volumeBGM;//シーン間共有:BGMのボリューム（初期値は0）
    public static bool startVolume = true;//最初のシーンか判定

    /*BGM：0箱猫エンド用不穏。*/
    public AudioClip[] bgms = new AudioClip[3];


    /*フェードイン・アウトの変数*/
    //private bool IsFade;
    private double FadeInSeconds = 1.5;
    public bool IsFadeIn = false;
    private double FadeDeltaTime = 0;
   
    private double FadeOutSeconds = 1.5;
    public bool IsFadeOut = false;//HakoFutaMから操作


    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        if (startVolume)
        {
            SoundSlider.GetComponent<Slider>().normalizedValue = this.audioSource.volume;//このオブジェクトのaudioSourceの値をスライダーの値に設定
            startVolume = false;
            return;
        }
        else
        {
            audioSource.volume = volumeBGM;
            SoundSlider.GetComponent<Slider>().normalizedValue = volumeBGM;//※おそらくこのコードのせいで一度スライダーのイベントトリガーが実行される(volumeBGMに値が代入される)
        }


    }

    void Update()
    {
        FadeInBGM();
        FadeOutBGM();
    }


    public void OnChangedSlider()//sliderオブジェクトのイベントから呼び出し:BGM音量調整
    {
        audioSource.volume = SoundSlider.GetComponent<Slider>().normalizedValue;//正規化されたスライダーの値
        volumeBGM = audioSource.volume;
    }

    private void FadeInBGM()//BGMのフェードイン
    {
        if (IsFadeIn)
        {
            FadeDeltaTime += Time.deltaTime;
            if (FadeDeltaTime >= FadeInSeconds)
            {
                FadeDeltaTime = FadeInSeconds;
                IsFadeIn = false;
            }
            audioSource.volume = (float)(FadeDeltaTime / FadeInSeconds);//float型に変換
            
        }
    }

    private void FadeOutBGM()//BGMのフェードアウト
    {
        if (IsFadeOut)
        {
            FadeDeltaTime += Time.deltaTime;
            Debug.Log(FadeDeltaTime);
            if (FadeDeltaTime >= FadeOutSeconds)
            {
                FadeDeltaTime = FadeOutSeconds;
                IsFadeOut = false;
            }
            audioSource.volume = (float)(volumeBGM - FadeDeltaTime / FadeOutSeconds);
        }
    }


    public void SetBGM(int x)//BGMをセットする：
    {
        audioSource.clip = bgms[x];
        audioSource.Play();
    }

    public void SetBGMFadeIN(int x)//フェードインするBGMをセットする：
    {
        audioSource.volume = 0;
        IsFadeIn = true;
        audioSource.clip = bgms[x];
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }

}
