using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

//从数据库中获取所有的数据工具类，必须表名和类名相同，类属性和表字段名都需要相同才可以。
//次类减少了每个属性的赋值
public class DBDataUtil {
		private static DBDataUtil instance = new DBDataUtil();

		private string persistentFilePath;

		public static DBDataUtil getInstance(){
				if (instance == null) {
						instance = new DBDataUtil ();
				}
				return instance ;
		}

		//设置数据库路径
		public void setPerSistentPath(string path){
				persistentFilePath = path;
		}

		/// <summary>
		/// 从数据库中获取全部数据
		/// </summary>
		/// <returns>The all data from D.</returns>
		/// <param name="data">Data.</param>
		/// <param name="tableName">如果表名存在，则以这个表名为准.，如果不在则是类名为表名</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public List<T> GetAllDataFromDB<T>(T data, string tableName=null) {
				List<T> resultList = new List<T>();
				if (data == null) {
						Debug.LogError("please create T instance!");
						return resultList;
				}
				try
				{
						SQLiteDB db = new SQLiteDB();
						db.Open(persistentFilePath);
						string tname = data.GetType().Name;
						if(tableName != null){
								tname = tableName;
						}
						SQLiteQuery qr = new SQLiteQuery(db, "SELECT * FROM "+tname+";");
						T result;
						while (qr.Step())
						{
								result = CreateInstance<T>(data);
								Type t =  data.GetType ();
								PropertyInfo[] info =  t.GetProperties();
								for (int i = 0; i < info.Length; i++) {
										PropertyInfo temp = info [i];
										string name = temp.Name;
										string type = temp.PropertyType.Name;
										if(!qr.HasField(name)){
												continue;
										}
										//Debug.Log(type + "=============" + data.GetType().Name);
										if(type == "Int32"){
												try{
													int intVal = qr.GetInteger(name);
													temp.SetValue(result,Convert.ChangeType(intVal,temp.PropertyType), null);
												}catch(Exception e){
														Debug.LogError(data.GetType().Name + ":" + e.ToString());
												}
										}
										else if(type == "String"){
												try{
													string strVal = qr.GetString(name);
													strVal = strVal == null ? "" : strVal;
													temp.SetValue(result,Convert.ChangeType(strVal, temp.PropertyType), null);
												}catch(Exception e){
														Debug.LogError(data.GetType().Name + ":" + e.ToString());
												}
										}
										else if(type == "Double"){
												try{
														double dVal = qr.GetDouble(name);
														temp.SetValue(result,Convert.ChangeType(dVal, temp.PropertyType), null);

												}catch(Exception e){
														Debug.LogError(data.GetType().Name + ":" + e.ToString());
												}
										}
								}
								resultList.Add(result);
						}
						qr.Release(); 
						db.Close();
				} catch (Exception e)
				{
						Debug.LogError(data.GetType().Name + ":" + e.ToString());
				}
				 
				return resultList;
		}

		//反射创建出实体
		public static T CreateInstance<T>(T data)
		{
				try
				{
						Type o = data.GetType();//加载类型
						object obj = Activator.CreateInstance(o, true);//根据类型创建实例
						return (T)obj;//类型转换并返回
				}
				catch
				{
						//发生异常，返回类型的默认值
						return default(T);
				}
		}
	
}
