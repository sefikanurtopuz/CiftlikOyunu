using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SQL
{
    public class sql
    {

        public string giris()
        {
            return "select * from kullanici where kullanici_adi= @kullanici_adi and sifre=@sifre";
        }

        public string ekle()
        {
            return "insert into skor (kullanici_id,skor_puani,inek_sayisi,sut_litresi) values (@kullanici_id,0,0,0) ";
        }

        public string inekEkle()
        {
            return "update skor set inek_sayisi+= 1 where kullanici_id = @kullanici_id";
        }

        public string inekSayisi()
        {
            return "select inek_sayisi from skor where kullanici_id=@kullanici_id ";
        }
       
        public string ekleKontrol()
        {
            return "select count(*) as sayi from skor where kullanici_id=@kullanici_id";
        }

        public string skorEkle()
        {
            return "update skor set skor_puani+= 5 where kullanici_id = @kullanici_id";
        }

        public string skorSutEkle()
        {
            return "update skor set skor_puani+= 10 where kullanici_id = @kullanici_id";
        }
        public string skorSayisi()
        {
            return "select skor_puani from skor where kullanici_id=@kullanici_id ";
        }


        public string sutEkle()
        {
            return "update skor set sut_litresi+= 5 where kullanici_id = @kullanici_id";
        }

        public string sutSayisi()
        {
            return "select sut_litresi from skor where kullanici_id=@kullanici_id ";
        }

    }
}
