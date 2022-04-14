using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Logic.Contract;
using Entities;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Logic.Implementation.Helpers;

namespace Logic.Implementation {
    public class LoanService : ILoanService {
        public string Request(string data) {
            if (string.IsNullOrEmpty(data)) {
                return string.Format("El contenido del XML no puede venir vacio.");
            }

            try {
                XmlDocument xmlDoc = Deserializer.GetXMLFromString(data);

                LoanRequest model = Deserializer.DeserializeXMLToLoanRequest(xmlDoc);

                bool valido = Validator.Validate(model);

                if (valido) {
                    return string.Format("El XML ID: {0}, fue aceptado con el nombre {1} {2}", model.customer_id, model.name_first, model.name_last);
                }
                else {
                    return string.Format("El XML no cumple con el formato valido.");
                }
            }
            catch (Exception Ex) {
                return string.Format("El XML no cumple con el formato valido. {0}", Ex.Message);
            }
        }
    }
}
