using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;
//using EDMx;
using ClassLibrary1;
using API.Models;


namespace API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Departments> Get()
        {
            Database db = new Database();
            var cmd = new OracleCommand();
            cmd.CommandText = "select KEY_GLOBAL_DEPT, global_dept_name from hart_global_depts";
            var set = Database.GetData(cmd, "dbdev1.hscnet.hsc.usf.edu", "1521", "DWTEST", "hart_global_depts", "ams9382q");

            

            List<Departments> departments = new List<Departments>();
            foreach (DataRow row in set.Tables[0].Rows)
            {
                departments.Add(new Departments() { KEY_GLOBAL_DEPT = Convert.ToInt32(row["KEY_GLOBAL_DEPT"]) , GLOBAL_DEPT_NAME = row["global_dept_name"].ToString() });

                //departments.Add(new Departments() { GLOBAL_DEPT_NAME = row["global_dept_name"].ToString() });
            }
               


            return  (departments);
        }

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
