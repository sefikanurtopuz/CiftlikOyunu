using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class inek
    {
        public int id { get; set; }
        public int sut_litre { get; set; }
        public int sure { get; set; }

        public  int iSayac { get;}
        public  int sSayac { get; }
        string hatamesaji = "";

        DAL.Execute exec = new DAL.Execute();
        SQL.sql _sql = new SQL.sql();
     
        public inek()
        {
            iSayac = 60;
            sSayac = 30;
        }

        public void skorTablo(int id)
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kullanici_id", id));
            DataTable sonuc =exec.executeDT(_sql.ekleKontrol(), _params.ToArray(), false, ref hatamesaji);
            int sayi= int.Parse(sonuc.Rows[0]["sayi"].ToString());
            if(sayi==0)
            {
                _params.Clear();
                _params.Add(new SqlParameter("@kullanici_id", id));
                bool result =exec.execute(_sql.ekle(), _params.ToArray(), false, ref hatamesaji);
            }  
        }
      

        public bool inekEkle(int id)
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kullanici_id", id));
             bool sonuc=exec.execute(_sql.inekEkle(), _params.ToArray(), false, ref hatamesaji);
            return sonuc;
        }

        public string inekSayisi(int id)
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kullanici_id", id));
           DataTable sonuc= exec.executeDT(_sql.inekSayisi(), _params.ToArray(), false, ref hatamesaji);
            return sonuc.Rows[0]["inek_sayisi"].ToString();
        }


        public bool sutEkle(int id)
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kullanici_id", id));
            bool sonuc = exec.execute(_sql.sutEkle(), _params.ToArray(), false, ref hatamesaji);
            return sonuc;
        }

        public string sutSayisi(int id)
        {
            List<SqlParameter> _params = new List<SqlParameter>();
            _params.Add(new SqlParameter("@kullanici_id", id));
            DataTable sonuc = exec.executeDT(_sql.sutSayisi(), _params.ToArray(), false, ref hatamesaji);
            return sonuc.Rows[0]["sut_litresi"].ToString();
        }
    }

}
