using UnityEngine;
using System.Collections;
using System;

public class CSV {

	private string[][]Array;

	public void ReadCSV
		(string fileName)
	{
		//read csv binary file
		TextAsset binAsset = Resources.Load (fileName, typeof(TextAsset)) as TextAsset;

		//read every line 
		string[] lineArray = binAsset.text.Split ("\r" [0]);

		Array = new string[lineArray.Length][];

		//split csv data to array
		for (int i = 0; i < lineArray.Length; i++) {
			Array[i] = lineArray[i].Split(',');
		}
	}


	string GetStringData(int nRow, int nCol)
	{
		if (Array.Length <= 0 || nRow >= Array.Length)
						return "";

		if (nCol >= Array [0].Length)
						return "";

		return Array [nRow] [nCol];
	}

	int GetIntegerData(int nRow, int nCol)
	{
		if (Array.Length <= 0 || nRow >= Array.Length)
						return 0;
		
		if (nCol >= Array [0].Length)
					return 0;

		Int32 nConvertNumber = Convert.ToInt32(Array [nRow] [nCol]);
		return nConvertNumber;
	}

	float GetFloatData(int nRow, int nCol)
	{
		if (Array.Length <= 0 || nRow >= Array.Length)
						return 0.0f;
		
		if (nCol >= Array [0].Length)
						return 0.0f;

		float fConvertNumber = Convert.ToSingle (Array [nRow] [nCol]);
		return fConvertNumber;
	}
}
