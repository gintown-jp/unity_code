using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;


public class test : MonoBehaviour
{

	[SerializeField] Text textObj;//☆


	string folderPath1;//対象ディレクトリを格納
	string filePath1;//対象ファイルを格納
	FileStream fs1 = null;
	string lodeText;//対象ファイル読み込み時の一時変数


	//「100000」初期値
	//「111111」全ての広告が解放済み
	//「110000」要素番号0はTipasHako0,AdBtnNo0の広告を解放済み


	void Start()
	{
		//フォルダとファイルのパス（途中まで）を取得する関数
		Debug.Log(Application.dataPath);
		Debug.Log(Application.persistentDataPath);

		//取得したパスにオリジナルのパスを結合
		//folderPath1 = Path.Combine(Application.dataPath, @"Script\Save\SubFolder1");(andoroidはApplication.dataPathだと結果が得られない、windows ios は大丈夫):https://techblog.kayac.com/unity_advent_calendar_2018_14
		folderPath1 = Path.Combine(Application.persistentDataPath, @"Script\Save\SubFolder1");
		filePath1 = Path.Combine(folderPath1, "data1.txt");

		Debug.Log(folderPath1);
		Debug.Log(filePath1);

		FileCheckCreate();//ディレクトとファイルがあるか確認しなければ作成

		FileStream fs = new FileStream(//インスタンス化？:https://programming.pc-note.net/csharp/filestream.html
				filePath1, FileMode.OpenOrCreate, FileAccess.ReadWrite);

		fs1 = fs;

		fs1.Dispose();//リソース解放

		FileLode();//リソース開放前に書くとエラーがでる。「Sharing violation on path」読み込もうとしたファイルが他のアプリで使用されている場合に発生するらしい

	}

	private void ReleaseMemory()
    {
		fs1.Dispose();//リソース解放
	}


	public bool FileCheck()//ディレクトとファイルがあるか確認
	{
		if (!Directory.Exists(folderPath1))
		{
			//Debug.Log(folderPath1 + "は存在しません。");
			return false;
		}
		else
		{
			Debug.Log("該当ディレクトあり");
		}
		if (!File.Exists(filePath1))
		{
			//Debug.Log(filePath1 + "は存在しません。");
			return false;
		}
		else
		{
			Debug.Log("該当ファイルあり");
		}
		return true;
	}

	public void FileCheckCreate()//ディレクトとファイルがあるか確認しなければ作成
	{
		if (!Directory.Exists(folderPath1))
		{
			//Debug.Log(folderPath1 + "は存在しません。");
			Directory.CreateDirectory(folderPath1);
		}
		else
		{
			//Debug.Log("該当ディレクトあり");
		}
		if (!File.Exists(filePath1))
		{
			//Debug.Log(filePath1 + "は存在しません。");
			File.WriteAllText(filePath1, "100000");
		}
		else
		{
			//Debug.Log("該当ファイルあり");
		}
		//fs1.Dispose();
	}


	public void FileCreate()//ディレクトリとファイルの作成、リソース解放：使わない
	{
		try
		{
			Directory.CreateDirectory(folderPath1);
			fs1 = File.Create(filePath1);
		}
		catch (Exception e)
		{
			Debug.Log(e.Message);
		}
		finally
		{
			if (fs1 != null)
			{
				try
				{
					fs1.Dispose();
				}
				catch (Exception e2)
				{
					Debug.Log(e2.Message);
				}

			}
		}
	}

	public void FileSave()//txtファイルを上書き
    {
		File.WriteAllText(filePath1, lodeText);
		fs1.Dispose();
	}

	public void FileReset()//ファイルリセット
	{
		File.WriteAllText(filePath1, "100000");
		fs1.Dispose();
	}


	public void File1Btn()//対象ファイルをチェックし存在すれば上書き:使っていない
    {
        if (FileCheck())
        {
			FileSave();//☆
		}
	}
	public void FileWrite(string data)//ファイル上書き:TipsMから呼び出し
    {
		lodeText = data;
		File.WriteAllText(filePath1, lodeText);
		fs1.Dispose();
	}

	public void FileLode()//ファイルの読み込み:TipsMから呼び出し
	{
		lodeText = File.ReadAllText(filePath1);
		//textObj.GetComponent<Text>().text = lodeText;//表示☆
	}

	public string FileLodeTo()//ファイルの読み込みしstring型で返す
	{
		lodeText = File.ReadAllText(filePath1);
		return lodeText;
	}


	//計算
	public void Calc0()//配列では0
	{
		int data = int.Parse(lodeText);
		data = data + 1;
		lodeText = data.ToString("000000");
		textObj.GetComponent<Text>().text = lodeText;//表示☆
	}

	public void Calc1()//配列では1
	{
		int data = int.Parse(lodeText);
		data = data + 10;
		lodeText = data.ToString("000000");
		textObj.GetComponent<Text>().text = lodeText;//表示☆
	}

	public void Calc2()//配列では2
    {
		int data = int.Parse(lodeText);
		data = data + 100;
		lodeText = data.ToString("000000");
		textObj.GetComponent<Text>().text = lodeText;//表示☆
	}
	public void Calc3()//配列では3
	{
		int data = int.Parse(lodeText);
		data = data + 1000;
		lodeText = data.ToString("000000");
		textObj.GetComponent<Text>().text = lodeText;//表示☆
	}

	public void Calc4()//配列では4
	{
		int data = int.Parse(lodeText);
		data = data + 10000;
		lodeText = data.ToString("000000");
		textObj.GetComponent<Text>().text = lodeText;//表示☆
	}

}
//https://gametukurikata.com/csharp/makefolderfile