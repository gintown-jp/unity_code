using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;



public class TitleLogoM : MonoBehaviour
{

	[SerializeField] Sprite clearLogo;//クリア後のロゴ画像
	//クリア後のタイトル画面変化
	string folderPathC;//対象ディレクトリを格納
	string filePathC;//対象ファイルを格納
	//FileStream fsC = null;

	// Start is called before the first frame update
	void Start()
    {
		/*--取得したパスにオリジナルのパスを結合--*/
		//folderPath1 = Path.Combine(Application.dataPath, @"Script\Save\SubFolder1");(andoroidはApplication.dataPathだと結果が得られない、windows ios は大丈夫):https://techblog.kayac.com/unity_advent_calendar_2018_14
		folderPathC = Path.Combine(Application.persistentDataPath, @"Script\Save\SubFolderC");
		filePathC = Path.Combine(folderPathC, "dataC.txt");


        if (FileCheck())
        {
			//タイトルロゴの変更処理
			Debug.Log(folderPathC + "クリアしています。");
			this.gameObject.GetComponent<Image>().sprite = clearLogo;
		}

		//FileStream fs = new FileStream(//インスタンス化？:https://programming.pc-note.net/csharp/filestream.html
		//	filePathC, FileMode.OpenOrCreate, FileAccess.ReadWrite);

		//fsC = fs;
		//fsC.Dispose();//リソース解放

	}

	private bool FileCheck()//ディレクトとファイルがあるか確認
	{
		if (!Directory.Exists(folderPathC))
		{
			//Debug.Log(folderPathC + "は存在しません。");
			return false;
		}
		else
		{
			//Debug.Log("該当ディレクトあり");
		}
		if (!File.Exists(filePathC))
		{
			//Debug.Log(filePath1 + "は存在しません。");
			return false;
		}
		else
		{
			//Debug.Log("該当ファイルあり");
		}
		return true;
	}

}
