using Entities;
using System;

namespace Logic.Implementation.Helpers {
    public static class Validator {
        public static bool Validate(LoanRequest model) {
            // Validation 1
            DateTime DOB = new DateTime(model.date_dob_y, model.date_dob_m, model.date_dob_d);
            if (DOB.AddYears(18) > DateTime.Today) {
                throw new Exception(message: "No es una persona mayor de edad.");
            }

            // Validation 2
            if (model.employer_length_months <= 12) {
                throw new Exception(message: "El nodo de “employer_length_months” debe ser mayor a 12.");
            }

            // Validation 3
            if (model.loan_amount_desired < 200 || model.loan_amount_desired > 500) {
                throw new Exception(message: "El nodo “loan_amount_desired” no puede ser menor a 200 ni mayor a 500.");
            }

            // Validation 4.1
            if (model.home_state.Length != 2) {
                throw new Exception(message: "El nodo “home_state” siempre debe tener largo de 2 caracteres.");
            }

            // Validation 4.2
            switch (model.home_state) {
                case "CA":
                case "FL":
                case "NY":
                case "ND":
                case "GA":
                case "NC":
                    throw new Exception(message: "El valor del nodo “home_state” no puede ser ninguno de los siguientes: CA, FL, NY, ND, GA, NC.");
                default:
                    break;
            }

            // Validation 5
            if (!Enum.IsDefined(typeof(IncomeFrequency), model.income_frequency)) {
                throw new Exception(message: "El nodo “income_frequency” solo puede ser alguno de los siguientes valores: Weekly, Biweekly, Monthly, Twice.");
            }

            // Validation 6.1
            switch (model.income_frequency) {
                case IncomeFrequency.WEEKLY:
                    model.income_frequency = IncomeFrequency.MONTHLY;

                    int WeeklyToMonthly = model.income_amount * 4;

                    model.income_amount = WeeklyToMonthly;

                    break;
                case IncomeFrequency.BIWEEKLY:
                case IncomeFrequency.TWICE:
                    model.income_frequency = IncomeFrequency.MONTHLY;

                    int MonthlyAmount = model.income_amount * 2;

                    model.income_amount = MonthlyAmount;

                    break;
                default:
                    break;
            }

            // Validation 6.2
            // No entendi bien esto: Asimismo,
            // se debe validar que el salario mensual solo puede estar +-15 % de $2000, de lo contrario
            // será rechazado.

            return true;
        }
    }
}
