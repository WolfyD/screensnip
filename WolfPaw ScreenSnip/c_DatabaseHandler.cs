using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace WolfPaw_ScreenSnip
{
	static class c_DatabaseHandler
	{
		/// <summary>
		/// Builds connection string
		/// https://www.connectionstrings.com/sqlite/
		/// </summary>
		public static SQLiteConnection ConnectToDB(String fileName, out string error)
		{
			String cs = "Data Source=" + fileName + ";Version=3;";
			if (File.Exists(fileName))
			{
				SQLiteConnection sqlc = new SQLiteConnection(cs);
				sqlc.Open();
				if (sqlc.State == System.Data.ConnectionState.Open)
				{
					error = "";
					return sqlc;
				}
				else
				{
					error = "Connection Error! Connection string: " + cs;
					return null;
				}
			}
			else
			{
				error = "DB file [ " + fileName + " ] does not exist!";
				return null;
			}
		}

		/// <summary>
		/// Creates main Images table.
		/// Columns:
		///		id INTEGER PRIMARY KEY AUTOINCREMENT, 
		///		title TEXT, 
		///		desc TEXT, 
		///		image TEXT, 
		///		tags TEXT, 
		///		save_date TEXT
		/// </summary>
		/// <param name="sqlc">SQL Connection</param>
		public static void generateTable(SQLiteConnection sqlc)
		{
			if (sqlc.State == System.Data.ConnectionState.Open)
			{
				SQLiteCommand sqlComm = new SQLiteCommand();
				sqlComm.Connection = sqlc;
				sqlComm.CommandText = "Create TABLE images (id INTEGER PRIMARY KEY AUTOINCREMENT, title TEXT, desc TEXT, image TEXT, tags TEXT, save_date TEXT)";
				sqlComm.ExecuteNonQuery();
			}

		}

		public static bool insertImage(SQLiteConnection sqlc, string title, string desc, string image, string tags, string date)
		{
			bool ret = true;

			if (sqlc.State != System.Data.ConnectionState.Open)
			{
				return false;
			}

			SQLiteCommand sqlComm = new SQLiteCommand();
			sqlComm.Connection = sqlc;
			sqlComm.CommandText = string.Format("INSERT INTO images (title,desc,image,tags,save_date) VALUES ('{0}','{1}','{2}','{3}','{4}')", title, desc, image, tags, date);
			try
			{
				sqlComm.ExecuteNonQuery();
			}
			catch
			{
				return false;
			}

			return ret;
		}

		/// <summary>
		/// //TODO:ADD SUMMARY
		/// </summary>
		/// <param name="sqlc"></param>
		/// <param name="title"></param>
		/// <param name="like"></param>
		/// <returns></returns>
		public static List<c_Object> getImagesByTitle(SQLiteConnection sqlc, string title, bool like)
		{
			List<c_Object> lco = new List<c_Object>();

			if (sqlc.State != System.Data.ConnectionState.Open)
			{
				return null;
			}

			SQLiteCommand sqlComm = new SQLiteCommand();
			sqlComm.Connection = sqlc;
			if (like)
			{
				sqlComm.CommandText = string.Format("SELECT * FROM images WHERE title like '%{0}%'", title);
			}
			else
			{
				sqlComm.CommandText = string.Format("SELECT * FROM images WHERE title='{0}'", title);
			}
			SQLiteDataReader r = sqlComm.ExecuteReader();
			while (r.Read())
			{
				string _title = r.GetString(1);
				string _desc = r.GetString(2);
				string _image = r.GetString(3);
				string _tags = r.GetString(4);
				string _savedate = r.GetString(5);

				c_Object obj = new c_Object(_title, _desc, _image, _tags, _savedate);
				lco.Add(obj);
			}

			//c_Object obj = new c_Object();
			return lco;
		}

		/// <summary>
		/// //TODO:ADD SUMMARY 2
		/// </summary>
		/// <param name="sqlc"></param>
		/// <param name="tags"></param>
		/// <returns></returns>
		public static List<c_Object> getImagesByTags(SQLiteConnection sqlc, string[] tags)
		{
			List<c_Object> lco = new List<c_Object>();
			List<int> ids = new List<int>();
			string idString = "";

			if (sqlc.State != System.Data.ConnectionState.Open)
			{
				return null;
			}

			SQLiteCommand sqlComm = new SQLiteCommand();
			sqlComm.Connection = sqlc;

			sqlComm.CommandText = "SELECT id, tags FROM images";
			SQLiteDataReader r1 = sqlComm.ExecuteReader();
			while (r1.Read())
			{
				int id = r1.GetInt32(0);
				string tagStr = r1.GetString(1);

				foreach (string s in tags)
				{
					if (tagStr.ToLower().Split(';').Contains(s.ToLower())) { ids.Add(id); }
					break;
				}
			}
			
			if (ids.Count > 0)
			{
				foreach(int i in ids) { idString += i + ","; }
				idString = idString.Trim(',');

				sqlComm.CommandText = string.Format("SELECT * FROM images WHERE id IN ( {0} )", idString);

				SQLiteDataReader r = sqlComm.ExecuteReader();
				while (r.Read())
				{
					string _title = r.GetString(1);
					string _desc = r.GetString(2);
					string _image = r.GetString(3);
					string _tags = r.GetString(4);
					string _savedate = r.GetString(5);

					c_Object obj = new c_Object(_title, _desc, _image, _tags, _savedate);
					lco.Add(obj);
				}
			}

			//c_Object obj = new c_Object();
			return lco;
		}


	}
}
