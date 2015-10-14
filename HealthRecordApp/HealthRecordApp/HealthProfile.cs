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
        private float height;
        private float weight;


        public HealthProfile (string firstName, string lastName)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.height = Height;
            this.weight = Weight;

        }

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

        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        #region Methods

        public int CalculateAge()
		{
            Console.Write("Enter your Date of Birth: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            int Days = (DateTime.Now.Year * 365 + DateTime.Now.DayOfYear) - (birthDate.Year * 365 + birthDate.DayOfYear);
            int Years = Days / 365;
            string message = (Days >= 365) ? "Your age: " + Years + "Years" : "Your Age:" + Days + "days";

            Console.Write(message);

			return UnknownValue;
		}

		public int CalculateMaxHeartRate()
		{
			return UnknownValue;
		}

		public decimal CalculateBMI()
		{
			return UnknownValue;
		}

		public void DisplayPatientProfile()
		{
		}

		#endregion
	}
}
