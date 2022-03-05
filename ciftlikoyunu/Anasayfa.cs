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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        BLL.Models.inek _inek = new BLL.Models.inek();
        Skor _skor = new Skor();
        
        int puan=0;

        public Kullanici _user;
        public async void btn_inekal_Click(object sender, EventArgs e)
        {

            lbl_ineksayac.Text = _inek.iSayac.ToString();
            
            await bekleAsync(_inek.iSayac, lbl_ineksayac,btn_inekal);
            _inek.inekEkle(_user.id);
            _skor.skorEkle(_user.id);
            lbl_ineksayi.Text = _inek.inekSayisi(_user.id).ToString();

            lbl_skorpuan.Text=_skor.skorSayisi(_user.id).ToString();
        }
        private async void btn_sutal_Click(object sender, EventArgs e)
        {
            if (int.Parse(lbl_ineksayi.Text)>=1)
            {
                lbl_sutsayac.Text = _inek.sSayac.ToString();
                await bekleAsync(_inek.sSayac, lbl_sutsayac,btn_sutal);

               _inek.sutEkle(_user.id);
                _skor.skorSutEkle(_user.id);
                lbl_litresayi.Text = _inek.sutSayisi(_user.id).ToString();
                lbl_skorpuan.Text = _skor.skorSayisi(_user.id).ToString();

            }
            else
            {
                DialogResult dresult = MessageBox.Show("İnek almadan süt alamazsınız!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            
        }
        // 1000 --> 1 saniye
        public int bekle()
        {
            int sure = 60000;
            System.Threading.Thread.Sleep(sure);
            return (sure / 1000);

        }

        public async Task<int> bekleAsync(int saniye, Label lblNesne,Button btn)
        {
            int sure = 1000;

            for (int i = saniye; i > 0; i--)
            {
                btn.Enabled = false;
                await Task.Run(() => System.Threading.Thread.Sleep(sure));
                int sayi = int.Parse(lblNesne.Text) - 1;
                lblNesne.Text = sayi.ToString();
                

            }

            btn.Enabled = true;
            return sure;

        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            //_kullanici.id = _k.id;
            _inek.skorTablo(_user.id);
            lbl_ineksayi.Text = _inek.inekSayisi(_user.id).ToString();
            lbl_skorpuan.Text = _skor.skorSayisi(_user.id).ToString();
        }
    }
}
