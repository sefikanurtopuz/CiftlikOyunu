using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Kullanici
    {

        //properties
        public int id { get; set; }
        public string kullanici_adi { get; set; }
        public string sifre { get; set; }
        public string hatamesaji = "";



        //actions

        public DataTable giris()
        {
            DAL.Execute exec = new DAL.Execute();
            SQL.sql _sql = new SQL.sql();
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kullanici_adi", kullanici_adi));
            _params.Add(new SqlParameter("@sifre", sifre));
           

           return exec.executeDT(_sql.giris(), _params.ToArray(), false, ref hatamesaji);
           
        }
    }
}
