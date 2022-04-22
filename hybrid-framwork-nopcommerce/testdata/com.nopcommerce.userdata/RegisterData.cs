using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace hybrid_framwork_nopcommerce.testdata.com.nopcommerce.userdata
{
    public class RegisterData
    {
        public void LoadJson()
        {
            using StreamReader r = new StreamReader("RegisterData.json");
            string json = r.ReadToEnd();
            List<Register> items = JsonConvert.DeserializeObject<List<Register>>(json);
        }

        public class Register
        {
            public string firstname;
            public string lastname;
            public string company;
            public string password;
            public IList<string> Dob { get; set; }
        }
    }
}
