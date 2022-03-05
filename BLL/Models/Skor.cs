using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Skor
    {
        //properties

        public int Id { get; set; }
        public int skor_puani { get; set; }

        //actions
        string hatamesaji = "";
        DAL.Execute exec = new DAL.Execute();
        SQL.sql _sql = new SQL.sql();
        public bool skorEkle(int id)
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kullanici_id", id));
            bool sonuc = exec.execute(_sql.skorEkle(), _params.ToArray(), false, ref hatamesaji);
            return sonuc;
        }
        public bool skorSutEkle(int id)
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kullanici_id", id));
            bool sonuc = exec.execute(_sql.skorSutEkle(), _params.ToArray(), false, ref hatamesaji);
            return sonuc;
        }
        public string skorSayisi(int id)
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kullanici_id", id));
            DataTable sonuc = exec.executeDT(_sql.skorSayisi(), _params.ToArray(), false, ref hatamesaji);
            return sonuc.Rows[0]["skor_puani"].ToString();
        }


    }
}
