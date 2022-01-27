using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBgM : MonoBehaviour
{
    Animator animator;//自身のアニメーターコンポーネントを格納

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void WindowBgChange(int x)//アニメーション切り替え：GManagerより呼び出し
    {
        switch (x)
        {
            case 0:
                animator.SetInteger("windowCh", 0);//消える
                break;
            case 1:
                animator.SetInteger("windowCh", 1);//カラス
                break;
            case 2:
                animator.SetInteger("windowCh", 2);//たくさんの猫
                break;
            case 3:
                animator.SetInteger("windowCh", 3);//遠くのでかい猫
                break;
            case 4:
                animator.SetInteger("windowCh", 4);//しっぽ
                break;
            case 5:
                animator.SetInteger("windowCh", 5);//ゆらす猫
                break;
            default:
                break;
        }
    }

}
