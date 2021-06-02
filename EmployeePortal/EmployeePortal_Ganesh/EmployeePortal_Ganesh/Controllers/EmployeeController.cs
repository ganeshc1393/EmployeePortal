using EmployeePortal_Ganesh.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortal_Ganesh.Controllers
{
    public class EmployeeController : Controller
    {
        ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
        public EmployeeProcess objEmployeeProcess = EmployeeProcess.GetInstance;
        // GET: Employee
        public ActionResult EmployeeList()
        {
            try
            {
                EmployeeDetails objEmpDetials = new EmployeeDetails();

                ViewBag.alert = Convert.ToString(TempData["alert"]);
                ViewBag.alert_message = Convert.ToString(TempData["alert_message"]);
                return View(objEmpDetials);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }   
        }

        public ActionResult CreatEmployee()
        {
            try
            {
                EmployeeDetails objEmpDetials = new EmployeeDetails();
                objEmpDetials.modelstate_result = "True";
                return View(objEmpDetials);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult CreatEmployee(EmployeeDetails objEmpDetials)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objEmpDetials.profile_pict = Path.Combine(Server.MapPath("~/img"), "Sample_User_Icon.png");
                    if (!objEmpDetials.b_edit_falge)
                    {
                        objEmpDetials.Result = Convert.ToString(objEmployeeProcess.InsertEmployeeDetails(objEmpDetials));
                    }
                    else
                    {
                        objEmpDetials.Result = Convert.ToString(objEmployeeProcess.UpdateEmployeeDetails(objEmpDetials));
                    }

                    if (objEmpDetials.Result == "True")
                    {
                        TempData["alert"] = objEmpDetials.Result;
                        TempData["alert_message"] = "Employee record has been saved successfully.";
                        return RedirectToAction("EmployeeList", objEmpDetials);
                    }
                    else
                    {
                        TempData["alert"] = objEmpDetials.Result;
                        TempData["alert_message"] = "Server error has encountered, failed to save the record.";
                        return View("EmployeeList", objEmpDetials);
                    }
                }
                else
                {
                    objEmpDetials.modelstate_result = ModelState.IsValid.ToString();
                    objEmpDetials.modelstate_message = "Form has invalid input data, please correct the errors and submit again!!!";

                    return View(objEmpDetials);
                }


            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
            finally
            {
                objEmpDetials = null;
            }
            
        }

        public ActionResult GetAllEmployeeList()
        {
            try
            {
                var lstemp = objEmployeeProcess.GetEmployeList();
                return Json(lstemp);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }

        }

        public ActionResult GetEmployeeListBySearch(string emp_no, string emp_name, string gender)
        {
            try
            {
                if (string.IsNullOrEmpty(emp_no) && string.IsNullOrEmpty(emp_name) && string.IsNullOrEmpty(gender))
                {
                    // getting all employee list
                    var lstemp = objEmployeeProcess.GetEmployeList();
                    return Json(lstemp);
                }
                else
                {
                    // getting employee list by search 
                    var lstemp = objEmployeeProcess.GetEmployeeListBySearch(emp_no, emp_name, gender);
                    return Json(lstemp);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }

        }

        public ActionResult Edit(string id)
        {
            EmployeeDetails objempresult = new EmployeeDetails();
            try
            {
                objempresult = objEmployeeProcess.GetEmployeeDetailsById(id);
                objempresult.b_edit_falge = true;
                
                return View("CreatEmployee",objempresult);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
        }

        public ActionResult Delete(string id)
        {
            bool bresult = false;
            EmployeeDetails objEmpDetials = new EmployeeDetails();
            try
            {
                bresult = objEmployeeProcess.DeleteEmployeeDetailsById(id);
                if (bresult)
                {
                    ViewBag.alert = "True";
                    ViewBag.alert_message = "Employee record has been deleted successfully.";
                    return View("EmployeeList");
                }
                else
                {
                    ViewBag.alert = "False";
                    ViewBag.alert_message = "Server error has encountered, failed to delete the record.";
                    return RedirectToAction("EmployeeList");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
        }


        public FileResult ExportToCsv(string emp_no, string emp_name, string gender)
        {
            try
            {
                var lstemp = objEmployeeProcess.GetExportEmpListBySearch(emp_no, emp_name, gender);
                StringBuilder sb = new StringBuilder();

                sb.Append("Emp Id,Name,Doj,Post,Level,Mobile,Personal mail,office mail,Dob,Blood Group,Pan No,Aadhaar No");

                //Add new line.  
                sb.Append("\r\n");
                if (lstemp != null && lstemp.Count() > 0)
                {
                    string separator = String.Empty;
                    foreach (var item in lstemp)
                    {
                        sb.Append(item.emp_no +"," + item.emp_name +"," + item.doj +"," + item.post +"," + item.emp_level +"," + item.mobile_num +"," + item.email_id +"," + item.office_mail +"," + item.dob +"," + item.blood_group +"," + item.pan_num +"," + item.aadhaar_num);
                        sb.Append("\r\n");
                    }

                }

                string current_date = DateTime.Now.ToString("yyyyMMdd");
                string filename="Employee_" + current_date;
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
                return File(buffer, "text/csv", filename+".csv");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
            

        }


        #region Custom Validation
        [HttpGet]
        public JsonResult IsEmpPersonalMailIdExist(string email_id)
        {
            try
            {
                bool isExist = objEmployeeProcess.CheckMailExistAlready(email_id);
                return Json(!isExist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
                
        }
        [HttpGet]
        public JsonResult IsEmpOfficeMailExist(string office_mail)
        {
            try
            {
                bool isExist = objEmployeeProcess.CheckMailExistAlready(office_mail);
                return Json(!isExist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
            
        }

        [HttpGet]
        public JsonResult IsEmpIdExist(string emp_no)
        {
            try
            {
                bool isExist = objEmployeeProcess.CheckEmpIdExistAlready(Convert.ToInt32(emp_no));
                return Json(!isExist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
        }

        #endregion
    }
}