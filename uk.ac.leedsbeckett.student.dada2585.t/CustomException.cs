using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    public class CustomException : Exception
    {
        public CustomException(ArrayList errorList) : base(BuildExceptionMessage(errorList))
        {
            
        }

        private static string BuildExceptionMessage(ArrayList errorList)
        {
            // exception message using the elements in the array list
            string message = "Errors occurred:";
            foreach (var error in errorList)
            {
                message += $"\n- {error}";
            }
            return message;
        }
    }
}
