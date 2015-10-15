using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthRecordApp;


namespace HealthRecordApp
{
	class Program
	{
        static HealthProfile healthProfile = new HealthProfile();

        static void Main(string[] args)
        {
            Boolean enteredvalue = false;
            Console.Write("Please Enter Person's first Name: ");
            while (!enteredvalue)
            {
                String firstName = Convert.ToString(Console.ReadLine());
                bool value = HealthProfileHelper.ValidateFirstName(firstName);

                if (value == false)
                {
                    Console.WriteLine("Invalid first Name. Please Enter Person's first Name: ");
                    
                }

                else
                {
                    healthProfile.FirstName = firstName;
                    Console.Write("Please Enter Person's last Name: ");
                }
                String lastName = Convert.ToString(Console.ReadLine());
                value = HealthProfileHelper.ValidateFirstName(lastName);

                if (value == false)
                {
                    Console.WriteLine("Invalid last Name. Please Enter Person's last Name: ");
                  
                }
                else
                {
                    healthProfile.LastName = lastName;
                    Console.Write("Please Enter Person's Gender (Unspecified/ Male/ Female): ");
                }

                String Gender = Convert.ToString(Console.ReadLine());
                Gender gender = new Gender();
                //Gender GenderType = HealthRecordApp.Gender.Female | HealthRecordApp.Gender.Male | HealthRecordApp.Gender.Unspecified;
                value = HealthProfileHelper.ValidateGender(Gender, ref gender);

                if (value == false)
                {
                    Console.WriteLine("Invalid Gender. Please Enter Person's Gender (Unspecified/ Male/ Female): ");
                    
                }
                else
                {
                    healthProfile.Gender = gender;
                    Console.Write("Please Enter Person's DateOfBirth: ");
                }

                String Datetime = Convert.ToString(Console.ReadLine());
                DateTime dateofbirth = new DateTime();
                value = HealthProfileHelper.ValidateDateOfBirth(Datetime, ref dateofbirth);

                if (value == false)
                {
                    Console.WriteLine("Invalid Date Of Birth. Please enter Person's Valid Date Of Birth: ");
                    
                }
                else
                {
                    //int DateOfBirth = int.Parse(Datetime);

                    healthProfile.DateOfBirth = dateofbirth;
                    Console.Write("Please Enter Person's Height: ");
                }

                String Height = Convert.ToString(Console.ReadLine());
                int h = 0;
                value = HealthProfileHelper.ValidateHeight(Height, ref h);

                if (value == false)
                {
                    Console.WriteLine("Invalid Height. Please enter Person's Valid Height: ");
                }
                else
	            {
                    healthProfile.Height = h;
                    Console.Write("Please Enter Person's Weight: ");
                }

                String Weight = Convert.ToString(Console.ReadLine());
                int w = 0;
                value = HealthProfileHelper.ValidateWeight(Weight, ref w);
                if (value == false)
                {
                    Console.WriteLine("Invalid Weight. Please enter Person's Valid Weight: ");
                }
                else
                {
                    healthProfile.Weight = w;
                    healthProfile.DisplayPatientProfile();                }



            }























        }


    }
}
