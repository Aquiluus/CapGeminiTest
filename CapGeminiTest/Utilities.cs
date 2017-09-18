using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace CapGeminiTest
{
    /// <summary>
    /// Utility class for general usage methods
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Method verifying whether data input in forms is valid
        /// </summary>
        /// <param name="name">Customer Name</param>
        /// <param name="surname">Customer surname</param>
        /// <param name="telephone">Customer telephone number</param>
        /// <param name="address">Customer Address (street, home number)</param>
        /// <param name="code">Customer Postal Code</param>
        /// <param name="city">Customer City</param>
        /// <returns></returns>
        public static Boolean VerifyFormsCorrect(string name, string surname, string telephone, string address, string code, string city)
        {
            var regexItemName = new Regex("^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]*$");
            var regexItemSurname = new Regex("^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ-]*$");
            var regexItemAddress = new Regex("^[-A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ0-9 ]*$");
            var regexItemCity = new Regex("^[-A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ ]*$");
            var regexItemTelephone = new Regex("^[0-9]*$");
            var regexItemCode = new Regex("^[0-9-]*$");
            try
            {
                if (!String.IsNullOrEmpty(name))
                {
                    if (!regexItemName.IsMatch(name))
                    {
                        throw new Exception("Name contains invalid characters");
                    }

                }
                else throw new Exception("Name cannot be empty");
                if (!String.IsNullOrEmpty(surname))
                {
                    if (!regexItemSurname.IsMatch(surname))
                    {
                        throw new Exception("Surname contains invalid characters");
                    }
                }
                else throw new Exception("Surname cannot be empty");
                if (!String.IsNullOrEmpty(telephone) || telephone.Length > 15)
                {
                    if (!regexItemTelephone.IsMatch(telephone))
                    {
                        throw new Exception("Telephone number contains invalid characters");
                    }
                }
                else throw new Exception("Provide a valid telephone number");
                if (!String.IsNullOrEmpty(address))
                {
                    if (!regexItemAddress.IsMatch(address))
                    {
                        throw new Exception("Address contains invalid characters");
                    }
                }
                else throw new Exception("Address cannot be empty");
                if (!String.IsNullOrEmpty(code))
                {
                    if (!regexItemCode.IsMatch(code))
                    {
                        throw new Exception("Postal code contains invalid characters");
                    }
                }
                else throw new Exception("Postal Code cannot be empty");
                if (!String.IsNullOrEmpty(city))
                {
                    if(!regexItemCity.IsMatch(city))
                    {
                        throw new Exception("City name contains invalid characters");
                    }
                }
                else throw new Exception("City cannot be empty");
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }
    }
}