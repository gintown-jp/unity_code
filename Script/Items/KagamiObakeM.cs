using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KagamiObakeM : MonoBehaviour
{

    [SerializeField] Sprite obakeImg1;//お化け少し
    [SerializeField] Sprite obakeImg2;//お化け全身見える
    [SerializeField] Sprite obakeImg3;//お化け口を空ける
    [SerializeField] Sprite bloodImg;//血しぶき
    private Sprite DefaultImg;//デフォルトの透明画像



    // Start is called before the first frame update
    void Start()
    {
        DefaultImg = this.GetComponent<Image>().sprite;
    }

    public void obakeChange(int x)//画像切り替え:KagamiUraMから呼び出し
    {
        switch (x)
        {
            case 1:
                this.GetComponent<Image>().sprite = obakeImg1;
                break;
            case 2:
                this.GetComponent<Image>().sprite = obakeImg2;
                break;
            case 3:
                this.GetComponent<Image>().sprite = obakeImg3;
                break;
            case 4:
                this.GetComponent<Image>().sprite = bloodImg;
                break;
            case 5:
                this.GetComponent<Image>().sprite = DefaultImg;//透明画像に変更
                break;
            default:
                break;
        }
    }

    public void obakeView(bool x)//お化け画像の表示非表示切り替え
    {
        if (x == true)
        {
            this.GetComponent<Image>().enabled = true;
        }
        else
        {
            this.GetComponent<Image>().enabled = false;
        }
    }


}
