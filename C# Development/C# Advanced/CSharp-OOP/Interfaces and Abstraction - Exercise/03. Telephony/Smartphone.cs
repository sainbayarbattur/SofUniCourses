namespace Telephony
{
    using System;
    public class Smartphone : ISmartphone
    {
        private string phone;
        private string site;

        public string Site
        {
            get => this.site;
            set
            {
                if (!IsValidSite(value))
                {
                    throw new Exception("Invalid URL!");
                }
                site = value;
            }
        }

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

        private bool IsValidSite(string value)
        {
            foreach (var character in value)
            {
                if (char.IsDigit(character))
                {
                    return false;
                }
            }
            return true;
        }

        public string Browsing()
        {
            return $"Browsing: {Site}!";
        }

        public string Call()
        {
            return $"Calling... {Phone}";
        }
    }
}