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
        public string contactName { get; set; }
        public string contactPhone { get; set; }
        public string contactEmail { get; set; }
        public string contactPosition { get; set; }
    }

    public class YearlyRevenue
    {
        public int year { get; set; }
        public int grossRevenue { get; set; }
        public int profit { get; set; }
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
        public List<Contact> contacts { get; set; }
        public List<YearlyRevenue> yearlyRevenue { get; set; }
    }

    [JsonArrayAttribute]
    public class Companies
    {        
        public Company[] companies { get; set; }
    }
}