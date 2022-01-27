using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemBoxPM : MonoBehaviour
{
    //enum定義(intはアイテムのIDと揃える)
    public enum Items
    {
        Tekagami = 0,
        Syasin = 1,
        Kuroneko = 2,
        Piece01 = 3,
        Piece02 = 4,
        Piece03 = 5,
        Piece04 = 6,
        Kagi = 7,
        Tai = 8,
        Souseigi = 9,
        kara = 10,//空の状態（初期値）

    };
    //enum宣言（各アイテムボックスの中身と揃える。あくまで参照用）
    Items itemPocket1 = Items.kara;//一番目のアイテム欄
    Items itemPocket2 = Items.kara;//二番目のアイテム欄
    Items itemPocket3 = Items.kara;//三番目のアイテム欄
    Items itemPocket4 = Items.kara;//四番目のアイテム欄


    //子オブジェクトの各アイテムボックス
    GameObject ItemBox1;
    GameObject ItemBox2;
    GameObject ItemBox3;
    GameObject ItemBox4;

    //切り替え用背景
    private Sprite DefaultImg;//デフォルトの画像レベル1画像
    [SerializeField] Sprite bgImg2;//レベル2画像
    [SerializeField] Sprite bgImg3;//レベル3画像


    // Start is called before the first frame update
    void Start()
    {
        //子オブジェクトのアイテムボックスを取得
        ItemBox1 = transform.Find("ItemBox1").gameObject;//transformコンポーネントを経由して親子関係のゲームオブジェクトを取得
        ItemBox2 = transform.Find("ItemBox2").gameObject;
        ItemBox3 = transform.Find("ItemBox3").gameObject;
        ItemBox4 = transform.Find("ItemBox4").gameObject;
        //デフォルトの画像をセット
        DefaultImg = this.GetComponent<Image>().sprite;
    }

  

    public bool ItemBoxFreeCheck()//空のアイテムボックスがあるかチェックする関数：ItemP.TouchRun()から呼び出し
    {
        if (itemPocket1 == Items.kara || itemPocket2 == Items.kara || itemPocket3 == Items.kara || itemPocket4 == Items.kara)
        {
            //Debug.Log("アイテムボックスに空がありました");
            return true;
        }
        else
        {
            //Debug.Log("アイテムボックスに空はありませんでした");
            ItemBox1.GetComponent<ItemBoxM>().ItemBoxFullAnime();//各アイテムボックスを拡大縮小するアニメーション
            ItemBox2.GetComponent<ItemBoxM>().ItemBoxFullAnime();
            ItemBox3.GetComponent<ItemBoxM>().ItemBoxFullAnime();
            ItemBox4.GetComponent<ItemBoxM>().ItemBoxFullAnime();
            return false;
        }
    }

    public void ItemBoxSelect(int itemId,GameObject obj)//空のアイテムボックスにアイテムの情報を与える：ItemPスクリプトのTouchRun()から呼び出される。
    {
        //Debug.Log("ItemBoxSelect()が実行されました");
        var enumValue = (Items)System.Enum.ToObject(typeof(Items), itemId);//intからenum型へ変換：https://www.fenet.jp/dotnet/column/language/2453/#intenum

        //空のアイテムボックスの一番上を選択
        if (itemPocket1 == Items.kara)
        {
            itemPocket1 = enumValue;//アイテムのIDを親アイテムボックスenum型にセットする
            ItemBox1.GetComponent<ItemBoxM>().SetItemBox(obj);//アイテムの情報を子アイテムボックスにセットする
        }
        else if(itemPocket2 == Items.kara)
        {
            itemPocket2 = enumValue;
            ItemBox2.GetComponent<ItemBoxM>().SetItemBox(obj);
        }
        else if(itemPocket3 == Items.kara)
        {
            itemPocket3 = enumValue;
            ItemBox3.GetComponent<ItemBoxM>().SetItemBox(obj);
        }
        else if(itemPocket4 == Items.kara)
        {
            itemPocket4 = enumValue;
            ItemBox4.GetComponent<ItemBoxM>().SetItemBox(obj);
        }

    }
    public void ItemBoxSelectHako(int itemId, Sprite thumImg, string itemName,string itemObjName)//空のアイテムボックスにアイテムの情報を与える：HakoInMスクリプトのTouchRun()から呼び出される。
    {
        //Debug.Log("ItemBoxSelect()が実行されました");
        var enumValue = (Items)System.Enum.ToObject(typeof(Items), itemId);//intからenum型へ変換：https://www.fenet.jp/dotnet/column/language/2453/#intenum

        //空のアイテムボックスの一番上を選択
        if (itemPocket1 == Items.kara)
        {
            itemPocket1 = enumValue;//アイテムのIDを親アイテムボックスenum型にセットする
            ItemBox1.GetComponent<ItemBoxM>().SetItemBoxHako(itemId, thumImg, itemName, itemObjName);//アイテムの情報を子アイテムボックスにセットする
        }
        else if (itemPocket2 == Items.kara)
        {
            itemPocket2 = enumValue;
            ItemBox2.GetComponent<ItemBoxM>().SetItemBoxHako(itemId, thumImg, itemName, itemObjName);
        }
        else if (itemPocket3 == Items.kara)
        {
            itemPocket3 = enumValue;
            ItemBox3.GetComponent<ItemBoxM>().SetItemBoxHako(itemId, thumImg, itemName, itemObjName);
        }
        else if (itemPocket4 == Items.kara)
        {
            itemPocket4 = enumValue;
            ItemBox4.GetComponent<ItemBoxM>().SetItemBoxHako(itemId, thumImg, itemName, itemObjName);
        }

    }

    public void KaraSet(GameObject obj)//空になったアイテムボックスに該当するenum型にKaraを設定：ItemBoxMから呼び出し
    {
        switch (obj.name)
        {
            case "ItemBox1":
                //該当のenum型に空の設定
                itemPocket1 = Items.kara;
                break;
            case "ItemBox2":
                itemPocket2 = Items.kara;
                break;
            case "ItemBox3":
                itemPocket3 = Items.kara;
                break;
            case "ItemBox4":
                itemPocket4 = Items.kara;
                break;
            default:
                break;
        }
    }

    public void ImgChange(int x)//背景のアイテムボックスを切り替え
    {
        if (x == 1)
        {
            this.GetComponent<Image>().sprite = DefaultImg;
        }
        if (x == 2)
        {
            this.GetComponent<Image>().sprite = bgImg2;
        }
        if (x == 3)
        {
            this.GetComponent<Image>().sprite = bgImg3;
        }
    }

}
