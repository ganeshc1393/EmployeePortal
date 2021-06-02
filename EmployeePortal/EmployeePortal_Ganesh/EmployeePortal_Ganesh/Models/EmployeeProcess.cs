using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EmployeePortal_Ganesh.Models
{
    public class EmployeeProcess
    {
        public static ILog log = log4net.LogManager.GetLogger(typeof(EmployeeProcess));

        
        private EmployeeProcess()
        {
        }

        private static EmployeeProcess _objinstance = null;
        public static EmployeeProcess GetInstance
        {
            get
            {
                if (_objinstance == null)
                {
                    _objinstance = new EmployeeProcess();
                }
                return _objinstance;
            }
        }

        public bool InsertEmployeeDetails(EmployeeDetails objEmpDetails)
        {
            using (EmployeePortal_GaneshEntities context = new EmployeePortal_GaneshEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        #region "Employee Details"
                        employee emp = new employee();
                        emp.emp_id = Convert.ToInt32(objEmpDetails.emp_no);
                        emp.first_name = objEmpDetails.first_name;
                        emp.last_name = objEmpDetails.last_name;
                        emp.gender = objEmpDetails.gender;
                        emp.dob = Convert.ToDateTime(objEmpDetails.dob);
                        emp.pan_num = objEmpDetails.pan_num;
                        emp.aadhaar_num = objEmpDetails.aadhaar_num;
                        emp.mobile_num = objEmpDetails.mobile_num;
                        emp.email_id = objEmpDetails.email_id;
                        emp.office_mail = string.IsNullOrEmpty(objEmpDetails.office_mail) ? "": objEmpDetails.office_mail;
                        emp.permanent_address = objEmpDetails.permanent_address;
                        emp.present_address = objEmpDetails.present_address;
                        emp.blood_group = objEmpDetails.blood_group;
                        emp.profile_pict = string.IsNullOrEmpty(objEmpDetails.profile_pict)? "": objEmpDetails.profile_pict;
                        emp.doj = Convert.ToDateTime(objEmpDetails.doj);
                        emp.emp_level = Convert.ToInt32(objEmpDetails.emp_level);
                        emp.post_name = objEmpDetails.post;
                        emp.basic_pay = Convert.ToInt32(objEmpDetails.basic_pay);
                        emp.house_allowance = Convert.ToInt32(objEmpDetails.house_allowance);
                        context.employees.Add(emp);
                        context.SaveChanges();

                        transaction.Commit();
                        return true;
                        #endregion
                    }
                    catch (DbEntityValidationException e)
                    {
                        log.Error(e.Message.ToString());
                        throw e;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        log.Error(ex.Message.ToString());
                        return false;
                    }
                }
            }
            
        }

        public bool UpdateEmployeeDetails(EmployeeDetails objEmpDetails)
        {
            using (EmployeePortal_GaneshEntities context = new EmployeePortal_GaneshEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int empid = Convert.ToInt32(objEmpDetails.emp_no);
                        employee emp = new employee();
                        emp = context.employees.Where(x => x.emp_id == empid).FirstOrDefault();
                        if (emp != null)
                        {
                            #region "Employee Details"
                           
                            emp.emp_id = Convert.ToInt32(objEmpDetails.emp_no);
                            emp.first_name = objEmpDetails.first_name;
                            emp.last_name = objEmpDetails.last_name;
                            emp.gender = objEmpDetails.gender;
                            emp.dob = Convert.ToDateTime(objEmpDetails.dob);
                            emp.pan_num = objEmpDetails.pan_num;
                            emp.aadhaar_num = objEmpDetails.aadhaar_num;
                            emp.mobile_num = objEmpDetails.mobile_num;
                            emp.email_id = objEmpDetails.email_id;
                            emp.office_mail = string.IsNullOrEmpty(objEmpDetails.office_mail) ? "" : objEmpDetails.office_mail;
                            emp.permanent_address = objEmpDetails.permanent_address;
                            emp.present_address = objEmpDetails.present_address;
                            emp.blood_group = objEmpDetails.blood_group;
                            emp.profile_pict = string.IsNullOrEmpty(objEmpDetails.profile_pict) ? "" : objEmpDetails.profile_pict;
                            emp.doj = Convert.ToDateTime(objEmpDetails.doj);
                            emp.emp_level = Convert.ToInt32(objEmpDetails.emp_level);
                            emp.post_name = objEmpDetails.post;
                            emp.basic_pay = Convert.ToInt32(objEmpDetails.basic_pay);
                            emp.house_allowance = Convert.ToInt32(objEmpDetails.house_allowance);
                            context.Entry(emp).State = EntityState.Modified;
                            context.SaveChanges();

                            transaction.Commit();
                        }
                        return true;
                        #endregion
                    }
                    catch (DbEntityValidationException e)
                    {
                        log.Error(e.Message.ToString());
                        throw;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        log.Error(ex.Message.ToString());
                        return false;
                    }
                }
            }

        }

        public bool CheckMailExistAlready(string email_id)
        {
            try
            {
                using (EmployeePortal_GaneshEntities context = new EmployeePortal_GaneshEntities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        // Check if any users match this e-mail address
                        bool isExist = context.employees.Where(u => u.email_id.ToLower().Equals(email_id.ToLower()) || u.office_mail.ToLower().Equals(email_id.ToLower())).FirstOrDefault() != null;
                        return isExist;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
            finally
            { 
            
            }
        }

        public bool CheckEmpIdExistAlready(int emp_no)
        {
            try
            {
                using (EmployeePortal_GaneshEntities context = new EmployeePortal_GaneshEntities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        // Check if EmpNo# is already exist or not in database
                        bool isExist = context.employees.Where(u => u.emp_id.Equals(emp_no)).FirstOrDefault() != null;
                        return isExist;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
            finally
            {

            }
        }

        public List<EmployeeDetails> GetEmployeList()
        {
            try
            {
                using (EmployeePortal_GaneshEntities context = new EmployeePortal_GaneshEntities())
                {

                    List<EmployeeDetails> lstresult = (from s in context.employees
                                                       orderby s.first_name,s.emp_id ascending
                                                 select new EmployeeDetails
                                                 {
                                                     emp_no = s.emp_id.ToString(),
                                                     emp_name = s.first_name + " " + s.last_name,
                                                     first_name = s.first_name.Trim(),
                                                     last_name = s.last_name.Trim(),
                                                     mobile_num = s.mobile_num,
                                                     email_id = s.email_id,
                                                     emp_level = s.emp_level.ToString(),
                                                     post = s.post_name

                                                 }).ToList();
                        return lstresult;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
        }

        public List<EmployeeDetails> GetEmployeeListBySearch(string emp_no, string emp_name, string gender)
        {
            int emp_id = Convert.ToInt32(string.IsNullOrEmpty(emp_no) ? "0" : emp_no );
            List<EmployeeDetails> lstresult = new List<EmployeeDetails>();
            try
            {
                using (EmployeePortal_GaneshEntities context = new EmployeePortal_GaneshEntities())
                {
                    if (emp_id > 0)
                    {
                        lstresult = (from s in context.employees
                                     where s.emp_id == emp_id
                                     orderby s.first_name, s.emp_id ascending
                                     select new EmployeeDetails
                                     {
                                         emp_no = s.emp_id.ToString(),
                                         emp_name = s.first_name + " " + s.last_name,
                                         first_name = s.first_name.Trim(),
                                         last_name = s.last_name.Trim(),
                                         mobile_num = s.mobile_num,
                                         email_id = s.email_id,
                                         emp_level = s.emp_level.ToString(),
                                         post = s.post_name

                                     }).ToList();
                    }
                    else {

                        lstresult = (from s in context.employees
                                     where s.gender == gender.Trim() && (s.first_name.Contains(emp_name) || s.last_name.Contains(emp_name))
                                     orderby s.first_name, s.emp_id ascending
                                     select new EmployeeDetails
                                     {
                                         emp_no = s.emp_id.ToString(),
                                         emp_name = s.first_name + " " + s.last_name,
                                         first_name = s.first_name.Trim(),
                                         last_name = s.last_name.Trim(),
                                         mobile_num = s.mobile_num,
                                         email_id = s.email_id,
                                         emp_level = s.emp_level.ToString(),
                                         post = s.post_name

                                     }).ToList();
                    }
                    return lstresult;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
        }

        public EmployeeDetails GetEmployeeDetailsById(string id)
        {
            int emp_no = Convert.ToInt32(id);
            try
            {
                using (EmployeePortal_GaneshEntities context = new EmployeePortal_GaneshEntities())
                {

                    EmployeeDetails empresult = (from s in context.employees
                                                 where s.emp_id == emp_no
                                                 select new EmployeeDetails
                                                 {
                                                    emp_no = s.emp_id.ToString().Trim(),
                                                    first_name = s.first_name.Trim(),
                                                    last_name = s.last_name.Trim(),
                                                    gender = s.gender.Trim(),
                                                     dt_dob = s.dob,
                                                     pan_num = string.IsNullOrEmpty(s.pan_num) ? "" : s.pan_num.Trim(),
                                                     aadhaar_num = string.IsNullOrEmpty(s.aadhaar_num) ? "" : s.aadhaar_num.Trim(),
                                                     mobile_num = s.mobile_num.Trim(),
                                                     email_id = s.email_id.Trim(),
                                                     office_mail = s.office_mail.Trim(),
                                                     permanent_address = s.permanent_address,
                                                     present_address = s.present_address,
                                                     blood_group = s.blood_group.Trim(),
                                                     profile_pict = s.profile_pict.Trim(),
                                                     dt_doj = s.doj,
                                                     emp_level = s.emp_level.ToString().Trim(),
                                                     post = s.post_name.Trim(),
                                                     basic_pay = s.basic_pay.ToString().Trim(),
                                                     house_allowance = s.house_allowance.ToString().Trim()
                                                 }).FirstOrDefault();
                    empresult.dob = empresult.dt_dob.ToString("dd/MM/yyyy");
                    empresult.doj = empresult.dt_doj.ToString("dd/MM/yyyy");
                    return empresult;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
        }

        public bool DeleteEmployeeDetailsById(string id)
        {
            int emp_no = Convert.ToInt32(id);
            using (EmployeePortal_GaneshEntities context = new EmployeePortal_GaneshEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        employee emp = context.employees.Where(x => x.emp_id == emp_no).FirstOrDefault();
                        var emp_history = context.employment_history.Where(x => x.emp_id == emp_no);

                        context.employment_history.RemoveRange(emp_history);
                        context.employees.Remove(emp);
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        log.Error(ex.Message.ToString());
                        return false;
                        throw ex;
                    }
                }
            }
        }

        public List<EmployeeDetails> GetExportEmpListBySearch(string emp_no, string emp_name, string gender)
        {
            int emp_id = Convert.ToInt32(string.IsNullOrEmpty(emp_no) ? "0" : emp_no);
            List<EmployeeDetails> lstresult = new List<EmployeeDetails>();
            try
            {
                using (EmployeePortal_GaneshEntities context = new EmployeePortal_GaneshEntities())
                {
                    if (emp_id > 0)
                    {
                        lstresult = (from s in context.employees
                                     where s.emp_id == emp_id
                                     orderby s.first_name, s.emp_id ascending
                                     select new EmployeeDetails
                                     {
                                         emp_no = s.emp_id.ToString().Trim(),
                                         emp_name = s.first_name.ToString().Trim() + " " + s.last_name.ToString().Trim(),
                                         first_name = s.first_name.Trim().ToString().Trim(),
                                         last_name = s.last_name.Trim().ToString().Trim(),
                                         dt_doj = s.doj,
                                         post = s.post_name.ToString().Trim(),
                                         emp_level = s.emp_level.ToString(),
                                         mobile_num = s.mobile_num,
                                         email_id = s.email_id.ToString().Trim(),
                                         office_mail = s.office_mail.ToString().Trim(),
                                         dt_dob = s.dob,
                                         blood_group = s.blood_group.ToString().Trim(),
                                         pan_num = s.pan_num.ToString().Trim(),
                                         aadhaar_num = s.aadhaar_num.ToString().Trim()


                                     }).ToList();
                        for (int i = 0; i < lstresult.Count; i++)
                        {
                            lstresult[i].mobile_num = lstresult[i].mobile_num.Trim();
                            lstresult[i].dob = lstresult[i].dt_dob.ToString("dd/MM/yyyy");
                            lstresult[i].doj = lstresult[i].dt_doj.ToString("dd/MM/yyyy");
                        }
                    }
                    else if (!string.IsNullOrEmpty(emp_name) && !string.IsNullOrEmpty(gender))
                    {

                        lstresult = (from s in context.employees
                                     where s.gender == gender.Trim() && (s.first_name.Contains(emp_name) || s.last_name.Contains(emp_name))
                                     orderby s.first_name, s.emp_id ascending
                                     select new EmployeeDetails
                                     {
                                         emp_no = s.emp_id.ToString().Trim(),
                                         emp_name = s.first_name.ToString().Trim() + " " + s.last_name.ToString().Trim(),
                                         first_name = s.first_name.Trim().ToString().Trim(),
                                         last_name = s.last_name.Trim().ToString().Trim(),
                                         dt_doj = s.doj,
                                         post = s.post_name.ToString().Trim(),
                                         emp_level = s.emp_level.ToString(),
                                         mobile_num = s.mobile_num,
                                         email_id = s.email_id.ToString().Trim(),
                                         office_mail = s.office_mail.ToString().Trim(),
                                         dt_dob = s.dob,
                                         blood_group = s.blood_group.ToString().Trim(),
                                         pan_num = s.pan_num.ToString().Trim(),
                                         aadhaar_num = s.aadhaar_num.ToString().Trim()


                                     }).ToList();
                        for (int i = 0; i < lstresult.Count; i++)
                        {
                            lstresult[i].mobile_num = lstresult[i].mobile_num.Trim();
                            lstresult[i].dob = lstresult[i].dt_dob.ToString("dd/MM/yyyy");
                            lstresult[i].doj = lstresult[i].dt_doj.ToString("dd/MM/yyyy");
                        }
                    }
                    else
                    {
                        lstresult = (from s in context.employees
                                     orderby s.first_name, s.emp_id ascending
                                     select new EmployeeDetails
                                     {
                                         emp_no = s.emp_id.ToString().Trim(),
                                         emp_name = s.first_name.ToString().Trim() + " " + s.last_name.ToString().Trim(),
                                         first_name = s.first_name.Trim().ToString().Trim(),
                                         last_name = s.last_name.Trim().ToString().Trim(),
                                         dt_doj = s.doj,
                                         post = s.post_name.ToString().Trim(),
                                         emp_level = s.emp_level.ToString(),
                                         mobile_num = s.mobile_num,
                                         email_id = s.email_id.ToString().Trim(),
                                         office_mail = s.office_mail.ToString().Trim(),
                                         dt_dob = s.dob,
                                         blood_group = s.blood_group.ToString().Trim(),
                                         pan_num = s.pan_num.ToString().Trim(),
                                         aadhaar_num = s.aadhaar_num.ToString().Trim()


                                     }).ToList();
                        for (int i = 0; i < lstresult.Count; i++)
                        {
                            lstresult[i].mobile_num = lstresult[i].mobile_num.Trim();
                            lstresult[i].dob = lstresult[i].dt_dob.ToString("dd/MM/yyyy");
                            lstresult[i].doj = lstresult[i].dt_doj.ToString("dd/MM/yyyy");
                        }
                    }
                    return lstresult;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message.ToString());
                throw ex;
            }
        }
    }
}