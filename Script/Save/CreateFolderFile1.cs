using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class CreateFolderFile1 : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		Debug.Log(Application.dataPath);
		Debug.Log(Application.persistentDataPath);

		string folderPath1 = Path.Combine(Application.dataPath, @"Scripts\File\SubFolder1");
		string folderPath2 = Path.Combine(Application.dataPath, @"Scripts\File\SubFolder2");
		string folderPath3 = Path.Combine(folderPath2, @"SubSubFolder");

		string filePath1 = Path.Combine(folderPath1, "data1.txt");
		string filePath2 = Path.Combine(folderPath2, "data2.txt");
		string filePath3 = Path.Combine(folderPath3, "data3.txt");

		FileStream fs1 = null;
		StreamWriter fs2 = null;
		FileStream fs3 = null;

		try
		{
			Directory.CreateDirectory(folderPath1);
			Directory.CreateDirectory(folderPath2);
			Directory.CreateDirectory(folderPath3);

			fs1 = File.Create(filePath1);
			fs2 = File.CreateText(filePath2);
			fs3 = File.Create(filePath3);
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
			if (fs2 != null)
			{
				try
				{
					fs2.Dispose();
				}
				catch (Exception e2)
				{
					Debug.Log(e2.Message);
				}
			}
			if (fs3 != null)
			{
				try
				{
					fs3.Dispose();
				}
				catch (Exception e2)
				{
					Debug.Log(e2.Message);
				}
			}
		}
	}
}
