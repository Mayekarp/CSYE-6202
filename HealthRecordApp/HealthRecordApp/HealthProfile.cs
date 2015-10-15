using System;

namespace HealthRecordApp
{
	public enum Gender
	{
		Unspecified,
		Male,
		Female
	}

	public class HealthProfile
	{
		private const int UnknownValue = -1;
        private string firstName;
        private string lastName;
        private DateTime dateofbirth;
        private int height;
        private int weight;
        private Gender gender;

        public HealthProfile()
        { }

        public HealthProfile (string firstName, string lastName, DateTime dateofbirth, int height, int weight)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.dateofbirth = DateOfBirth;
            this.height = Height;
            this.weight = Weight;
            this.gender = Gender;         }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateofbirth; }
            set { dateofbirth = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        

        #region Methods

        public int CalculateAge()
		{
            
            int Days = (DateTime.Now.Year * 365 + DateTime.Now.DayOfYear) - (dateofbirth.Year * 365 + dateofbirth.DayOfYear);
            int Years = Days / 365;
            //string age = (Days >= 365) ? "Your age: " + Years + "Years" ;

            return(Years);

           // CalculateMaxHeartRate(Years);
			//return UnknownValue;
		}

		public int CalculateMaxHeartRate()
		{
            //int num;
            //Int32.TryParse(age, out num );
            //int MaxHeartRate = 220 - num;

            //Console.Write(MaxHeartRate);
            return( 220 - CalculateAge());
			//return UnknownValue;
		}

		public decimal CalculateBMI()
		{
            
            //int factor = 730;
            //feet = Convert.ToInt32(Console.Read());
            //inches = Convert.ToInt32(Console.Read());
            //pounds = Convert.ToInt32(Console.Read());

            //height = (feet * 12) + inches;
            //BMI = 
            // return UnknownValue;

            decimal d = 0;
            d= ((Weight * 703m) / (Height* Height));
            return d;
		}

		public void DisplayPatientProfile()
		{
            Console.Write("Displaying Patiet's Profile");
            Console.WriteLine("\nFirst Name: " +FirstName);
            Console.WriteLine("\nLast Name: " +LastName);
            Console.WriteLine("\nGender: " +gender);
            Console.WriteLine("\nDateOfBirth: " +dateofbirth);
            Console.WriteLine("\nAge: " +CalculateAge());
            Console.WriteLine("\nMaxHeartRate: " +CalculateMaxHeartRate());
            Console.WriteLine("\nBMI: " +CalculateBMI());
            
        }

        
        #endregion
    }
}
