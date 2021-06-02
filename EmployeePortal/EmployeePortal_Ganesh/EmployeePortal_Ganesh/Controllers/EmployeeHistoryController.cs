using EmployeePortal_Ganesh.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePortal_Ganesh.Controllers
{
    public class EmployeeHistoryController : Controller
    {
        ILog log = log4net.LogManager.GetLogger(typeof(EmployeeHistory));

        // GET: EmployeeHistory
        public ActionResult Index(string id, string emp_name)
        {
            EmployeeHistory objempresult = new EmployeeHistory();
            try
            {
                objempresult.emp_no = Convert.ToInt32(id);
                objempresult.emp_name = emp_name;

                return View(objempresult);
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                throw ex;
            }
        }

        public ActionResult GetEmployeeHistory(string emp_no)
        {
            EmployeeHistory objEmployeeHistory = new EmployeeHistory();
            try
            {
                var lstemp = objEmployeeHistory.GetEmployeeHistoryDetailsById(emp_no);
                return Json(lstemp);
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                throw ex;
            }
        }
    }
}