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
    public static class MethodsHandler
    {
        /// <summary>
        /// this is the method responsible for storing method names and parameters
        /// </summary>
        private static Dictionary<string, object> methods = new Dictionary<string, object>();

        /// <summary>
        /// this is the method for storing the defined method parameters
        /// </summary>
        private static Dictionary<string, object> methodParameters = new Dictionary<string, object>();

        /// <summary>
        /// method for storing defined method commands
        /// </summary>
        private static Dictionary<string, object> methodCommands = new Dictionary<string, object>();

        /// <summary>
        /// method for setting variable key and object values
        /// </summary>
        /// <param name="methodName">this the variable key</param>
        /// <param name="value">this variable object value</param>
        public static void SetMethod(string methodName, object value)
        {
            methods[methodName] = value;    
        }


        /// <summary>
        /// method for getting methods
        /// </summary>
        /// <param name="name">this the variable name</param>
        /// <returns></returns>
        /// <exception cref="Exception">thrown when a variable does not exist</exception>
        public static object GetMethod(string name)
        {
            if(methods.ContainsKey(name)) return methods[name];
            throw new Exception($"Method {name} not found");
        }

        public static void SetMethodParameters(string methodName, object value)
        {
            methodParameters[methodName] = value;
        }

        public static object GetMethodParameters(string methodName)
        {
            if (methodParameters.ContainsKey(methodName)) return methodParameters[methodName];
            throw new Exception($"Method {methodName} not found");
        }

        public static void SetMethodCommands(string methodName, object value)
        {
            methodCommands[methodName] = value;
        }

        public static object GetMethodCommands(string methodName)
        {
            if (methodCommands.ContainsKey(methodName)) return methodCommands[methodName];
            throw new Exception($"Method {methodName} not found");
        }
    }
}
