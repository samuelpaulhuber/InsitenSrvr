using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsitenServer.Models
{
    public enum Status
    {
        Researching = 1,
        PendingApproval = 2,
        Approved = 3,
        Declined = 4
    }

    public class Contact
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class YearlyRevenue
    {
        public string year { get; set; }
        public string profit { get; set; }
    }

    public class Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string address1 { get; set; }
        public object address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string description { get; set; }
        public List<string> contacts { get; set; }
        public List<YearlyRevenue> yearlyRevenue { get; set; }
    }

    [JsonArrayAttribute]
    public class Companies
    {        
        public Company[] companies { get; set; }
    }
}