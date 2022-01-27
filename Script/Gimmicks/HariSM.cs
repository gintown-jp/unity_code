using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HariSM : GimmickP
{
    private Vector3 hariSEuler;//HariLの角度（針の初期位置）

    // Start is called before the first frame update
    void Start()
    {
        GimmickInfoSet(28, "短針");//ギミックの基本情報をセット：親クラスから呼び出す
        hariSEuler = this.transform.localEulerAngles;//オイラー角を取得


    }

    public void HariSMoveL()
    {
        float angle = 0.1666f;
        this.transform.rotation *= Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public void HariSMoveR()
    {
        float angle = 0.1666f;
        this.transform.rotation *= Quaternion.AngleAxis(angle, Vector3.back);
    }
    public bool HariSJuge()//HariLM:HariLJuge()より呼び出し
    {
        Quaternion quaternion = this.transform.rotation;
        var rotz = quaternion.eulerAngles.z;
        Debug.Log("s" + rotz);
        if (rotz < 345 && rotz > 320)
        {
            return true;
        }
        return false;
    }

    public void HariSRe()//針を初期位置へ戻す
    {
        this.transform.rotation = Quaternion.Euler(hariSEuler);//オイラー角をクォータニオンへ変換し代入
    }

}
