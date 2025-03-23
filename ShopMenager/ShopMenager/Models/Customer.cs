using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMenager.Models
{
    public class Customer
    {
        [JsonProperty(Required = Required.Always)]
        public int CustomerId { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string FirstName { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string LastName { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Email { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Phone { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Address { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string City { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string PhotoPath { get; set; }
    }
}
