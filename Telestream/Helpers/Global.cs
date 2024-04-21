using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace Telestream.Helpers
{
    public class Global
    {
        public static List<List<List<string>>> GetAllData() {
            List<List<List<string>>> allData = new List<List<List<string>>>();
            string uploadDirectoryPath = Path.Combine(Path.GetFullPath("./wwwroot"), "uploads");
            StreamReader reader = null;

            if(Directory.Exists(uploadDirectoryPath))
            {
            string [] fileEntries = Directory.GetFiles(uploadDirectoryPath);
            foreach(string fileName in fileEntries) {
                if (File.Exists(fileName)){
                    reader = new StreamReader(File.OpenRead(fileName));
                    List<List<string>> subData = new List<List<string>>();
                    while (!reader.EndOfStream){
                        List<string> contactDetail = new List<string>();
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        foreach (var item in values){
                        contactDetail.Add(item);
                        }
                        subData.Add(contactDetail);
                    }
                    allData.Add(subData);
                }
            }
            }
            return allData;
        }

        public static int GetKeyIdx(List<string> data, string key) {
            int keyIdx = -1;
            int nFoundCnt = 0;
            string searchKey = key.Replace(" ", "").ToUpper();
            int idx = -1;

            foreach (string columnName in data)
            {
                idx++;
                string detailKey = columnName.Replace(" ", "").ToUpper();
                bool isValid = false;
                if (detailKey.IndexOf("ADDRESS") > -1) {
                    nFoundCnt++;
                }

                switch (searchKey)
                {
                    case "LASTNAME":
                        if (nFoundCnt == 1)
                        {
                            isValid = (detailKey.IndexOf("ADDRESS") > -1);
                        }
                        break;
                    case "ADDRESS":
                        if (nFoundCnt > 1)
                        {
                            isValid = (detailKey.IndexOf("ADDRESS") > -1);
                        }
                        break;
                    default:
                        isValid = (detailKey.IndexOf(searchKey) > -1);
                        break;
                }

                if (isValid)
                {
                    keyIdx = idx;
                }
            };

            return keyIdx;
        }

        public static string GetValue(List<List<string>> data, string key, int idx) {

            if (data.Count < 2 || idx > data.Count - 1 || idx < 0) {
            return "";
            }

            int keyIdx = GetKeyIdx(data[0], key);
            if (keyIdx < 0 || keyIdx > data[idx].Count-1) {
            return "";
            }

            return data[idx][keyIdx];
        }

        public static string GetContactName(string phoneNumber) {
            phoneNumber = GetValidPhoneNumber(phoneNumber);
            string contactName = "";
            try
            {
                List<List<List<string>>> allData = GetAllData();
                foreach (List<List<string>> subData in allData)
                {
                    int idx = -1;
                    foreach (List<string> contactDetail in subData)
                    {
                        idx++;
                        if (idx < 1)
                        {
                            continue;
                        }
                        string currentPhone = GetValue(subData, "phone#", idx);
                        currentPhone = GetValidPhoneNumber(currentPhone);
                        if (phoneNumber.Equals(currentPhone))
                        {
                            string firstName = GetValue(subData, "first name", idx);
                            string secondName = GetValue(subData, "last name", idx);
                            return firstName + " " + secondName;
                        }
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return contactName;
        }

        public static string GetValidPhoneNumber(string phoneNumber) {
            string validPhoneNumber = "";
            Regex extractNumberrRegex = new Regex("\\d+");
            string [] extracted = extractNumberrRegex.Matches(phoneNumber)
            .Cast<Match>()
            .Select(m => m.Value) 
            .ToArray(); 
            validPhoneNumber = string.Join("", extracted);
            if (validPhoneNumber.Length < 11) {
            validPhoneNumber = "1" + validPhoneNumber;
            }
            validPhoneNumber = "+" + validPhoneNumber;
            return validPhoneNumber;
        }

    }
}
