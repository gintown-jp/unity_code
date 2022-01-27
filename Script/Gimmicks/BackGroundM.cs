using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackGroundM : MonoBehaviour
{

    private Sprite DeffultImg;//最初に表示されている画像
    //変化する画像を設定
    [SerializeField] Sprite yogore1;
    [SerializeField] Sprite yogore2;
    [SerializeField] Sprite yogore3;
    [SerializeField] Sprite kibako;



    void Start()
    {
        DeffultImg = this.GetComponent<Image>().sprite;
    }

    public void KabeImgChange(int x)//画像の切り替え関数:GManagerから呼び出し
    {
        switch (x)
        {
            case 0:
                this.GetComponent<Image>().sprite = DeffultImg;
                break;
            case 1:
                this.GetComponent<Image>().sprite = yogore1;
                break;
            case 2:
                this.GetComponent<Image>().sprite = yogore2;
                break;
            case 3:
                this.GetComponent<Image>().sprite = yogore3;
                break;
            case 4:
                this.GetComponent<Image>().sprite = kibako;
                break;
            default:
                this.GetComponent<Image>().sprite = DeffultImg;
                break;

        }
    }



}
