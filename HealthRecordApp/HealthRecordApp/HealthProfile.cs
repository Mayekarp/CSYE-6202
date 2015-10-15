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
        private DateTime dOB;
        private int heightInInches;
        private int weightInPounds;
        private Gender gender;

        public HealthProfile()
        { }

        public HealthProfile (string firstName, string lastName, DateTime dateofbirth, int height, int weight)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.dOB = dateofbirth;
            this.heightInInches = height;
            this.WeightInPounds = weight;
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

        public DateTime DOB
        {
            get { return dOB; }
            set { dOB = value; }
        }

        public int HeightInInches
        {
            get { return heightInInches; }
            set { heightInInches = value; }
        }

        public int WeightInPounds
        {
            get { return weightInPounds; }
            set { weightInPounds = value; }
        }

        public Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        

        #region Methods

        public int CalculateAge()
		{
            
            int Days = (DateTime.Now.Year * 365 + DateTime.Now.DayOfYear) - (dOB.Year * 365 + dOB.DayOfYear);
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

            decimal BMI = 0;
            BMI = ((WeightInPounds * 703m) / (HeightInInches* HeightInInches));
            BMI =Decimal.Round(BMI, 2);
            return BMI;
		}

		public void DisplayPatientProfile()
		{
            Console.WriteLine("\nDisplaying Patient's Profile");
            Console.WriteLine("\nFirst Name: " +FirstName);
            Console.WriteLine("\nLast Name: " +LastName);
            Console.WriteLine("\nGender: " +gender);
            Console.WriteLine("\nDateOfBirth: " +dOB);
            Console.WriteLine("\nAge: " +CalculateAge());
            Console.WriteLine("\nMaxHeartRate: " +CalculateMaxHeartRate());
            Console.WriteLine("\nBMI: " +CalculateBMI());
            
        }

        
        #endregion
    }
}
