using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSE_M : MonoBehaviour//SEの管理
{
    AudioSource audioSource;

    //SE:0ピアノ。1猫の怒った鳴声。2焼く。3カラス。4ピースはまる音。5猫1。6猫2。7猫3。8ピンポン。9ピース4つ集めた時の猫。10ドアノブ。11ドア窓。
    public AudioClip[] clips = new AudioClip[11];

    //一定時間ごとのイベント処理変数
    public bool crowSEOn = false;//GManaerから呼び出し
    private float timeOutCrow = 10.0f;
    private float timeElapsed;
    public bool catsSEOn = false;//GManaerから呼び出し
    private float timeOutCats = 7.0f;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (crowSEOn)
        {
            CrowSE();
            return;
        }
        if (catsSEOn)
        {
            CatsSE();
            return;
        }
    }

    public void SE01Play()//クリック時に音(矢印のクリック時に変更)
    {
        audioSource.PlayOneShot(clips[0]);
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    SE01Play();
        //}
    }

    

    public void CatAngerSE()//怒った猫の鳴声
    {
        audioSource.PlayOneShot(clips[1]);
    }

    public void BakeSE()//焼く音
    {
        audioSource.PlayOneShot(clips[2]);
    }

    private void CrowSE()//カラスの鳴声
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > timeOutCrow)
        {
            audioSource.PlayOneShot(clips[3]);
            timeElapsed = -10f;
        }
    }

    private void CatsSE()//猫複数の鳴声
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > timeOutCats)
        {
            int r = Random.Range(1, 5);
            switch (r)
            {
                case 1:
                    audioSource.PlayOneShot(clips[5]);
                    timeElapsed = -3f;
                    break;
                case 2:
                    audioSource.PlayOneShot(clips[6]);
                    timeElapsed = -4f;
                    break;
                case 3:
                    timeElapsed = 6f;
                    break;
                case 4:
                    audioSource.PlayOneShot(clips[7]);
                    timeElapsed = -5f;
                    break;
                default:
                    timeElapsed = 3f;
                    break;

            }
        }

    }


    public void KachiSE()//ピースがはまる音
    {
        audioSource.PlayOneShot(clips[4]);
    }

    public void StartBtnClick()//スタートボタンを押した時の音
    {
        audioSource.PlayOneShot(clips[5]);
    }

    public void peice4Cat()//ピースを4つ集めた時の音
    {
        audioSource.PlayOneShot(clips[9]);
    }

    public void PinPonSE()//ピンポン
    {
        audioSource.PlayOneShot(clips[8]);
    }

    public void DoorKnobSE()//ドアノブ
    {
        audioSource.PlayOneShot(clips[10]);
    }

    public void DoorMirrorSE()//ドアノブ
    {
        audioSource.PlayOneShot(clips[11]);
    }
}
