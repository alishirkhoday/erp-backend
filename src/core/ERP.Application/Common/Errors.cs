namespace ERP.Application.Common
{
    public abstract class Errors
    {
        public abstract class General
        {
            public static Error IdIsEmpty()
            {
                return new Error("IdIsEmpty", "Id is empty.");
            }

            public static Error NotFound(string? id = null, string? entity = null)
            {
                string forId = id == null ? "" : $" for Id '{id}'";
                string forEntity = entity == null ? "" : $" from '{entity}'";
                return new Error("RecordNotFound", $"Record not found{forId}{forEntity}!");
            }

            public static Error AlreadyExists(object record)
            {
                return new Error("RecordAlreadyExistence", $"Record already exists for {record}.");
            }

            public static Error AnErrorHasOccurred()
            {
                return new Error("AnErrorHasOccurred", $"An error has occurred.");
            }

            public static Error NotSavedChanges()
            {
                return new Error("NotSavedChanges", "Not saved changes.");
            }
        }

        public abstract class User
        {
            public static Error UsernameIsUsed(string username)
            {
                return new Error("UsernameIsUsed", $"{username} is used.");
            }

            public static Error MobilePhoneNumberIsUsed(string mobilePhoneNumberWithRegionCode)
            {
                return new Error("UserMobilePhoneNumberIsAlreadyRegistered", $"MobilePhoneNumber {mobilePhoneNumberWithRegionCode} is already registered.");
            }

            public static Error EmailIsUsed(string email)
            {
                return new Error("UserEmailIsAlreadyRegistered", $"Email {email} is already registered.");
            }

            public static Error YouMustChooseOneOfTheRegistrationMethods()
            {
                return new Error("YouMustChooseOneOfTheRegistrationMethods", "You must choose one of the registration methods : Mobile phone number or Email.");
            }

            public static Error ThisMobilePhoneNumberDoesNotMatch()
            {
                return new Error("ThisMobilePhoneNumberDoesNotMatch", "This mobile phone number does not match the user's mobile phone number.");
            }

            public static Error ThisEmailDoesNotMatch()
            {
                return new Error("ThisEmailDoesNotMatch", "This email does not match the user's email.");
            }

            public static Error YouMustChooseOneOfTheMethods()
            {
                return new Error("YouMustChooseOneOfTheMethods", "You must choose one of the methods : Mobile phone number or Email.");
            }

            public static Error TheNumberOfRequestsForVerificationCodeHasBeenReached()
            {
                return new Error("TheNumberOfRequestsForVerificationCodeHasBeenReached", $"The number of requests for verification code has been reached.");
            }

            public static Error VerificationCodeIsNotValid()
            {
                return new Error("VerificationCodeIsNotValid", $"Verification code is not valid.");
            }

            public static Error UserNotFound()
            {
                return new Error("UserNotFound", $"User not found.");
            }

            public static Error MobilePhoneNumberNotConfirm(string mobilePhoneNumberRegionCode, string mobilePhoneNumber)
            {
                return new Error("UserMobilePhoneNumberNotConfirm", $"MobilePhoneNumber {mobilePhoneNumberRegionCode}{mobilePhoneNumber} not confirm.");
            }

            public static Error EmailNotConfirm(string email)
            {
                return new Error("UserEmailNotConfirm", $"Email {email} not confirm.");
            }

            public static Error UserIsNotActive()
            {
                return new Error("UserIsNotActive", $"User is not active.");
            }

            public static Error UserIsBan()
            {
                return new Error("UserIsBan", $"User is ban.");
            }

            public static Error PasswordIsWrong()
            {
                return new Error("PasswordIsWrong", $"Password is wrong.");
            }

            public static Error UserAccountIsLocked(string errorMessage)
            {
                return new Error("UserAccountIsLocked", $"User account is locked for {errorMessage}.");
            }

            public static Error UsernameNotFound(string username)
            {
                return new Error("UsernameIsNotRegistered", $"Username {username} is not registered.");
            }

            public static Error MobilePhoneNumberNotFound(string mobilePhoneNumberWithRegionCode)
            {
                return new Error("MobilePhoneNumberIsNotRegistered", $"MobilePhoneNumber {mobilePhoneNumberWithRegionCode} is not registered.");
            }

            public static Error EmailNotFound(string email)
            {
                return new Error("EmailIsNotRegistered", $"Email {email} is not registered.");
            }

            public static Error CurrentPasswordIsWrong()
            {
                return new Error("CurrentPasswordIsWrong", $"Current password is wrong.");
            }
        }

        public abstract class Human
        {
            public static Error NationalIdIsUsed(string nationalId)
            {
                return new Error("NationalIdIsUsed", $"{nationalId} is used.");
            }

            public static Error PassportIdIsUsed(string passportId)
            {
                return new Error("PassportIdIsUsed", $"{passportId} is used.");
            }
        }

        public abstract class Account
        {
            public static Error NameIsUsed(string name)
            {
                return new Error("NameIsUsed", $"{name} is used.");
            }

            public static Error AccountNotFound()
            {
                return new Error("AccountNotFound", $"Account not found.");
            }

            public static Error ParentAccountIdIsEmpty()
            {
                return new Error("ParentAccountIdIsEmpty", "Parent account id is empty.");
            }

            public static Error ParentAccountNotFound()
            {
                return new Error("ParentAccountNotFound", $"Parent account not found.");
            }

            public static Error ParentAccountIsFinal()
            {
                return new Error("ParentAccountIsFinal", $"Parent account is final.");
            }

            public static Error ParentAccountGroupIsEqualToAccountGroup()
            {
                return new Error("ParentAccountGroupIsEqualToAccountGroup", $"Parent account group is equal to account group.");
            }
        }
    }
}
