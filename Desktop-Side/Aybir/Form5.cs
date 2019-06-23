using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aybir
{
    public partial class Form5 : Form
    {
        string baglantiYolu = @"Data Source=localhost;Initial Catalog=Aybirveri;Integrated Security=True";
        

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        public int kisiyiAra()
        {
            string[] isim_parcalari = textBox1.Text.ToUpper().Split(' ');
            string[] soyad_parcalari = textBox2.Text.ToUpper().Split(' ');

            string isimm = isim_parcalari[0];
            string soyisimm = soyad_parcalari[0];

            for (int i = 1; i < isim_parcalari.Length; i++)
            {
                string parca_isim = isim_parcalari[i];
                if (parca_isim != "")
                {
                    if (isimm != "")
                        isimm = isimm + " " + parca_isim;
                    else
                        isimm = parca_isim;
                }
            }

            for (int j = 1; j < soyad_parcalari.Length; j++)
            {
                string parca_soyad = soyad_parcalari[j];
                if (parca_soyad != "")
                {
                    if (soyisimm != "")
                        soyisimm = soyisimm + " " + soyad_parcalari[j];
                    else
                        soyisimm = parca_soyad;
                }
            }

            int deger = -1;
            SqlConnection baglanti5 = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti5;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "select kisiID,Telefon from Kisiler where Ad=@pad and Soyad=@psoyad";
            komut.Parameters.AddWithValue("@pad", isimm);
            komut.Parameters.AddWithValue("@psoyad", soyisimm);
            baglanti5.Open();
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                deger = Convert.ToInt32(dr["kisiID"]);
                label19.Text = dr["Telefon"].ToString();
            }
            baglanti5.Close();
            return deger;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti4 = new SqlConnection(baglantiYolu);
            if (radioButton1.Checked == true)
            {
                
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti4;
                komut.CommandType = CommandType.Text;
                komut.CommandText = "select sum(eskipetek) as teskipetek, sum(alinantakoz) as talinantakoz, sum(yerinemum) as tyerinemum, sum(dusurulenfire) as tdusurulenfire, sum(satilanpetek) as tsatilanpetek, sum(oduncpetek) as toduncpetek, sum(odenentakoz) as todenentakoz, sum(odenenkarapetek) as todenenkarapetek, sum(alinanpara) as talinanpara  from kayitlar where tarih>=@pbaslangic and tarih<=@pbitis";
                komut.Parameters.AddWithValue("@pbaslangic", dateTimePicker1.Value.Date);
                komut.Parameters.AddWithValue("@pbitis", dateTimePicker2.Value.Date);
                baglanti4.Open();
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    label20.Text = dr["teskipetek"].ToString();
                    label21.Text = dr["talinantakoz"].ToString();
                    label22.Text = dr["tyerinemum"].ToString();
                    label23.Text = dr["tdusurulenfire"].ToString();
                    label24.Text = dr["tsatilanpetek"].ToString();
                    label25.Text = dr["toduncpetek"].ToString();
                    label26.Text = dr["todenentakoz"].ToString();
                    label27.Text = dr["todenenkarapetek"].ToString();
                    label28.Text = dr["talinanpara"].ToString();
                }
                baglanti4.Close();

                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                label17.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
                label25.Visible = true;
                label26.Visible = true;
                label27.Visible = true;
                label28.Visible = true;

            }
            else if (radioButton2.Checked == true)
            {
                int kisiid = kisiyiAra();

                if (kisiid == -1)
                {
                    MessageBox.Show("BU İSİM SİSTEMDE KAYITLI DEĞİL!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlCommand komut2 = new SqlCommand();
                    komut2.Connection = baglanti4;
                    komut2.CommandType = CommandType.Text;
                    komut2.CommandText = "select sum(eskipetek) as teskipetek, sum(alinantakoz) as talinantakoz, sum(yerinemum) as tyerinemum, sum(dusurulenfire) as tdusurulenfire, sum(satilanpetek) as tsatilanpetek, sum(oduncpetek) as toduncpetek, sum(odenentakoz) as todenentakoz, sum(odenenkarapetek) as todenenkarapetek, sum(alinanpara) as talinanpara  from kayitlar where tarih>=@pbaslangic and tarih<=@pbitis and kisiID=@pkisiid";
                    komut2.Parameters.AddWithValue("@pbaslangic", dateTimePicker1.Value.Date);
                    komut2.Parameters.AddWithValue("@pbitis", dateTimePicker2.Value.Date);
                    komut2.Parameters.AddWithValue("@pkisiid", kisiid);
                    baglanti4.Open();
                    SqlDataReader dr2 = komut2.ExecuteReader();

                    if (dr2.Read())
                    {
                        label20.Text = dr2["teskipetek"].ToString();
                        label21.Text = dr2["talinantakoz"].ToString();
                        label22.Text = dr2["tyerinemum"].ToString();
                        label23.Text = dr2["tdusurulenfire"].ToString();
                        label24.Text = dr2["tsatilanpetek"].ToString();
                        label25.Text = dr2["toduncpetek"].ToString();
                        label26.Text = dr2["todenentakoz"].ToString();
                        label27.Text = dr2["todenenkarapetek"].ToString();
                        label28.Text = dr2["talinanpara"].ToString();
                    }

                    if (dr2["teskipetek"] == DBNull.Value)
                        MessageBox.Show("BU TARİHLER ARASINDA SİSTEMDE YAZDIĞINIZ İSME AİT BİR KAYIT YOK!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        label18.Text = textBox1.Text.ToUpper() + " " + textBox2.Text.ToUpper();
                        label7.Visible = true;
                        label8.Visible = true;
                        label9.Visible = true;
                        label10.Visible = true;
                        label11.Visible = true;
                        label12.Visible = true;
                        label13.Visible = true;
                        label14.Visible = true;
                        label15.Visible = true;
                        label16.Visible = true;
                        label17.Visible = true;
                        label18.Visible = true;
                        label19.Visible = true;
                        label20.Visible = true;
                        label21.Visible = true;
                        label22.Visible = true;
                        label23.Visible = true;
                        label24.Visible = true;
                        label25.Visible = true;
                        label26.Visible = true;
                        label27.Visible = true;
                        label28.Visible = true;

                    }
                    baglanti4.Close();
                   
                    

                }

            }

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            label6.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            button2.Visible = true;
            label4.Visible = false;
            label5.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {

            label2.Visible = true;
            label3.Visible = true;
            label6.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            button2.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Close();
            
        }

        private void Form5_InputLanguageChanging(object sender, InputLanguageChangingEventArgs e)
        {

        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* DialogResult giriskapanis = MessageBox.Show("Programı kapatmak istediğinizden eminmisiniz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (giriskapanis == DialogResult.No)
            {
                e.Cancel = true;
                return;

            }
            Environment.Exit(0);*/
        }
    }
}
