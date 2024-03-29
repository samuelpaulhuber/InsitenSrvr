﻿using InsitenServer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InsitenServer
{
    /// <summary>
    /// Class used manage file manipulation
    /// </summary>
    public static class FileManager
    {
        private static string fullPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.json");

        /// <summary>
        /// Write data to file
        /// </summary>
        /// <param name="data">Company data</param>
        private static void UpdateFile(string data)
        {
            File.WriteAllText(fullPath, data);
        }

        /// <summary>
        /// Read file and parse data in objects
        /// </summary>
        /// <returns>Company[]</returns>
        public static List<Company> GetCompanies()
        {
            if (!File.Exists(fullPath))
                File.WriteAllText(fullPath, "[]");

            return JsonConvert.DeserializeObject<List<Company>>(File.ReadAllText(fullPath));
        }

        /// <summary>
        /// Calls GetCompanies and returns the company with the id specified
        /// </summary>
        /// <param name="id">Id to search for</param>
        /// <returns>Company</returns>
        public static Company GetCompany(int id)
        {
            var companies = GetCompanies().ToList();
            return companies.FirstOrDefault(x => x.id == id);
        }

        public static List<Company> RemoveCompany(int id)
        {
            var companies = GetCompanies().ToList();
            var companyToRemove = GetCompany(id);

            var index = companies.RemoveAll((x) => x.id == id);
            UpdateFile(Newtonsoft.Json.JsonConvert.SerializeObject(companies.ToArray()));

            return companies;
        }

        /// <summary>
        /// Updates a company's info or adds a new company
        /// </summary>
        /// <param name="company">Company</param>
        public static int AddUpdateCompany(Company company)
        {
            var companies = GetCompanies().ToList();
            var retCompany = companies.FindIndex(x => x.id == company.id);
            var id = 0;
            if (retCompany >= 0)
            {
                //update the company
                companies[retCompany] = company;
            }
            else
            {
                //add the company
                id = companies == null || companies.Count == 0 ? 1 : companies.Max(x => x.id) + 1;
                company.id = id;
                companies.Add(company);
            }

            UpdateFile(Newtonsoft.Json.JsonConvert.SerializeObject(companies.ToArray()));

            return id;
        }
    }
}
