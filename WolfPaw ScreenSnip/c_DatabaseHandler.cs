using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Security.AccessControl;

namespace SharpSnip
{
	static class c_DatabaseHandler
	{
		#region MISC

		/// <summary>
		/// Builds connection string
		/// <para>https://www.connectionstrings.com/sqlite/</para>
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
		/// Attempts to disconnect the SQLite connection for a 
		/// <para>specified connection if it is not in closed state</para>
		/// </summary>
		private static bool DisconnectFromDB(SQLiteConnection conn, out string ErrorMessage)
        {
			ErrorMessage = "";

			try
			{
				if (conn.State != System.Data.ConnectionState.Closed)
				{
					conn.Close();
					return true;
                }
                else { ErrorMessage = "Can not close connection, as Connection is not open."; }
            }catch(Exception ex) { ErrorMessage = ex.Message; }

			return false;
        }

		/// <summary>
		/// Attempts to disconnect and delete the DB file for a specified connection.
		/// </summary>
		public static bool DeleteDB(SQLiteConnection conn, out string ErrorMessage)
        {
			ErrorMessage = "";
			string name = conn.FileName;

			try
            {
				if (DisconnectFromDB(conn, out ErrorMessage))
				{
					if (File.Exists(name))
					{
						File.Delete(name);
						return true;
					}
					else { ErrorMessage = $"File [{name}] does not exist, or could not be reached."; }
				}
            }catch(Exception ex) { ErrorMessage = ex.Message; }

			return false;
        }

		/// <summary>
		/// Returns table names from current Database
		/// </summary>
		public static String[] getTableNamesFromDB(SQLiteConnection sqlc)
		{
			string[] ret;

			if (sqlc.State != System.Data.ConnectionState.Open)
			{
				return null;
			}

			SQLiteCommand sqlComm = new SQLiteCommand
			{
				Connection = sqlc,
				CommandText = "SELECT name FROM sqlite_master WHERE type='table' and name NOT LIKE 'sqlite_sequence'"
			};

			string tablenames = "";

			try
			{
				SQLiteDataReader sr = sqlComm.ExecuteReader();
				while (sr.Read())
				{
					tablenames += sr.GetString(0) + "|";
				}
			}
			catch
			{
				return null;
			}
			tablenames = tablenames.Trim('|');
			ret = tablenames.Split('|');

			return ret;
		}

		#endregion

		#region Table creators

		/// <summary>
		/// <para>Columns: </para>
		/// <list type="bullet">
		/// <para>Creates main Images table. </para>
		///	<description>images </description>
		///		<para><term>id </term><description> INTEGER PRIMARY KEY AUTOINCREMENT, </description></para>
		///		<para><term>title </term><description> TEXT, </description></para>
		///		<para><term>desc </term><description> TEXT, </description></para>
		///		<para><term>image </term><description> TEXT, </description></para>
		///		<para><term>tags </term><description> TEXT, </description></para>
		///		<para><term>save_date </term><description> TEXT </description></para>
		/// </list>
		/// </summary>
		/// <param name="sqlc">SQL Connection</param>
		public static void generateTable(SQLiteConnection sqlc)
		{
			if (sqlc.State == System.Data.ConnectionState.Open)
			{
				SQLiteCommand sqlComm = new SQLiteCommand
				{
					Connection = sqlc,
					CommandText = "Create TABLE images (id INTEGER PRIMARY KEY AUTOINCREMENT, title TEXT, desc TEXT, image TEXT, tags TEXT, save_date TEXT)"
				};
				sqlComm.ExecuteNonQuery();
			}

		}

		/// <summary>
		/// Creates backups table. Backups is where the screen captures are stored for later use 
		/// in case someone wanted to edit the cutouts they took and wanted more detail than before
		/// Columns:
		///		id INTEGER PRIMARY KEY AUTOINCREMENT, 
		///		imgid TEXT, 
		///		image TEXT,
		///		points TEXT
		/// </summary>
		/// <param name="sqlc">SQLite3 Connection</param>
		public static SQLiteConnection generateEditTable(SQLiteConnection sqlc)
		{
			if (sqlc.State == System.Data.ConnectionState.Open)
			{
				SQLiteCommand sqlComm = new SQLiteCommand
				{
					Connection = sqlc,
					CommandText = "Create TABLE backups_for_editing (id INTEGER PRIMARY KEY AUTOINCREMENT, imgid TEXT, image TEXT, points TEXT)"
				};
				sqlComm.ExecuteNonQuery();
				return sqlc;
			}
			return null;
		}

