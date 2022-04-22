using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.utilities
{
    public class DataHelper
    {
        public static DataHelper GetData()
        {
            return new DataHelper();
        }

        public string GetFirstName()
        {
            return Faker.Name.First();
        }

        public string GetLastName()
        {
            return Faker.Name.First();
        }

        public string GetEmail()
        {
            return Faker.Internet.Email();
        }

        public string GetAddress()
        {
            return Faker.Address.StreetAddress();
        }
    }
}
