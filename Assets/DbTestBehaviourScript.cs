using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using UnityEngine.UI;

public class DbTestBehaviourScript : MonoBehaviour
{

    public Text data;
    public InputField check;


    // Use this for initialization
    void Start()
    {
        UserDb mUserDb = new UserDb();

        //Add Data
        mUserDb.addData(new UserEntity(1, "matt", "marshall"));
        mUserDb.addData(new UserEntity(2, "john", "smith"));
        mUserDb.addData(new UserEntity(3, "jane", "doe"));
        mUserDb.addData(new UserEntity(4, "barry", "bonds"));
        mUserDb.close();


        //Fetch All Data
        UserDb mUserDb2 = new UserDb();
        System.Data.IDataReader reader = mUserDb2.getAllData();

        int fieldCount = reader.FieldCount;
        List<UserEntity> myList = new List<UserEntity>();
        while (reader.Read())
        {
            UserEntity entity = new UserEntity(int.Parse(reader[0].ToString()),
                                    reader[1].ToString(),
                                    reader[2].ToString());

            Debug.Log("id: " + entity._id);
            myList.Add(entity);
        }

    }

    public void getUser()
    {
        UserDb users = new UserDb();
        int number;
        data.text = string.Empty;
        if(int.TryParse(check.text, out number))
        {
            System.Data.IDataReader reader = users.getDataById(number);

            int fieldCount = reader.FieldCount;
            while (reader.Read())
            {
                UserEntity entity = new UserEntity(int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        reader[2].ToString());

                Debug.Log("name: " + entity._firstName);

                data.text += entity._id + " " + entity._firstName + " " + entity._lastName;
            }
        }
        else
        {
            System.Data.IDataReader reader = users.getDataByString(check.text);

            int fieldCount = reader.FieldCount;
            while (reader.Read())
            {
                UserEntity entity = new UserEntity(int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        reader[2].ToString());

                Debug.Log("name: " + entity._firstName);

                data.text += entity._id + " " + entity._firstName + " " + entity._lastName + "\n";
            }
        }
    }
}