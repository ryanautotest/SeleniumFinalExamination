﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFinalExamination.DAO
{
    public class EmployeeDAO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public string Age { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("salary")]
        public string Salary { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }
    }
}
