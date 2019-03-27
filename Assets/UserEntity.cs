using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
    public class UserEntity
    {
        public int _id;
        public string _firstName;
        public string _lastName;

        public UserEntity(int id, string firstName, string lastName)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
        }

        public static UserEntity getTemporaryUser()
        {
            return new UserEntity(0,"First Name", "Last Name");
        }
    }
}
