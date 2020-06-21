using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Crediting
{
    class GlobalVariables
    {
        private static int _employeeId = 0;

        public static int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        private static string _employeeFirstName = "";

        public static string EmployeeFirstName
        {
            get { return _employeeFirstName; }
            set { _employeeFirstName = value; }
        }

        private static string _employeeLastName = "";

        public static string EmployeeLastName
        {
            get { return _employeeLastName; }
            set { _employeeLastName = value; }
        }
    }
}
