using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HakoM : GimmickP
{
    void Start()
    {
        GimmickInfoSet(0,"箱");//ギミックの基本情報をセット：親クラスから呼び出す
        //Debug.Log("ギミックの基本情報をセットしました。" + gimmickID + gimmickName);
    }

}