		/// <summary>
		/// Creates additional Images table if someone wants more than one table to sort their images.
		/// Columns:
		///		id INTEGER PRIMARY KEY AUTOINCREMENT, 
		///		title TEXT, 
		///		desc TEXT, 
		///		image TEXT, 
		///		tags TEXT, 
		///		save_date TEXT
		/// </summary>
		/// <param name="sqlc">SQL Connection</param>
		public static void generateAdditionalTable(SQLiteConnection sqlc, string tableName)
		{
			if (sqlc.State == System.Data.ConnectionState.Open)
			{
				SQLiteCommand sqlComm = new SQLiteCommand
				{
					Connection = sqlc,
					CommandText = "Create TABLE " + tableName + " (id INTEGER PRIMARY KEY AUTOINCREMENT, title TEXT, desc TEXT, image TEXT, tags TEXT, save_date TEXT)"
				};
				sqlComm.ExecuteNonQuery();
			}

		}

		#endregion

		#region Insert/Update/Delete

		/// <summary>
		/// Inserts image data into backup table
		/// </summary>
		/// <param name="sqlc">SQLite3 Connection</param>
		/// <param name="image">Image data in X16</param>
		/// <param name="imgid">Random ID connecting this image to a cutout</param>
		/// <param name="points">Array of points of the image in the following form: x:y|x:y|x:y...</param>
		/// <returns>Bool value if the image was added to db successfully</returns>
		public static bool insertImageToBackups(SQLiteConnection sqlc, string image, string imgid, string points)
		{
			bool ret = true;

			if (sqlc.State != System.Data.ConnectionState.Open)
			{
				return false;
			}

			using (SQLiteCommand sqlComm = new SQLiteCommand
			{
				Connection = sqlc,
				CommandText = string.Format("INSERT INTO backups_for_editing (imgid,image,points) VALUES ('{0}','{1}','{2}')", imgid, image, points)
			})
			{
				try
				{
					sqlComm.ExecuteNonQuery();
				}
				catch
				{
					return false;
				}
			}
			return ret;
		}

