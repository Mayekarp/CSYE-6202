using System;
using System.Text.RegularExpressions;

namespace HealthRecordApp
{
	public class HealthProfileHelper
	{
		public static bool ValidateFirstName(string firstName)
		{
            if(String.IsNullOrEmpty(firstName))
            {
                return false;
            }
            var result = false;
            if (Regex.IsMatch(firstName, "^[a-z]+$", RegexOptions.IgnoreCase))
                result = true;
            else if (firstName == null )
            {
                
                result = false;
            }
            return result;
		}

		public static bool ValidateLastName(string lastName)
		{
            if (String.IsNullOrEmpty(lastName))
            {
                return false;
            }
            var result = false;
            if (Regex.IsMatch(lastName, "^[a-z]+$", RegexOptions.IgnoreCase))
                result = true;
            else if (lastName == null)
            {
                result = false;
            }

            return result;
        }

		public static bool ValidateGender(string enteredGender, ref Gender patientGender)
		{
            var result = false;
            if (enteredGender.ToLower().Equals("female"))
            {
                patientGender = Gender.Female;

                result = true;
            }
            if (enteredGender.ToLower().Equals("male"))
            {
                patientGender = Gender.Male;
                result = true;
            }
            if (enteredGender.ToLower().Equals("unspecified"))
            {
                patientGender = Gender.Unspecified;
                result = true;

            }
			return result;
		}

		public static bool ValidateDateOfBirth(string enteredDOB, ref DateTime patientDOB)
		{
            DateTime db = DateTime.Now;
            //return DateTime.TryParse(enteredDOB, out patientDOB) ? true : false;
            var result = false;

            if (DateTime.TryParse(enteredDOB, out patientDOB))
            {
                result = true;
            }
            else
            {
                result= false;
            }
            if( db.CompareTo(patientDOB) < 0)
            {
                patientDOB = DateTime.MinValue;
                return false;
            }
            return result;

        }

        public static bool ValidateHeight(string heightInString, ref int patientHeight)
		{
            int h = 0;
            if (int.TryParse(heightInString,out h))
            {
                if (h >0)
                {
                    patientHeight = h;
                    return true;
                }
                else
                {
                    return false;
                }
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
                if(w > 0) {
                    patientWeight = w;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
	}
}
