using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortal_Ganesh.Models
{

    public class EmployeeDetails
    {
        #region Variables
        private string _emp_no;
        private string _first_name;
        private string _last_name;
        private string _emp_name;
        private string _dob;
        private DateTime _dt_dob;
        private string _gender;
        private string _pan_num;
        private string _aadhaar_num;
        private string _mobile_num;
        private string _email_id;
        private string _office_mail;
        private string _permanent_address;
        private string _present_address;
        private string _blood_group;
        private string _doj;
        private DateTime _dt_doj;
        private string _emp_level;
        private string _post;
        private string _basic_pay;
        private string _house_allowance;
        private string _modelstate_result;
        private string _modelstate_message;
        private string _profile_pict;
        private string _alert;
        private string _alert_message;
        private string _Result;
        private bool _is_mailid_exist;
        private bool _b_edit_falge;


        [Required(ErrorMessage = "Please enter emp no#")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please input numeric only!")]
        [StringLength(5, ErrorMessage = "Please input 5 characters only!", MinimumLength = 5)]
        [Remote("IsEmpIdExist", "Employee", ErrorMessage = "Emp no# exist already")]
        public string emp_no {get {return _emp_no;}set {_emp_no = value;}}

        [Required(ErrorMessage = "Please enter fiest name")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Please input alphabet only!")]
        [StringLength(50, ErrorMessage = "Input between 1 to 50 characters!", MinimumLength = 1)]
        public string first_name {get { return _first_name; }set { _first_name = value; }}

        [Required(ErrorMessage = "Please enter last name")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Please input alphabet only!")]
        [StringLength(50, ErrorMessage = "Input between 1 to 50 characters!", MinimumLength = 1)]
        public string last_name {get { return _last_name; }set { _last_name = value; }}

        public string emp_name { get { return _emp_name; } set { _emp_name = value; } }

        [Required(ErrorMessage = "Please enter dob")]
        public string dob { get { return _dob; } set { _dob = value; } }
        public DateTime dt_dob { get { return _dt_dob; } set { _dt_dob = value; } }
        

        [Required(ErrorMessage = "Please input valid gender!")]
        public string gender { get { return _gender; } set { _gender = value; } }

        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Please input alphanumeric only!")]
        [StringLength(10, ErrorMessage = "Please input 10 characters only!", MinimumLength = 10)]
        public string pan_num { get { return _pan_num; } set { _pan_num = value; } }


        [RegularExpression("^[0-9]*$", ErrorMessage = "Please input numeric only!")]
        [StringLength(12, ErrorMessage = "Please input 12 numers only!", MinimumLength = 12)]
        public string aadhaar_num { get { return _aadhaar_num; } set { _aadhaar_num = value; } }

        [Required(ErrorMessage = "Please enter mobile number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please input numeric only!")]
        [StringLength(10, ErrorMessage = "Please input 10 characters only!", MinimumLength = 10)]
        public string mobile_num { get { return _mobile_num; } set { _mobile_num = value; } }

        [Required(ErrorMessage = "Please enter email id")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please input a valid email!")]
        [Remote("IsEmpPersonalMailIdExist", "Employee",ErrorMessage = "Email id is already taken!")]
        public string email_id { get { return _email_id; } set { _email_id = value; } }

        [Required(ErrorMessage = "Please enter office mail")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please input a valid email!")]
        [Remote("IsEmpOfficeMailExist", "Employee",ErrorMessage = "Email id is already taken!")]
        public string office_mail { get { return _office_mail; } set { _office_mail = value; } }

        [StringLength(200, ErrorMessage = "Text should not exceeds 200 characters!", MinimumLength = 1)]
        public string permanent_address { get { return _permanent_address; } set { _permanent_address = value; } }

        [StringLength(200, ErrorMessage = "Text should not exceeds 200 characters!", MinimumLength = 1)]
        public string present_address { get { return _present_address; } set { _present_address = value; } }

        public string blood_group { get { return _blood_group; } set { _blood_group = value; } }

        [Required(ErrorMessage = "Please enter doj")]
        public string doj { get { return _doj; } set { _doj = value; } }
        public DateTime dt_doj { get { return _dt_doj; } set { _dt_doj = value; } }

        [Required(ErrorMessage = "Please select a value between 7 to 13!")]
        public string emp_level { get { return _emp_level; } set { _emp_level = value; } }

        [StringLength(30, ErrorMessage = "Please input within 30 characters", MinimumLength = 1)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Please input only alphabet and space")]
        public string post { get { return _post; } set { _post = value; } }

        [Required(ErrorMessage = "Please enter basic pay")]
        [StringLength(8, ErrorMessage = "Please input  between 3 to 8 characters!", MinimumLength = 3)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please input numeric only!")]
        public string basic_pay { get { return _basic_pay; } set { _basic_pay = value; } }

       
        [Required(ErrorMessage = "Please enter house allowance")]
        [StringLength(5, ErrorMessage = "Please input  between 3 to 5 characters!", MinimumLength = 3)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please input numeric only!")]
        public string house_allowance { get { return _house_allowance; } set { _house_allowance = value; } }

        public string modelstate_result { get { return _modelstate_result; } set { _modelstate_result = value; } }
        public string modelstate_message { get { return _modelstate_message; } set { _modelstate_message = value; } }
        public string profile_pict { get { return _profile_pict; } set { _profile_pict = value; } }

        public string alert { get { return _alert; } set { _alert = value; } }
        public string alert_message { get { return _alert_message; } set { _alert_message = value; } }
        public string Result { get { return _Result; } set { _Result = value; } }

        public bool is_mailid_exist { get { return _is_mailid_exist; } set { _is_mailid_exist = value; } }
        public bool b_edit_falge { get { return _b_edit_falge; } set { _b_edit_falge = value; } }
        #endregion

        
    }
}