		/// <summary>
		/// Updates the points data contained in backup images
		/// </summary>
		public static bool updateBackupsImage(SQLiteConnection sqlc, string image, string imgid, string points)
		{
			bool ret = true;

			if (sqlc.State != System.Data.ConnectionState.Open)
			{
				return false;
			}

			SQLiteCommand sqlComm = new SQLiteCommand
			{
				Connection = sqlc,
				CommandText = string.Format("UPDATE backups_for_editing set points='{0}' WHERE imgid='{1}'", points, imgid)
			};
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
		/// Deletes a value from the imageBackup table
		/// </summary>
		/// <param name="sqlc">SQLite3 Connection</param>
		/// <param name="imgid">Image ID of the image to delete</param>
		/// <returns>Bool value if the delete was successful</returns>
		public static bool deleteBackupsImage(SQLiteConnection sqlc, string imgid)
		{
			bool ret = true;

			if (sqlc.State != System.Data.ConnectionState.Open)
			{
				return false;
			}

			SQLiteCommand sqlComm = new SQLiteCommand
			{
				Connection = sqlc,
				CommandText = string.Format("DELETE FROM backups_for_editing WHERE imgid='{0}'", imgid)
			};
			try
			{
				sqlComm.ExecuteNonQuery();

				using (SQLiteCommand command = sqlc.CreateCommand())
				{
					command.CommandText = "vacuum;";
					command.ExecuteNonQuery();
				}
			}
			catch
			{
				return false;
			}

			return ret;
		}
		
		/// <summary>
		/// Insetrs image into database
		/// </summary>
		/// <param name="sqlc">SQLite3 Connection</param>
		/// <param name="title">Image title</param>
		/// <param name="desc">Image description</param>
		/// <param name="image">Image string in X16</param>
		/// <param name="tags">Tags for the image</param>
		/// <param name="date">Date when Image is saved</param>
		/// <returns>Bool value true if image was saved successfully</returns>
		public static bool insertImage(SQLiteConnection sqlc, string tableName, string title, string desc, string image, string tags, string date)
		{
			bool ret = true;

			if (sqlc.State != System.Data.ConnectionState.Open)
			{
				return false;
			}

			SQLiteCommand sqlComm = new SQLiteCommand
			{
				Connection = sqlc,
				CommandText = string.Format("INSERT INTO {5} (title,desc,image,tags,save_date) VALUES ('{0}','{1}','{2}','{3}','{4}')", title, desc, image, tags, date, tableName)
			};
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

		#endregion

		#region ImageSelectors

		/// <summary>
		/// Returns images that have a specific title
		/// </summary>
		/// <param name="sqlc">SQLite3 Connection</param>
		/// <param name="title">Title string to match</param>
		/// <param name="like">Bool value specifying if the match has to be perfect</param>
		/// <returns>Images that have the specified title</returns>
		public static List<c_Object> getImagesByTitle(SQLiteConnection sqlc, string title, bool like, string tableName)
        {
            List<c_Object> lco = new List<c_Object>();

            if (sqlc.State != System.Data.ConnectionState.Open)
            {
                return null;
            }

			SQLiteCommand sqlComm = new SQLiteCommand
			{
				Connection = sqlc
			};
			if (like)
            {
                sqlComm.CommandText = string.Format("SELECT * FROM " + tableName + " WHERE title like '%{0}%'", title);
            }
            else
            {
                sqlComm.CommandText = string.Format("SELECT * FROM " + tableName + " WHERE title='{0}'", title);
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
		/// Returns images saved in a specific date range
		/// </summary>
		/// <param name="sqlc">SQLite3 Connection</param>
		/// <param name="date">Date range split by pipe</param>
		/// <returns>Pictures that were taken in the selected range</returns>
		public static List<c_Object> getImagesByDate(SQLiteConnection sqlc, string date, string tableName)
        {
            List<c_Object> lco = new List<c_Object>();
            date = date.Replace("/", "");
            string[] dates = date.Split('|');


            if (sqlc.State != System.Data.ConnectionState.Open)
            {
                return null;
            }

			SQLiteCommand sqlComm = new SQLiteCommand
			{
				Connection = sqlc,

				CommandText = string.Format("SELECT * FROM " + tableName + " WHERE save_date between '{0}' and '{1}'", dates[0], dates[1])
			};

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
		/// Returns images that have a specific description text set to them
		/// </summary>
		/// <param name="sqlc">SQLite3 Connection</param>
		/// <param name="desc">Description text to search for</param>
		/// <param name="like">Bool value determining if the description has to be matched properly</param>
		/// <returns>Images that have specified description</returns>
        public static List<c_Object> getImagesByDescription(SQLiteConnection sqlc, string desc, bool like, string tableName)
		{
			List<c_Object> lco = new List<c_Object>();

			if (sqlc.State != System.Data.ConnectionState.Open)
			{
				return null;
			}

			SQLiteCommand sqlComm = new SQLiteCommand
			{
				Connection = sqlc
			};
			if (like)
			{
				sqlComm.CommandText = string.Format("SELECT * FROM " + tableName + " WHERE desc like '%{0}%'", desc);
			}
			else
			{
				sqlComm.CommandText = string.Format("SELECT * FROM " + tableName + " WHERE desc='{0}'", desc);
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
		/// Returns images that have specific tags
		/// </summary>
		/// <param name="sqlc">SQLite3 Connection</param>
		/// <param name="tags">The String[] containing the tags needed to return</param>
		/// <returns>Imaghes that have specified tags</returns>
		public static List<c_Object> getImagesByTags(SQLiteConnection sqlc, string[] tags, string tableName)
		{
			List<c_Object> lco = new List<c_Object>();
			List<int> ids = new List<int>();
			string idString = "";

			if (sqlc.State != System.Data.ConnectionState.Open)
			{
				return null;
			}

			SQLiteCommand sqlComm = new SQLiteCommand
			{
				Connection = sqlc,

				CommandText = "SELECT id, tags FROM " + tableName + ""
			};
			SQLiteDataReader r1 = sqlComm.ExecuteReader();
			while (r1.Read())
			{
				int id = r1.GetInt32(0);
				string tagStr = r1.GetString(1);

				foreach (string s in tags)
				{
					if (tagStr.ToLower().Split(';').Contains(s.ToLower())) { ids.Add(id); }
				}
			}

			r1.Close();

			if (ids.Count > 0)
			{
				foreach (int i in ids) { idString += i + ","; }
				idString = idString.Trim(',');

				sqlComm.CommandText = string.Format("SELECT * FROM " + tableName + " WHERE id IN ( {0} )", idString);

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

		/// <summary>
		/// Returns all the images saved to DB
		/// </summary>
		/// <param name="sqlc">SQLite3 Connection</param>
		/// <returns>All images from DB</returns>
		public static List<c_Object> getImagesAll(SQLiteConnection sqlc, string tableName)
		{
			List<c_Object> lco = new List<c_Object>();

			if (sqlc.State != System.Data.ConnectionState.Open)
			{
				return null;
			}

			SQLiteCommand sqlComm = new SQLiteCommand
			{
				Connection = sqlc,
				CommandText = "SELECT * FROM " + tableName + ""
			};

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

		#endregion

	}
}
