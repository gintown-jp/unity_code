using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VerandaM : MonoBehaviour
{
    private Sprite DefaultImg;//デフォルトの透明画像
    [SerializeField] Sprite handImg;//猫の手画像
    [SerializeField] Sprite kagamiGirl;//鏡エンドの画像
    [SerializeField] Sprite SyashinGirl;//写真エンドの画像
    [SerializeField] Sprite ClearImg;

    // Start is called before the first frame update
    void Start()
    {
        DefaultImg = this.GetComponent<Image>().sprite;
    }

    public void ImgChange(bool x)//ベランダの画像切り替え：GManagerから呼び出し
    {
        if(x == true)
        {
            this.GetComponent<Image>().sprite = handImg;
        }
        else if(x == false)
        {
            this.GetComponent<Image>().sprite = DefaultImg;
        }
    }
    public void ImgEndChange(int x)//ベランダの画像切り替え:GManagerから呼び出し
    {
        if(x == 3)//鏡エンド
        {
            this.GetComponent<Image>().sprite = kagamiGirl;
        }
        else if (x == 4)//写真エンド
        {
            this.GetComponent<Image>().sprite = SyashinGirl;
        }
    }

    public void ClearWindowImg()
    {
        this.GetComponent<Image>().sprite = ClearImg;
    }

}
