namespace Problem_3._Telephony
{
    using System;

    public class StationaryPhone : IStationaryPhone
    {
        private string phone;

        public string Phone
        {
            get => this.phone;
            set
            {
                if (!IsValidNumber(value))
                {
                    throw new Exception("Invalid number!");
                }
                phone = value;
            }
        }

        public string Deal()
        {
            return $"Dialing... {Phone}";
        }

        private bool IsValidNumber(string value)
        {
            foreach (var character in value)
            {
                if (char.IsLetter(character))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
