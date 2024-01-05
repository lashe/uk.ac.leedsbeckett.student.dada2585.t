using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.ac.leedsbeckett.student.dada2585.t
{
    /// <summary>
    /// class for handling setting and getting variable command
    /// </summary>
    public static class VariablesHandler
    {
        /// <summary>
        /// this is the method responsible for storing variable names and values
        /// </summary>
        private static Dictionary<string, object> variables = new Dictionary<string, object>();

        /// <summary>
        /// method for setting variable key and object values
        /// </summary>
        /// <param name="name">this the variable key</param>
        /// <param name="value">this variable object value</param>
        public static void SetVariable(string name, object value)
        {
            variables[name] = value;    
        }
        /// <summary>
        /// method for getting variables
        /// </summary>
        /// <param name="name">this the variable name</param>
        /// <returns></returns>
        /// <exception cref="Exception">thrown when a variable does not exist</exception>
        public static object GetVariable(string name)
        {
            if(variables.ContainsKey(name)) return variables[name];
            throw new Exception($"Variable {name} not found");
        }

        /// <summary>
        /// method for updating a variable value
        /// </summary>
        /// <param name="name">variable name</param>
        /// <param name="newValue"> new value</param>
        /// <exception cref="ArgumentException"></exception>
        public static void UpdateVariable(string name, object newValue)
        {
            if(variables.ContainsKey(name))
            {
                variables[name] = newValue;
            }
            else
            {
                throw new ArgumentException($"Variable {name} not found");
            }
        }
    }
}
