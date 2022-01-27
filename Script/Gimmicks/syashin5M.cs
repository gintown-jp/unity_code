using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class syashin5M : MonoBehaviour
{
    public Sprite syashinImg1;
    public Sprite syashinImg2;
    public Sprite syashinImg3;
    public Sprite syashinImg4;
    public Sprite syashinImg5;
    private int imgNumber = 0;//写真切り替えカウント用（写真のカオス度として使用）
    private bool jugeImg = false;//写真切り替えを行うか判定
    [SerializeField] GameObject GameMObj;
    [SerializeField] GameObject SyashinButtonObj;
    [SerializeField] GameObject ImageObj;//Sya5Panelの女の子の写真
    [SerializeField] Sprite Cork2Img;
    [SerializeField] Sprite Cork3Img;
    [SerializeField] Sprite Img002;
    [SerializeField] Sprite Img003;
    [SerializeField] Sprite Img004;
    [SerializeField] Sprite Img005;



    public void ImgChange()//写真を切り替えていく。：イベントトリガーとCorkBoardMから呼び出し
    {
        if(jugeImg == false) { return; }//スワイプで写真がセットされてからでないとボタンは実行させない
        imgNumber ++;
        if(imgNumber > 6)
        {
            imgNumber = 7;
            return;
        }
        PhotoSwich();
        Invoke("ImgSwich",0.26f);
    }
    private void ImgSwich()//コルクボードの写真の切り替え
    {
        switch (imgNumber)
        {
            case 1:
                GetComponent<Image>().sprite = syashinImg1;
                SyashinButtonObj.GetComponent<Image>().sprite = Cork2Img;
                break;
            case 3://写真にロープが見える
                GetComponent<Image>().sprite = syashinImg2;
                ImageObj.GetComponent<Image>().sprite = Img002;
                break;
            case 4:
                GetComponent<Image>().sprite = syashinImg3;
                ImageObj.GetComponent<Image>().sprite = Img003;
                jugeImgOn();//全体カオス度に加算
                break;
            case 5:
                GetComponent<Image>().sprite = syashinImg4;
                ImageObj.GetComponent<Image>().sprite = Img004;
                break;
            case 6:
                GetComponent<Image>().sprite = syashinImg5;
                SyashinButtonObj.GetComponent<Image>().sprite = Cork3Img;
                ImageObj.GetComponent<Image>().sprite = Img005;
                //写真エンドフラグ
                SyashinEndFlag();

                break;
            default:
                break;
        }
    }
    public void jugeImgOn()
    {
        GetComponent<Image>().raycastTarget = true;
        GameMObj.GetComponent<GManager>().PlusChaos();//全体のカオス度に+1
        jugeImg = true;
    }
    private void PhotoSwich()//写真の切り替え
    {
        switch (imgNumber)
        {
            case 1:
                break;
            case 3:
                ImageObj.GetComponent<Image>().sprite = Img002;
                break;
            case 4:
                ImageObj.GetComponent<Image>().sprite = Img003;
                break;
            case 5:
                ImageObj.GetComponent<Image>().sprite = Img004;
                break;
            case 6:
                ImageObj.GetComponent<Image>().sprite = Img005;
                break;
            default:
                break;
        }
    }

    private void SyashinEndFlag()//鏡エンドのフラグ
    {
        GameMObj.GetComponent<GManager>().VerandaSE_NON();//猫とカラスのSEを消す

        //ギミック操作を止める☆鏡だけは見れるようにしたい・・・
        GameMObj.GetComponent<GManager>().tuchNo(false);//raycasttargetを非アクティブ化
        GameMObj.GetComponent<GManager>().EndVarSet(4);//写真エンドを設定
        SyashinButtonObj.GetComponent<Image>().raycastTarget = true;//写真ボタンだけタッチ可能

        //PanelParentMで矢印ボタンと向きを判定しベランダで女の子が血だらけになっている画像に


    }


}
