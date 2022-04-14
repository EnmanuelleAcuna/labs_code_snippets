using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Entities {
    [DataContract]
    public class LoanRequest {
        [DataMember]
        public int sub_id { get; set; }

        [DataMember]
        public string bank_account_type { get; set; }

        [DataMember]
        public string bank_name { get; set; }

        [DataMember]
        public string client_url_root { get; set; }

        [DataMember]
        public int customer_id { get; set; }

        [DataMember]
        public int employer_length_months { get; set; }

        [DataMember]
        public string employer_name { get; set; }

        [DataMember]
        public string ext_work { get; set; }

        [DataMember]
        public string home_city { get; set; }

        [DataMember]
        public string home_state { get; set; }

        [DataMember]
        public string home_street { get; set; }

        [DataMember]
        public int home_zip { get; set; }

        [DataMember]
        public int income_date1_d { get; set; }

        [DataMember]
        public int income_date1_m { get; set; }

        [DataMember]
        public int income_date1_y { get; set; }

        [DataMember]
        public int income_date2_d { get; set; }

        [DataMember]
        public int income_date2_m { get; set; }

        [DataMember]
        public int income_date2_y { get; set; }

        [DataMember]
        public IncomeFrequency income_frequency { get; set; }

        [DataMember]
        public int income_amount { get; set; }

        [DataMember]
        public string income_type { get; set; }

        [DataMember]
        public int loan_amount_desired { get; set; }

        [DataMember]
        public bool military { get; set; }

        [DataMember]
        public string name_first { get; set; }

        [DataMember]
        public string name_last { get; set; }

        [DataMember]
        public string name_middle { get; set; }

        [DataMember]
        public string name_title { get; set; }

        [DataMember]
        public string phone_home { get; set; }

        [DataMember]
        public string phone_cell { get; set; }

        [DataMember]
        public int date_dob_d { get; set; }

        [DataMember]
        public int date_dob_m { get; set; }

        [DataMember]
        public int date_dob_y { get; set; }

        [DataMember]
        public int residence_length_months { get; set; }

        [DataMember]
        public string residence_type { get; set; }

        [DataMember]
        public string ssn_part_1 { get; set; }

        [DataMember]
        public string ssn_part_2 { get; set; }

        [DataMember]
        public string ssn_part_3 { get; set; }

        [DataMember]
        public string state_id_number { get; set; }

        [DataMember]
        public string state_issued_id { get; set; }

        [DataMember]
        public string bank_check_number { get; set; }
    }
}
