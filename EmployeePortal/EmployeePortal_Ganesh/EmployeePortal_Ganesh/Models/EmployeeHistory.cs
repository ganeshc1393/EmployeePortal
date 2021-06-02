using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal_Ganesh.Models
{
    public class EmployeeHistory
    {

        public int emp_no { get; set; }
        public string organization_name { get; set; }
        public DateTime dtfrom_date { get; set; }
        public string from_date { get; set; }
        public DateTime dtuntil_date { get; set; }
        public string until_date { get; set; }
        public string location { get; set; }
        public string country { get; set; }
        public string post { get; set; }
        public string skill_used { get; set; }
        public string emp_name { get; set; }



        public List<EmployeeHistory> GetEmployeeHistoryDetailsById(string id)
        {

            int emp_no = Convert.ToInt32(id);
            try
            {
                using (EmployeePortal_GaneshEntities context = new EmployeePortal_GaneshEntities())
                {

                    List<EmployeeHistory> empresult = (from s in context.employment_history
                                                       where s.emp_id == emp_no
                                                       orderby s.until_date descending
                                                       select new EmployeeHistory
                                                       {
                                                           emp_no = s.emp_id,
                                                           organization_name = s.organization_name,
                                                           dtfrom_date = s.from_date,
                                                           dtuntil_date = s.until_date,
                                                           location = s.location,
                                                           country = s.country,
                                                           post = s.post,
                                                           skill_used = s.skill_used
                                                       }).ToList();
                    for (int i = 0; i < empresult.Count; i++)
                    {
                        empresult[i].from_date = empresult[i].dtfrom_date.ToString("MM/yyyy");
                        empresult[i].until_date = empresult[i].dtuntil_date.ToString("MM/yyyy");
                    }

                    return empresult;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}