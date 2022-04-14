using Entities;
using System.Xml;
using System.Xml.Serialization;
using System;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using Logic.Implementation;
using System.Collections.Generic;

namespace Logic.Implementation.Helpers {
    /// <summary>
    /// The service consumes an XML and this XML can be loaded from a file or a string
    /// </summary>
    public static class Deserializer {
        public static XmlDocument GetXMLFromFile() {
            string sourceFile = "C:/Users/enmanuelle/source/repos/WCF tests/Source/Service/Logic.Implemetation/LoanRequest.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(sourceFile);

            return xmlDoc;
        }

        public static XmlDocument GetXMLFromString(string data) {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(data);

            return xmlDoc;
        }

        public static LoanRequest DeserializeXMLToLoanRequest(XmlDocument xmlDoc) {
            try {
                XmlReader reader = new XmlNodeReader(xmlDoc);
                XmlSerializer serializer = new XmlSerializer(typeof(LoanRequestRaw));
                LoanRequestRaw rawModel = (LoanRequestRaw)serializer.Deserialize(reader);

                // Loop the data array to transfer into a dictionary
                Dictionary<string, string> data = new Dictionary<string, string>();
                foreach (var item in rawModel.data) {
                    data.Add(item.name, item.value);
                }

                // Create an instance of loanRequest
                LoanRequest model = new LoanRequest {
                    sub_id = Convert.ToInt32(data["sub_id"]),
                    bank_account_type = data["bank_account_type"],
                    bank_name = data["bank_name"],
                    client_url_root = data["client_url_root"],
                    customer_id = Convert.ToInt32(data["customer_id"]),
                    employer_length_months = Convert.ToInt32(data["employer_length_months"]),
                    employer_name = data["employer_name"],
                    ext_work = data["ext_work"],
                    home_city = data["home_city"],
                    home_state = data["home_state"],
                    home_street = data["home_street"],
                    home_zip = Convert.ToInt32(data["home_zip"]),
                    income_date1_d = Convert.ToInt32(data["income_date1_d"]),
                    income_date1_m = Convert.ToInt32(data["income_date1_m"]),
                    income_date1_y = Convert.ToInt32(data["income_date1_y"]),
                    income_date2_d = Convert.ToInt32(data["income_date2_d"]),
                    income_date2_m = Convert.ToInt32(data["income_date2_y"]),
                    income_frequency = (IncomeFrequency)Enum.Parse(typeof(IncomeFrequency), data["income_frequency"], true),// (IncomeFrequency)data["income_frequency"],
                    income_amount = Convert.ToInt32(data["income_amount"]),
                    income_type = data["income_type"],
                    loan_amount_desired = Convert.ToInt32(data["loan_amount_desired"]),
                    military = Convert.ToBoolean(data["military"]),
                    name_first = data["name_first"],
                    name_last = data["name_last"],
                    name_middle = data["name_middle"],
                    name_title = data["name_title"],
                    phone_home = data["phone_home"],
                    phone_cell = data["phone_cell"],
                    date_dob_d = Convert.ToInt32(data["date_dob_d"]),
                    date_dob_m = Convert.ToInt32(data["date_dob_m"]),
                    date_dob_y = Convert.ToInt32(data["date_dob_y"]),
                    residence_length_months = Convert.ToInt32(data["residence_length_months"]),
                    residence_type = data["residence_type"],
                    ssn_part_1 = data["ssn_part_1"],
                    ssn_part_2 = data["ssn_part_2"],
                    ssn_part_3 = data["ssn_part_3"],
                    state_id_number = data["state_id_number"],
                    state_issued_id = data["state_issued_id"],
                    bank_check_number = data["bank_check_number"]
                };

                return model;
            }
            catch (Exception Ex) {
                throw new ArgumentException(message: "El XML no cumple con el formato valido. " + Ex.Message);
            }
        }
    }

    // This to clases are to deserialize the XML in the given format of <root><data name="someName">value</data></root>
    [Serializable]
    public class DataValue {
        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlText]
        public string value { get; set; }
    }

    [Serializable]
    [XmlRoot("tss_loan_request")]
    public class LoanRequestRaw {
        [XmlElement("data")]
        public List<DataValue> data { get; set; }
    }
}
