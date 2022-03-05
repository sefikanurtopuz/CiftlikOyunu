using BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ciftlikoyunu
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        BLL.Models.Kullanici _kullanici = new BLL.Models.Kullanici();
        BLL.Models.inek _inek = new BLL.Models.inek();
        Anasayfa anasayfa = new Anasayfa();
        private void btn_giris_Click(object sender, EventArgs e)
        {
            DataTable result = null;
            _kullanici.kullanici_adi = txt_kullanici.Text;
            _kullanici.sifre = txt_sifre.Text;

            result = _kullanici.giris();

            if (result != null && result.Rows.Count == 1)
            {

                this.Hide();
                _kullanici.id=int.Parse(result.Rows[0]["id"].ToString());
                anasayfa._user = new Kullanici();
                anasayfa._user = _kullanici;
                anasayfa.Show();


            }
            else
            {
                DialogResult dresult = MessageBox.Show("Hatalı giriş denemesi! Tekrar denemek ister misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dresult.ToString() == "Yes")
                {
                    txt_kullanici.Text = "";
                    txt_sifre.Text = "";
                }
                else
                {
                    Application.Exit();
                }

            }

        }
    }
}
