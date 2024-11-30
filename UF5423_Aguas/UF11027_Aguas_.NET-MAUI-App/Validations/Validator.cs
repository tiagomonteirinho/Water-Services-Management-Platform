﻿using System.Text.RegularExpressions;

namespace UF11027_Aguas_.NET_MAUI_App.Validations
{
    public class Validator : IValidator
    {
        public string NameError { get; set; } = "";
        public string EmailError { get; set; } = "";
        public string PhoneNumberError { get; set; } = "";
        public string SerialNumberError { get; set; } = "";

        private const string EmptyNameErrorMessage = "Name is required.";
        private const string InvalidNameErrorMessage = "Name is invalid.";
        private const string EmptyEmailErrorMessage = "Email is required.";
        private const string InvalidEmailErrorMessage = "Email is invalid.";
        private const string EmptyPhoneNumberErrorMessage = "Phone number is required.";
        private const string InvalidPhoneNumberErrorMessage = "Phone number is invalid.";
        private const string EmptySerialNumberErrorMessage = "Serial number is required.";
        private const string InvalidSerialNumberErrorMessage = "Serial number is invalid.";

        public Task<bool> Validate(string name, string email, string phoneNumber, string serialNumber)
        {
            var isNameValid = ValidateName(name);
            var isEmailValid = ValidateEmail(email);
            var isPhoneNumberValid = ValidatePhoneNumber(phoneNumber);
            var isSerialNumberValid = ValidateSerialNumber(serialNumber);
            return Task.FromResult(isNameValid && isEmailValid && isPhoneNumberValid);
        }

        private bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                NameError = EmptyNameErrorMessage;
                return false;
            }

            if (name.Length < 3)
            {
                NameError = InvalidNameErrorMessage;
                return false;
            }

            NameError = "";
            return true;
        }

        private bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                EmailError = EmptyEmailErrorMessage;
                return false;
            }

            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                EmailError = InvalidEmailErrorMessage;
                return false;
            }

            EmailError = "";
            return true;
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                PhoneNumberError = EmptyPhoneNumberErrorMessage;
                return false;
            }

            if (phoneNumber.Length < 9)
            {
                PhoneNumberError = InvalidPhoneNumberErrorMessage;
                return false;
            }

            PhoneNumberError = "";
            return true;
        }

        private bool ValidateSerialNumber(string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber))
            {
                SerialNumberError = EmptySerialNumberErrorMessage;
                return false;
            }

            if (serialNumber.Length < 6 || !Regex.IsMatch(serialNumber, @"^\d+$"))
            {
                SerialNumberError = InvalidSerialNumberErrorMessage;
                return false;
            }

            SerialNumberError = "";
            return true;
        }
    }
}