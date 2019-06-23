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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        string baglantiYolu = @"Data Source=localhost;Initial Catalog=Aybirveri;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {

            double eskipetek = 0;
            double alinantakoz = 0;
            double verilenmum = 0;
            double dusurulenfire = 0;
            double satilanpetek = 0;
            double oduncverilenpetek = 0;
            double borctakoz = 0;
            double borckarapetek = 0;
            double alinanpara = 0;
            DateTime tarih = dateTimePicker1.Value.Date;
            string[] isim_parcalari = textBox1.Text.ToUpper().Split(' ');
            string[] soyad_parcalari = textBox12.Text.ToUpper().Split(' ');
            string ad = isim_parcalari[0];
            string soyad = soyad_parcalari[0];
            string telefon = textBox2.Text;

            for (int i = 1; i < isim_parcalari.Length; i++)
            {   
                string parca_isim = isim_parcalari[i];
                if (parca_isim != "")
                {
                    if (ad != "")
                        ad = ad + " " + parca_isim;
                    else
                        ad = parca_isim;
                }
            }

            for (int j = 1; j < soyad_parcalari.Length; j++)
            {
                string parca_soyad = soyad_parcalari[j];
                if (parca_soyad != "")
                {
                    if (soyad != "")
                        soyad = soyad + " " + soyad_parcalari[j];
                    else
                        soyad = parca_soyad;
                }
            }

            if (textBox3.Text != "")
                eskipetek = Convert.ToDouble(textBox3.Text);
            if (textBox4.Text != "")
                alinantakoz = Convert.ToDouble(textBox4.Text);
            if (textBox5.Text != "")
                verilenmum = Convert.ToDouble(textBox5.Text);
            if (textBox6.Text != "")
                dusurulenfire = Convert.ToDouble(textBox6.Text);
            if (textBox7.Text != "")
                satilanpetek = Convert.ToDouble(textBox7.Text);
            if (textBox8.Text != "")
                oduncverilenpetek = Convert.ToDouble(textBox8.Text);
            if (textBox9.Text != "")
                borctakoz = Convert.ToDouble(textBox9.Text);
            if (textBox10.Text != "")
                borckarapetek  = Convert.ToDouble(textBox10.Text);
            if (textBox11.Text != "")
                alinanpara = Convert.ToDouble(textBox11.Text);

            if (ad == "" || soyad == "")
                MessageBox.Show("AD SOYAD BİLGİSİ GİRMEDEN KAYIT YAPAMAZSINIZ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else
            {
                SqlConnection baglanti = new SqlConnection(baglantiYolu);
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;
                komut.CommandText = "select kisiID from Kisiler where Ad=@pad and Soyad=@psoyad";
                komut.Parameters.AddWithValue("@pad", ad);
                komut.Parameters.AddWithValue("@psoyad", soyad);
                baglanti.Open();
                SqlDataReader dr = komut.ExecuteReader();
                
                int kisiid = 0;
                if (dr.Read())
                {
                   kisiid = Convert.ToInt32(dr["kisiID"]);
                   baglanti.Close();
                   if(telefon != "")
                   {
                      SqlCommand komut2 = new SqlCommand();
                      komut2.Connection = baglanti;
                      komut2.CommandType = CommandType.Text;
                      komut2.CommandText = "update Kisiler set Telefon=@ptelefon where kisiID=@pkisiid";
                      komut2.Parameters.AddWithValue("@ptelefon", telefon);
                      komut2.Parameters.AddWithValue("@pkisiid",kisiid);
                      baglanti.Open();
                      komut2.ExecuteNonQuery();
                      baglanti.Close();
                   }
                  
                }
                else
                {
                      baglanti.Close();
                      SqlCommand komut4 = new SqlCommand();
                      komut4.Connection = baglanti;
                      komut4.CommandType = CommandType.Text;
                      komut4.CommandText = "insert into Kisiler values(@pad,@psoyad,@ptelefon)";
                      komut4.Parameters.AddWithValue("@pad", ad);
                      komut4.Parameters.AddWithValue("@psoyad", soyad);
                      komut4.Parameters.AddWithValue("@ptelefon", telefon);
             
                      baglanti.Open();
                      komut4.ExecuteNonQuery();
                      baglanti.Close();

                     
                     // SqlConnection baglanti2 = new SqlConnection(baglantiYolu);
                      SqlCommand komut3 = new SqlCommand();
                      komut3.Connection = baglanti;
                      komut3.CommandType = CommandType.Text;
                      komut3.CommandText = "SELECT IDENT_CURRENT ('Kisiler') as sonid";
                      baglanti.Open();
                      SqlDataReader dr2 = komut3.ExecuteReader();
                     // kisiid = 1;
                      if (dr2.Read())
                      {
                         //if( dr2["sonid"] != DBNull.Value)
                              kisiid = Convert.ToInt32(dr2["sonid"]);

                      }
                      baglanti.Close();

                     

                }

               int gelenDeger = kayitAra(kisiid, tarih);
               if (gelenDeger == -1)
               {
                   SqlCommand komut5 = new SqlCommand();
                   komut5.Connection = baglanti;
                   komut5.CommandType = CommandType.Text;
                   baglanti.Open();
                   komut5.CommandText = "insert into kayitlar values(@pkisiID,@ptarih,@peskipetek,@palinantakoz,@pverilenmum,@pdusurulenfire,@psatilanpetek,@poduncverilenpetek,@pborctakoz,@pborckarapetek,@palinanpara)";
                   komut5.Parameters.AddWithValue("@pkisiID", kisiid);
                   komut5.Parameters.AddWithValue("@ptarih", tarih);
                   komut5.Parameters.AddWithValue("@peskipetek", eskipetek);
                   komut5.Parameters.AddWithValue("@palinantakoz", alinantakoz);
                   komut5.Parameters.AddWithValue("@pverilenmum", verilenmum);
                   komut5.Parameters.AddWithValue("@pdusurulenfire", dusurulenfire);
                   komut5.Parameters.AddWithValue("@psatilanpetek", satilanpetek);
                   komut5.Parameters.AddWithValue("@poduncverilenpetek", oduncverilenpetek);
                   komut5.Parameters.AddWithValue("@pborctakoz", borctakoz);
                   komut5.Parameters.AddWithValue("@pborckarapetek", borckarapetek);
                   komut5.Parameters.AddWithValue("@Palinanpara", alinanpara);

                   komut5.ExecuteNonQuery();
                   baglanti.Close();
               }
               else
               {
                   SqlConnection baglanti6 = new SqlConnection(baglantiYolu);
                   SqlCommand komut4 = new SqlCommand();
                   komut4.Connection = baglanti6;
                   komut4.CommandType = CommandType.Text;

                   komut4.CommandText = "update kayitlar set eskipetek = eskipetek + @psayi,alinantakoz = alinantakoz + @palinantakoz,yerinemum = yerinemum + @pyerinemum,dusurulenfire = dusurulenfire + @pdusurulenfire,satilanpetek = satilanpetek + @psatilanpetek,oduncpetek = oduncpetek + @poduncpetek,odenentakoz = odenentakoz + @podenentakoz,odenenkarapetek = odenenkarapetek + @podenenkarapetek,alinanpara = alinanpara + @palinanpara where kayitID=@pid";

                  
                   komut4.Parameters.AddWithValue("@psayi", eskipetek);
                   komut4.Parameters.AddWithValue("@palinantakoz", alinantakoz);
                   komut4.Parameters.AddWithValue("@pyerinemum", verilenmum);
                   komut4.Parameters.AddWithValue("@pdusurulenfire", dusurulenfire);
                   komut4.Parameters.AddWithValue("@psatilanpetek", satilanpetek);
                   komut4.Parameters.AddWithValue("@poduncpetek", oduncverilenpetek);
                   komut4.Parameters.AddWithValue("@podenentakoz", borctakoz);
                   komut4.Parameters.AddWithValue("@podenenkarapetek", borckarapetek);
                   komut4.Parameters.AddWithValue("@palinanpara", alinanpara);
                   komut4.Parameters.AddWithValue("@pid",gelenDeger);


                   baglanti6.Open();
                   komut4.ExecuteNonQuery();
                   baglanti6.Close();
               }
                MessageBox.Show("KAYIT EKLENDİ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
            }
            
        }

        public int kayitAra(int kisiidsi ,DateTime tarih)
        {
            int deger = -1;
            SqlConnection baglantim = new SqlConnection(baglantiYolu);
            SqlCommand aramakomut = new SqlCommand();
            aramakomut.Connection = baglantim;
            aramakomut.CommandType = CommandType.Text;
            aramakomut.CommandText = "select kayitID from kayitlar where kisiID=@pkisiid and tarih=@ptarih";
            aramakomut.Parameters.AddWithValue("@pkisiid", kisiidsi);
            aramakomut.Parameters.AddWithValue("@ptarih", tarih);
            baglantim.Open();
            SqlDataReader veri = aramakomut.ExecuteReader();
            if (veri.Read())
            {
                deger = Convert.ToInt32(veri["kayitID"]);
            }

            baglantim.Close();

            return deger;

        }


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Close();
           
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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
