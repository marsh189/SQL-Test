using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank
{
    public class UserDb : SqliteHelper
    {
        private const String Tag = "UserDb:\t";

        private const String TABLE_NAME = "Users";
        private const String KEY_ID = "id";
        private const String KEY_FIRST_NAME = "first_name";
        private const String KEY_LAST_NAME = "last_name";

        private String[] COLUMNS = new string[] {KEY_ID, KEY_FIRST_NAME, KEY_LAST_NAME};


        public UserDb() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_FIRST_NAME + " TEXT, " +
                KEY_LAST_NAME + " TEXT) ";
            dbcmd.ExecuteNonQuery();
        }

        public void addData(UserEntity user)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_FIRST_NAME + ", "
                + KEY_LAST_NAME + " ) "

                + "VALUES ( '"
                + user._id + "', '"
                + user._firstName + "', '"
                + user._lastName + "' )";
            dbcmd.ExecuteNonQuery();
        }


        public override IDataReader getDataById(int id)
        {
            Debug.Log(Tag + "Getting user: " + id);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + id + "'";
            return dbcmd.ExecuteReader();
        }

        public override IDataReader getDataByString(string str)
        {
            Debug.Log(Tag + "Getting user: " + str);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_FIRST_NAME + " = '" + str + "'";
            return dbcmd.ExecuteReader();
        }

        public override void deleteDataByString(string id)
        {
            Debug.Log(Tag + "Deleting User: " + id);

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + id + "'";
            dbcmd.ExecuteNonQuery();
        }

        public override void deleteDataById(int id)
        {
            base.deleteDataById(id);
        }

        public override void deleteAllData()
        {
            Debug.Log(Tag + "Deleting Table");

            base.deleteAllData(TABLE_NAME);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }
    }
}
