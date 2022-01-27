using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//reycastAllでUI取得するために使用


/*--UIスワイプ処理採用--コード*/
/*--使い方：スワイプするオブジェクト(ギミックやアイテム)にアタッチする--*/

public class SwipeM3 : MonoBehaviour
{
    private Vector3 defaultPos; // 初期状態のオブジェクト位置
    private Vector3 mousePos; // 最初にタッチ(左クリック)した地点の情報を入れる
    private bool touchJudg = false;// タッチしているか判定


    [SerializeField] Camera mainCamera;


    private void Start()
    {
        defaultPos = this.transform.position; // 初期のオブジェクト位置を取得

    }


    void Update()
    {
        if (touchJudg == true)
        {
            Move();
        }
    }

    public void ItemBoxTouchJudg()//アイテムボックスをタッチしたか判定：インスペクター上のイベントトリガーに設定
    {
        if (this.gameObject.GetComponent<ItemBoxM>().setItemID == 10)
        {
            return;
        }
        touchJudg = true;
        this.transform.GetChild(1).gameObject.GetComponent<ReButtonM>().ReButtonClose();//子要素のRwButtonオブジェクトのImageコンポーネントをOffにする

    }

    private void Move()// スワイプに合わせてオブジェクトをドラックする処理
    {
        //Debug.Log("Move()を実行しました");


        //スワイプに合わせてオブジェクトをドラックする処理
        if (Input.GetMouseButtonDown(0)) // マウス左クリック(画面タッチ)が行われたら
        {
            this.transform.localScale = new Vector3(0.1f, 0.1f, 1);//ドラック中はサイズを縮小。数値はカメラとの距離を考慮


        }
        if (Input.GetMouseButton(0)) // クリックし続けている間実行
        {
            
            mousePos = Input.mousePosition;
            mousePos.z = Mathf.Abs(mainCamera.transform.position.z);// 下を含めた３行でマウス座標をワールド座標に変換（そのまま座標を指定すると「カメラの原点」を取ってしまうのでz値は修正) https://www.shibuya24.info/entry/dynamic_brush_mesh
            var pos = mainCamera.ScreenToWorldPoint(mousePos);
            this.transform.position = new Vector3(pos.x, pos.y, 0);//カメラの位置にz座標があるため調整

        }


        if (Input.GetMouseButtonUp(0))// タッチを終了した時の処理
        {
            MoveEnd();
            this.transform.localScale = new Vector3(1, 1, 1);//ドラックの終わりにサイズを戻す。数値はカメラとの距離を考慮
        }
    }

    private void MoveEnd()// スワイプ終了時の処理
    {
        this.transform.GetChild(1).gameObject.GetComponent<ReButtonM>().ReButtonOpen();//子要素のRwButtonオブジェクトのImageコンポーネントをOnにする

        //raycastAllを飛ばしてオブジェクトやUIが重なっているか調べる（通常のraycastではUIは取得できない）https://teratail.com/questions/106298
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;

        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, result);
        foreach (RaycastResult raycastResult in result)//取得したオブジェクトの数だけ繰り返し
        {
            GameObject obj = raycastResult.gameObject;

            // 取得したオブジェクトがギミックならギミックのスクリプトにあるイベントを実行する
            // 複数ある場合は全て取得されるため注意
            //Debug.Log(obj.name);

            if (obj.name == "ItemBoxParent")//スワイプ終了時の位置がアイテムボックス上であれば実行：何もせず元の位置に戻す
            {
                GoBackObj();
                touchJudg = false;

                return;
            }
            if (obj.tag == "Gimmick")
            {
                //ギミックが重なっている時は取得した情報からイベントの判定関数を呼び出す
                //イベントの実行（処理の終了）
                MoveEndEventFlag(obj);
                GoBackObj();
                touchJudg = false;
                return;
            }

        }
        GoBackObj();// スワイプ前の位置に戻す
        touchJudg = false;
    }

    private void GoBackObj()// スワイプ中のオブジェクトをスワイプ前の位置に戻す処理
    {
        if (Input.GetMouseButtonUp(0))
        {
            this.transform.position = defaultPos;
        }
    }

    private void MoveEndEventFlag(GameObject obj)//ItemBoxを離した位置でのイベント判定（イベント判定はスワイプ終了時のPanel内のobj(ギミック)が判定する）
    {
        //Debug.Log("MoveEndEventFlag()を実行しました" + obj);
        if (obj.name == "HakoIn" && obj.GetComponent<HakoInM>().itemId == 10)//箱が空の時に実行
        {
            obj.GetComponent<GimmickP>().SwipeOnEvent(this.gameObject, this.gameObject.GetComponent<ItemBoxM>().setItemID);//スワイプしてきた「ItemBoxオブジェクトと」ItemBoxオブジェクトにセットされている「アイテムID」を渡す
            this.gameObject.GetComponent<ItemBoxM>().ItemReturnHako();//アイテムボックスを空にする
            return;
        }
        if (obj.name == "corkBoard")//コルクボードに写真を落とした時に実行
        {
            var setItemID = this.gameObject.GetComponent<ItemBoxM>().setItemID;
            if(setItemID != 1) { return; }
            obj.GetComponent<GimmickP>().SwipeOnEvent(this.gameObject, setItemID);//スワイプしてきた「ItemBoxオブジェクトと」ItemBoxオブジェクトにセットされている「アイテムID」を渡す
            this.gameObject.GetComponent<ItemBoxM>().ItemReturnHako();//アイテムボックスを空にする
            return;
        }
        if (obj.name == "Art2")//絵画2に落とした時に実行
        {
            obj.GetComponent<GimmickP>().SwipeOnEvent(this.gameObject, this.gameObject.GetComponent<ItemBoxM>().setItemID);//スワイプしてきた「ItemBoxオブジェクトと」ItemBoxオブジェクトにセットされている「アイテムID」を渡す
            return;
        }
        if (obj.name == "Cat")//猫に落とした時に実行
        {
            obj.GetComponent<GimmickP>().SwipeOnEvent(this.gameObject, this.gameObject.GetComponent<ItemBoxM>().setItemID);//スワイプしてきた「ItemBoxオブジェクトと」ItemBoxオブジェクトにセットされている「アイテムID」を渡す
            var setItemID = this.gameObject.GetComponent<ItemBoxM>().setItemID;
            if (setItemID == 9)//たい焼きを落とした時は消費する
            {
                this.gameObject.GetComponent<ItemBoxM>().ItemReturnHako();//アイテムボックスを空にする
            }
            return;
        }
        if (obj.name == "Futa")//蓋に落とした時に実行
        {
            var setItemID = this.gameObject.GetComponent<ItemBoxM>().setItemID;
            obj.GetComponent<GimmickP>().SwipeOnEvent(this.gameObject, this.gameObject.GetComponent<ItemBoxM>().setItemID);//スワイプしてきた「ItemBoxオブジェクトと」ItemBoxオブジェクトにセットされている「アイテムID」を渡す
            if (setItemID >= 3 && setItemID <= 6)//ピースを渡したら空にする
            {
                this.gameObject.GetComponent<ItemBoxM>().ItemReturnHako();//アイテムボックスを空にする
            }
            return;
        }

    }


}
