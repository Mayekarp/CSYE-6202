using System;
using System.Text.RegularExpressions;

namespace HealthRecordApp
{
	public class HealthProfileHelper
	{
		public static bool ValidateFirstName(string firstName)
		{
            if (Regex.IsMatch(firstName, "^[a-z]+$", RegexOptions.IgnoreCase))
                return true;
            else
            {
                return false;
            }
		}

		public static bool ValidateLastName(string lastName)
		{

            if (Regex.IsMatch(lastName, "^[a-z]+$", RegexOptions.IgnoreCase))
                return true;
            else
            {
                return false;
            }
        }

		public static bool ValidateGender(string enteredGender, ref Gender patientGender)
		{
            var result = false;
            if (enteredGender.ToLower().Equals("f"))
            {
                patientGender = Gender.Female;

                result = true;
            }
            if (enteredGender.ToLower().Equals("m"))
            {
                patientGender = Gender.Male;
                result = true;
            }
            if (enteredGender.ToLower().Equals("u"))
            {
                patientGender = Gender.Unspecified;
                result = true;

            }
			return result;
		}

		public static bool ValidateDateOfBirth(string enteredDOB, ref DateTime patientDOB)
		{
            DateTime db = new DateTime();
            //return DateTime.TryParse(enteredDOB, out patientDOB) ? true : false;

            if (DateTime.TryParse(enteredDOB, out db))
            {
                
                patientDOB = db;
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool ValidateHeight(string heightInString, ref int patientHeight)
		{
            int h = 0;
            if (int.TryParse(heightInString,out h))
            {
                patientHeight = h;
                return true;
            }
            else
            {
                return false;
            }
            
		}

		public static bool ValidateWeight(string weightInString, ref int patientWeight)
		{
            int w = 0;
            if (int.TryParse(weightInString, out w))
            {
                patientWeight = w;
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}
