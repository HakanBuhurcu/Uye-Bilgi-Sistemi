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
    public partial class Form4 : Form
    {
        string baglantiYolu = @"Data Source=localhost;Initial Catalog=Aybirveri;Integrated Security=True";
        
        public Form4()
        {
            InitializeComponent();
        }

        
        
        

        DateTime tarih,yenitarih;
        string ad,yeniad;
        string soyad, yenisoyad;
        string telefon,yenitelefon;
        double sayi,yenisayi;
        double alinantakoz,yenialinantakoz;
        double yerinemum,yeniyerinemum;
        double dusurulenfire,yenidusurulenfire;
        double satilanpetek,yenisatilanpetek;
        double oduncpetek,yenioduncpetek;
        double odenentakoz,yeniodenentakoz;
        double odenenkarapetek,yeniodenenkarapetek;
        double alinanpara,yenialinanpara;
        int degisken = 1;
        bool isimDegistiMi = false;
        bool numaraDegistiMi = false;

        
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        public int kisiAra()
        {
            int deger = -1;
            SqlConnection baglanti4 = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti4;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "select kisiID from Kisiler where Ad=@pad and Soyad=@psoyad";
            komut.Parameters.AddWithValue("@pad", yeniad);
            komut.Parameters.AddWithValue("@psoyad", yenisoyad);
            baglanti4.Open();
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                deger = Convert.ToInt32(dr["kisiID"]);
            }
            baglanti4.Close();
            return deger;
        }
        public int kayitAra(int kisiidsi)
        {
            int deger = -1;
            SqlConnection baglantim = new SqlConnection(baglantiYolu);
            SqlCommand aramakomut = new SqlCommand();
            aramakomut.Connection = baglantim;
            aramakomut.CommandType = CommandType.Text;
            aramakomut.CommandText = "select kayitID from kayitlar where kisiID=@pkisiid and tarih=@ptarih";
            aramakomut.Parameters.AddWithValue("@pkisiid", kisiidsi);
            aramakomut.Parameters.AddWithValue("@ptarih", yenitarih);
            baglantim.Open();
            SqlDataReader veri = aramakomut.ExecuteReader();
            if (veri.Read())
            {
                deger = Convert.ToInt32(veri["kayitID"]);
            }

            baglantim.Close();

            return deger;

        }
        public void KisiGuncelle(int sahisid)
        {
            SqlConnection baglanti5 = new SqlConnection(baglantiYolu);
            SqlCommand komut2 = new SqlCommand();
            komut2.Connection = baglanti5;
            komut2.CommandType = CommandType.Text;
            komut2.CommandText = "update Kisiler set Ad=@pad,Soyad=@psoyad where kisiID=@pkisiid";
            komut2.Parameters.AddWithValue("@pad",yeniad);
            komut2.Parameters.AddWithValue("@psoyad",yenisoyad);
            komut2.Parameters.AddWithValue("@pkisiid", sahisid);

            baglanti5.Open();
            komut2.ExecuteNonQuery();
            baglanti5.Close();
        }
        public void TelefonGuncelle(int id)
        {
            SqlConnection baglanti6 = new SqlConnection(baglantiYolu);
            SqlCommand komut3 = new SqlCommand();
            komut3.Connection = baglanti6;
            komut3.CommandType = CommandType.Text;
            komut3.CommandText = "update Kisiler set Telefon=@ptelefon where kisiID=@pkisiid";
            komut3.Parameters.AddWithValue("@ptelefon", textBox2.Text);
            komut3.Parameters.AddWithValue("@pkisiid", id);

            baglanti6.Open();
            komut3.ExecuteNonQuery();
            baglanti6.Close();

        }
        public void KayitlariIdsizGuncelle(int kayitid)
        {
            SqlConnection baglanti2 = new SqlConnection(baglantiYolu);
            SqlCommand komut2 = new SqlCommand();
            komut2.Connection = baglanti2;
            komut2.CommandType = CommandType.Text;
            int id1 = Form3.kayitid;
            komut2.CommandText = "update kayitlar set tarih=@ptarih,eskipetek=@psayi,alinantakoz=@palinantakoz,yerinemum=@pyerinemum,dusurulenfire=@pdusurulenfire,satilanpetek=@psatilanpetek,oduncpetek=@poduncpetek,odenentakoz=@podenentakoz,odenenkarapetek=@podenenkarapetek,alinanpara=@palinanpara where kayitID=@pid";

            komut2.Parameters.AddWithValue("@ptarih", yenitarih);
            komut2.Parameters.AddWithValue("@psayi", yenisayi);
            komut2.Parameters.AddWithValue("@palinantakoz", yenialinantakoz);
            komut2.Parameters.AddWithValue("@pyerinemum", yeniyerinemum);
            komut2.Parameters.AddWithValue("@pdusurulenfire", yenidusurulenfire);
            komut2.Parameters.AddWithValue("@psatilanpetek", yenisatilanpetek);
            komut2.Parameters.AddWithValue("@poduncpetek", yenioduncpetek);
            komut2.Parameters.AddWithValue("@podenentakoz", yeniodenentakoz);
            komut2.Parameters.AddWithValue("@podenenkarapetek", yeniodenenkarapetek);
            komut2.Parameters.AddWithValue("@palinanpara", yenialinanpara);
            komut2.Parameters.AddWithValue("@pid", kayitid);


            baglanti2.Open();
            komut2.ExecuteNonQuery();
            baglanti2.Close();
        }
        public void OzelKaydiIdsizGuncelle(int kayitid,int kisiidm,string prmtre)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            
            if (tarih == yenitarih)
            {
                SqlCommand komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;   
                komut.CommandText = "update kayitlar set " + prmtre + " = @psayi where kayitID=@pid";
                komut.Parameters.AddWithValue("@psayi", yenisayi);
                komut.Parameters.AddWithValue("@pid", kayitid);


                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                SqlCommand sifirlaKomut = new SqlCommand();
                sifirlaKomut.Connection = baglanti;
                sifirlaKomut.CommandType = CommandType.Text;
                sifirlaKomut.CommandText = "update kayitlar set " + prmtre + "=0 where kayitID=@pkayitid";
                sifirlaKomut.Parameters.AddWithValue("@pkayitid", kayitid);
                baglanti.Open();
                sifirlaKomut.ExecuteNonQuery();
                baglanti.Close();

                int gelenKayitID = kayitAra(kisiidm);
                if (gelenKayitID == -1)
                {
                    SqlCommand ekleKomut = new SqlCommand();
                    ekleKomut.Connection = baglanti;
                    ekleKomut.CommandType = CommandType.Text;
                    ekleKomut.CommandText = "insert into kayitlar (kisiID,tarih," + prmtre + ") values(@pkisiid,@ptarih,@psayi)";
                    ekleKomut.Parameters.AddWithValue("@pkisiid", kisiidm);
                    ekleKomut.Parameters.AddWithValue("@ptarih", yenitarih);
                    ekleKomut.Parameters.AddWithValue("@psayi", yenisayi);
                    baglanti.Open();
                    ekleKomut.ExecuteNonQuery();
                    baglanti.Close();

                   
                }
                else
                {
                    SqlCommand arttirKomut = new SqlCommand();
                    arttirKomut.Connection = baglanti;
                    arttirKomut.CommandType = CommandType.Text;
                    arttirKomut.CommandText = "update kayitlar set " + prmtre + "=" + prmtre + "+@psayi where kayitID=@pkayitid";
                    arttirKomut.Parameters.AddWithValue("@psayi", yenisayi);
                    arttirKomut.Parameters.AddWithValue("@pkayitid", gelenKayitID);
                    baglanti.Open();
                    arttirKomut.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox12.Text == "")
            {
                MessageBox.Show("AD SOYAD ALANINI BOŞ BIRAKAMAZSIN!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
               // degisken = 1;

                if (textBox3.Text == "")
                    yenisayi = 0;
                else
                    yenisayi = Convert.ToDouble(textBox3.Text);
                
                yenitarih = dateTimePicker1.Value.Date;
                string[] isim_parcalari = textBox1.Text.ToUpper().Split(' ');
                string[] soyad_parcalari = textBox12.Text.ToUpper().Split(' ');
             
                yeniad = isim_parcalari[0];
                yenisoyad = soyad_parcalari[0];
                yenitelefon = textBox2.Text;

                for (int i = 1; i < isim_parcalari.Length; i++)
                {
                    string parca_isim = isim_parcalari[i];
                    if (parca_isim != "")
                    {
                        if (yeniad != "")
                            yeniad = yeniad + " " + parca_isim;
                        else
                            yeniad = parca_isim;
                    }
                }

                for (int j = 1; j < soyad_parcalari.Length; j++)
                {
                    string parca_soyad = soyad_parcalari[j];
                    if (parca_soyad != "")
                    {
                        if (yenisoyad != "")
                            yenisoyad = yenisoyad + " " + soyad_parcalari[j];
                        else
                            yenisoyad = parca_soyad;
                    }
                }



                if (tarih == yenitarih && ad==yeniad && soyad==yenisoyad && telefon == yenitelefon && sayi == yenisayi)
                {
                    MessageBox.Show("HİÇBİR DEĞİŞİKLİK YAPMADINIZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


                else
                {

                    int gelenid = 0;
                    int kisiid = Form3.kisiID;
                    int id1 = Form3.kayitid;
                    string prmtre = Form3.veri;
                    if (isimDegistiMi)
                    {
                        gelenid = kisiAra();
                        if (gelenid == -1)
                        {
                            KisiGuncelle(kisiid);
                            OzelKaydiIdsizGuncelle(id1,kisiid,prmtre);
                           // MessageBox.Show("İF (GELENID == -1) BLOĞUNA GİRDİ,İSİM DEGİŞTİ BU AD KİŞİLERDE YOK KİŞİNİN ADI VE KAYIT GÜNCELLENDİ");
                        }
                        else
                        {
                            SqlConnection baglanti = new SqlConnection(baglantiYolu);
                            SqlCommand sifirlaKomut = new SqlCommand();
                            sifirlaKomut.Connection = baglanti;
                            sifirlaKomut.CommandType = CommandType.Text;
                            sifirlaKomut.CommandText = "update kayitlar set " + prmtre + "=0 where kayitID=@pkayitid";
                            sifirlaKomut.Parameters.AddWithValue("@pkayitid", id1);
                            baglanti.Open();
                            sifirlaKomut.ExecuteNonQuery();
                            baglanti.Close();

                            int gelenKayitID = kayitAra(gelenid);
                            if (gelenKayitID == -1)
                            {
                                SqlCommand ekleKomut = new SqlCommand();
                                ekleKomut.Connection = baglanti;
                                ekleKomut.CommandType = CommandType.Text;
                                ekleKomut.CommandText = "insert into kayitlar (kisiID,tarih," + prmtre + ") values(@pkisiid,@ptarih,@psayi)";
                                ekleKomut.Parameters.AddWithValue("@pkisiid", gelenid);
                                ekleKomut.Parameters.AddWithValue("@ptarih", yenitarih);
                                ekleKomut.Parameters.AddWithValue("@psayi", yenisayi);
                                baglanti.Open();
                                ekleKomut.ExecuteNonQuery();
                                baglanti.Close();


                            }
                            else
                            {
                                SqlCommand arttirKomut = new SqlCommand();
                                arttirKomut.Connection = baglanti;
                                arttirKomut.CommandType = CommandType.Text;
                                arttirKomut.CommandText = "update kayitlar set " + prmtre + "=" + prmtre + "+@psayi where kayitID=@pkayitid";
                                arttirKomut.Parameters.AddWithValue("@psayi", yenisayi);
                                arttirKomut.Parameters.AddWithValue("@pkayitid", gelenKayitID);
                                baglanti.Open();
                                arttirKomut.ExecuteNonQuery();
                                baglanti.Close();
                            }
                            numaraDegistiMi = true;
                            //MessageBox.Show("İSİM DEGİŞTİ KİSİLERDE BULUNDU NDEGSİTMİ TRUE YAPILDI .KİSİİD VE KAYIT GÜNCELLENDİ");
                        }
                        
                    }
                    else
                    {
                        OzelKaydiIdsizGuncelle(id1,kisiid,prmtre);
                      //  MessageBox.Show("İSİM DEĞİŞMEDİĞİ İÇİN SADECE KAYDI GÜNCELLEDİ");
                    }
                   


                    if (numaraDegistiMi)
                    {
                        if (isimDegistiMi && gelenid != -1)
                        {
                            TelefonGuncelle(gelenid);
                          //  MessageBox.Show("numaraDegistiMi=TRUE İSİM DEĞİŞMİŞ VE KİSİİD = GELENİD OLMUŞ GELENİDNİN TELİ GÜNCELLENDİ");
                        }
                        else
                        {
                            TelefonGuncelle(kisiid);
                          //  MessageBox.Show("KİSİİDNİN TELİ GÜNCELLENDİ");
                        }

                        numaraDegistiMi = false;
                    }

                    isimDegistiMi = false;

                    Temizleme();

                    MessageBox.Show("KAYIT DEĞİŞTİRİLDİ", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Form3 frm3 = new Form3();
                    DateTime baslangic = Form3.baslangic;
                    DateTime bitis = Form3.bitis;
                    DataSet kayitlar1 = frm3.Listele(baslangic, bitis, prmtre);
                    frm3.dataGridView1.DataSource = kayitlar1.Tables[0];
                    frm3.dateTimePicker1.Value = baslangic;
                    frm3.dateTimePicker2.Value = bitis;
                    int kontroldegeri = Form3.deger;

                    if (kontroldegeri == 6)
                    {
                        frm3.dataGridView1.Columns[6].Visible = true;
                        frm3.radioButton1.Checked = true;
                    }
                    else if (kontroldegeri == 7)
                    {
                        frm3.dataGridView1.Columns[7].Visible = true;
                        frm3.radioButton2.Checked = true;
                    }
                    else if (kontroldegeri == 8)
                    {
                        frm3.dataGridView1.Columns[8].Visible = true;
                        frm3.radioButton3.Checked = true;
                    }
                    else if (kontroldegeri == 9)
                    {
                        frm3.dataGridView1.Columns[9].Visible = true;
                        frm3.radioButton4.Checked = true;
                    }
                    else if (kontroldegeri == 10)
                    {
                        frm3.dataGridView1.Columns[10].Visible = true;
                        frm3.radioButton5.Checked = true;
                    }
                    else if (kontroldegeri == 11)
                    {
                        frm3.dataGridView1.Columns[11].Visible = true;
                        frm3.radioButton6.Checked = true;
                    }
                    else if (kontroldegeri == 12)
                    {
                        frm3.dataGridView1.Columns[12].Visible = true;
                        frm3.radioButton7.Checked = true;
                    }
                    else if (kontroldegeri == 13)
                    {
                        frm3.dataGridView1.Columns[13].Visible = true;
                        frm3.radioButton8.Checked = true;
                    }
                    else if (kontroldegeri == 14)
                    {
                        frm3.dataGridView1.Columns[14].Visible = true;
                        frm3.radioButton9.Checked = true;
                    }
                   frm3.dataGridView1.Visible = true;
                   frm3.label5.Visible = true;
                   frm3.Show();
                   this.Close();
                    /*sayi = yenisayi;
                    tarih = yenitarih;
                    ad = yeniad;
                    soyad = yenisoyad;
                    telefon = yenitelefon;*/

                    
                }

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tarih = dateTimePicker1.Value.Date;
            ad = textBox1.Text;
            soyad = textBox12.Text;
            telefon = textBox2.Text;
            sayi = Convert.ToDouble(textBox3.Text);
            alinantakoz = Convert.ToDouble(textBox4.Text);
            yerinemum = Convert.ToDouble(textBox5.Text);
            dusurulenfire = Convert.ToDouble(textBox6.Text);
            satilanpetek = Convert.ToDouble(textBox7.Text);
            oduncpetek = Convert.ToDouble(textBox8.Text);
            odenentakoz = Convert.ToDouble(textBox9.Text);
            odenenkarapetek = Convert.ToDouble(textBox10.Text);
            alinanpara = Convert.ToDouble(textBox11.Text);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            if (degisken == 0)
            {
                yenitarih = dateTimePicker1.Value.Date;
                yeniad = textBox1.Text;
                yenisoyad = textBox12.Text;
                yenitelefon = textBox2.Text;

                if (textBox3.Text == "")
                    yenisayi = 0;
                else
                    yenisayi = Convert.ToDouble(textBox3.Text);

                if (textBox4.Text == "")
                    yenialinantakoz = 0;
                else
                    yenialinantakoz = Convert.ToDouble(textBox4.Text);

                if (textBox5.Text == "")
                    yeniyerinemum = 0;
                else
                    yeniyerinemum = Convert.ToDouble(textBox5.Text);

                if (textBox6.Text == "")
                    yenidusurulenfire = 0;
                else
                    yenidusurulenfire = Convert.ToDouble(textBox6.Text);

                if (textBox7.Text == "")
                    yenisatilanpetek = 0;
                else
                    yenisatilanpetek = Convert.ToDouble(textBox7.Text);

                if (textBox8.Text == "")
                    yenioduncpetek = 0;
                else
                    yenioduncpetek = Convert.ToDouble(textBox8.Text);

                if (textBox9.Text == "")
                    yeniodenentakoz = 0;
                else
                    yeniodenentakoz = Convert.ToDouble(textBox9.Text);

                if (textBox10.Text == "")
                    yeniodenenkarapetek = 0;
                else
                    yeniodenenkarapetek = Convert.ToDouble(textBox10.Text);

                if (textBox11.Text == "")
                    yenialinanpara = 0;
                else
                    yenialinanpara = Convert.ToDouble(textBox11.Text);
                

                if (tarih == yenitarih && ad == yeniad && soyad == yenisoyad && telefon == yenitelefon && sayi == yenisayi && alinantakoz == yenialinantakoz && yerinemum == yeniyerinemum && dusurulenfire == yenidusurulenfire && satilanpetek == yenisatilanpetek && oduncpetek == yenioduncpetek && odenentakoz == yeniodenentakoz && odenenkarapetek == yeniodenenkarapetek && alinanpara == yenialinanpara)
                {
                    frm3.Show();
                    this.Close();
                }
                else
                {
                    DialogResult cevap = MessageBox.Show("YAPTIĞINIZ DEĞİŞİKLERİ KAYDETMEDİNİZ.KAYDETMEDEN ÇIKMAK İSTER MİSİNİZ?","UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (DialogResult.Yes == cevap)
                    {
                        frm3.Show();
                        this.Close();
                    }
                 
                }
            }
            else if (degisken == 1)
            {
                frm3.Show();
                this.Close();
             //   MessageBox.Show("degisiklik yok");
            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox12.Text ==  "")
                MessageBox.Show("AD SOYAD ALANINI BOŞ BIRAKAMAZSINIZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                degisken = 1;

                yenitarih = dateTimePicker1.Value.Date;
                string[] isim_parcalari = textBox1.Text.ToUpper().Split(' ');
                string[] soyad_parcalari = textBox12.Text.ToUpper().Split(' ');

                yeniad = isim_parcalari[0];
                yenisoyad = soyad_parcalari[0];
                yenitelefon = textBox2.Text;

                for (int i = 1; i < isim_parcalari.Length; i++)
                {
                    string parca_isim = isim_parcalari[i];
                    if (parca_isim != "")
                    {
                        if (yeniad != "")
                            yeniad = yeniad + " " + parca_isim;
                        else
                            yeniad = parca_isim;
                    }
                }

                for (int j = 1; j < soyad_parcalari.Length; j++)
                {
                    string parca_soyad = soyad_parcalari[j];
                    if (parca_soyad != "")
                    {
                        if (parca_soyad != "")
                        {
                            if (yenisoyad != "")
                                yenisoyad = yenisoyad + " " + soyad_parcalari[j];
                            else
                                yenisoyad = parca_soyad;
                        }
                    }
                }


                if (textBox3.Text == "")
                    yenisayi = 0;
                else
                    yenisayi = Convert.ToDouble(textBox3.Text);

                if (textBox4.Text == "")
                    yenialinantakoz = 0;
                else
                    yenialinantakoz = Convert.ToDouble(textBox4.Text);

                if (textBox5.Text == "")
                    yeniyerinemum = 0;
                else
                    yeniyerinemum = Convert.ToDouble(textBox5.Text);

                if (textBox6.Text == "")
                    yenidusurulenfire = 0;
                else
                    yenidusurulenfire = Convert.ToDouble(textBox6.Text);

                if (textBox7.Text == "")
                    yenisatilanpetek = 0;
                else
                    yenisatilanpetek = Convert.ToDouble(textBox7.Text);

                if (textBox8.Text == "")
                    yenioduncpetek = 0;
                else
                    yenioduncpetek = Convert.ToDouble(textBox8.Text);

                if (textBox9.Text == "")
                    yeniodenentakoz = 0;
                else
                    yeniodenentakoz = Convert.ToDouble(textBox9.Text);

                if (textBox10.Text == "")
                    yeniodenenkarapetek = 0;
                else
                    yeniodenenkarapetek = Convert.ToDouble(textBox10.Text);

                if (textBox11.Text == "")
                    yenialinanpara = 0;
                else
                    yenialinanpara = Convert.ToDouble(textBox11.Text);
                
                
               
                if (tarih == yenitarih && ad == yeniad && soyad == yenisoyad && telefon == yenitelefon && sayi == yenisayi && alinantakoz == yenialinantakoz && yerinemum == yeniyerinemum && dusurulenfire == yenidusurulenfire && satilanpetek == yenisatilanpetek && oduncpetek == yenioduncpetek && odenentakoz == yeniodenentakoz && odenenkarapetek == yeniodenenkarapetek && alinanpara == yenialinanpara)
                {
                    MessageBox.Show("HİÇBİR DEĞİŞİKLİK YAPMADINIZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int gelenid = 0;
                    int kisiid = Form3.kisiID;
                    int id1 = Form3.kayitid;
                    if (isimDegistiMi)
                    {
                        gelenid = kisiAra();
                        if (gelenid == -1)
                        {
                            KisiGuncelle(kisiid);
                            KayitlariIdsizGuncelle(id1);
                        }
                        else
                        {
                            SqlConnection baglanti = new SqlConnection(baglantiYolu);
                            SqlCommand sifirlaKomut = new SqlCommand();
                            sifirlaKomut.Connection = baglanti;
                            sifirlaKomut.CommandType = CommandType.Text;
                            sifirlaKomut.CommandText = "delete from kayitlar where kayitID=@pkayitid";
                            sifirlaKomut.Parameters.AddWithValue("@pkayitid", id1);
                            baglanti.Open();
                            sifirlaKomut.ExecuteNonQuery();
                            baglanti.Close();

                            int gelenKayitID = kayitAra(gelenid);
                            if (gelenKayitID == -1)
                            {
                                SqlCommand ekleKomut = new SqlCommand();
                                ekleKomut.Connection = baglanti;
                                ekleKomut.CommandType = CommandType.Text;
                                ekleKomut.CommandText = "insert into kayitlar values(@pkisiid,@ptarih,@psayi,@palinantakoz,@pyerinemum,@pdusurulenfire,@psatilanpetek,@poduncpetek,@podenentakoz,@podenenkarapetek,@palinanpara)";
                                ekleKomut.Parameters.AddWithValue("@pkisiid", gelenid);
                                ekleKomut.Parameters.AddWithValue("@ptarih", yenitarih);
                                ekleKomut.Parameters.AddWithValue("@psayi", yenisayi);
                                ekleKomut.Parameters.AddWithValue("@palinantakoz", yenialinantakoz);
                                ekleKomut.Parameters.AddWithValue("@pyerinemum", yeniyerinemum);
                                ekleKomut.Parameters.AddWithValue("@pdusurulenfire", yenidusurulenfire);
                                ekleKomut.Parameters.AddWithValue("@psatilanpetek", yenisatilanpetek);
                                ekleKomut.Parameters.AddWithValue("@poduncpetek", yenioduncpetek);
                                ekleKomut.Parameters.AddWithValue("@podenentakoz", yeniodenentakoz);
                                ekleKomut.Parameters.AddWithValue("@podenenkarapetek", yeniodenenkarapetek);
                                ekleKomut.Parameters.AddWithValue("@palinanpara", yenialinanpara);
                                baglanti.Open();
                                ekleKomut.ExecuteNonQuery();
                                baglanti.Close();


                            }
                            else
                            {

                                SqlConnection baglanti6 = new SqlConnection(baglantiYolu);
                                SqlCommand komut4 = new SqlCommand();
                                komut4.Connection = baglanti6;
                                komut4.CommandType = CommandType.Text;

                                komut4.CommandText = "update kayitlar set eskipetek=eskipetek+@psayi,alinantakoz=alinantakoz+@palinantakoz,yerinemum=yerinemum+@pyerinemum,dusurulenfire=dusurulenfire+@pdusurulenfire,satilanpetek=satilanpetek+@psatilanpetek,oduncpetek=oduncpetek+@poduncpetek,odenentakoz=odenentakoz+@podenentakoz,odenenkarapetek=odenenkarapetek+@podenenkarapetek,alinanpara=alinanpara+@palinanpara where kayitID=@pid";
                                komut4.Parameters.AddWithValue("@psayi", yenisayi);
                                komut4.Parameters.AddWithValue("@palinantakoz", yenialinantakoz);
                                komut4.Parameters.AddWithValue("@pyerinemum", yeniyerinemum);
                                komut4.Parameters.AddWithValue("@pdusurulenfire", yenidusurulenfire);
                                komut4.Parameters.AddWithValue("@psatilanpetek", yenisatilanpetek);
                                komut4.Parameters.AddWithValue("@poduncpetek", yenioduncpetek);
                                komut4.Parameters.AddWithValue("@podenentakoz", yeniodenentakoz);
                                komut4.Parameters.AddWithValue("@podenenkarapetek", yeniodenenkarapetek);
                                komut4.Parameters.AddWithValue("@palinanpara", yenialinanpara);
                                komut4.Parameters.AddWithValue("@pid", gelenKayitID);


                                baglanti6.Open();
                                komut4.ExecuteNonQuery();
                                baglanti6.Close();

                            }
                            numaraDegistiMi = true;

                        }

                    }
                    else
                        KayitlariIdsizGuncelle(id1);
                       // MessageBox.Show("selam");


                    if (numaraDegistiMi)
                    {
                        if (isimDegistiMi && gelenid != -1)
                            TelefonGuncelle(gelenid);
                        else
                            TelefonGuncelle(kisiid);

                        numaraDegistiMi = false;
                    }

                    isimDegistiMi = false;

                    Temizleme();

                    MessageBox.Show("KAYIT DEĞİŞTİRİLDİ", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    

                    Form3 frm3 = new Form3();
                    DateTime baslangic = Form3.baslangic;
                    DateTime bitis = Form3.bitis;
                    DataSet kayitlar1 = frm3.TumunuListele(baslangic, bitis);
                    frm3.dataGridView1.DataSource = kayitlar1.Tables[0];
                    frm3.dateTimePicker1.Value = baslangic;
                    frm3.dateTimePicker2.Value = bitis;
                    frm3.radioButton10.Checked = true;
                    frm3.dataGridView1.Columns[6].Visible = true;
                    frm3.dataGridView1.Columns[7].Visible = true;
                    frm3.dataGridView1.Columns[8].Visible = true;
                    frm3.dataGridView1.Columns[9].Visible = true;
                    frm3.dataGridView1.Columns[10].Visible = true;
                    frm3.dataGridView1.Columns[11].Visible = true;
                    frm3.dataGridView1.Columns[12].Visible = true;
                    frm3.dataGridView1.Columns[13].Visible = true;
                    frm3.dataGridView1.Columns[14].Visible = true;
                    frm3.dataGridView1.Visible = true;
                    frm3.label5.Visible = true;
                    frm3.Show();
                    this.Close();

                  /*  sayi = yenisayi;
                    tarih = yenitarih;
                    ad= yeniad;
                    soyad = yenisoyad;
                    telefon = yenitelefon;
                    alinantakoz = yenialinantakoz;
                    yerinemum = yeniyerinemum;
                    dusurulenfire = yenidusurulenfire;
                    satilanpetek = yenisatilanpetek;
                    oduncpetek = yenioduncpetek;
                    odenentakoz = yeniodenentakoz;
                    odenenkarapetek = yeniodenenkarapetek;
                    alinanpara = yenialinanpara;

                    MessageBox.Show(Convert.ToString(kisiid) + Convert.ToString(isimDegistiMi) + Convert.ToString(numaraDegistiMi));*/

                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
            degisken = 0;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
            degisken = 0;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
            degisken = 0;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
            degisken = 0;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
            degisken = 0;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
            degisken = 0;

        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
            degisken = 0;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
            degisken = 0;
        }


        public void Temizleme()
        {
            SqlConnection baglanti3 = new SqlConnection(baglantiYolu);
            SqlCommand komut3 = new SqlCommand();
            komut3.Connection = baglanti3;
            komut3.CommandType = CommandType.Text;
            komut3.CommandText = "delete from kayitlar where eskipetek=0 and alinantakoz=0 and yerinemum=0 and dusurulenfire=0 and satilanpetek=0 and oduncpetek=0 and odenentakoz=0 and odenenkarapetek=0 and alinanpara=0";
      
            baglanti3.Open();
            komut3.ExecuteNonQuery();
            baglanti3.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            isimDegistiMi = true;
            degisken = 0;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {

            isimDegistiMi = true;
            degisken = 0;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            numaraDegistiMi = true;
            degisken = 0;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* DialogResult giriskapanis = MessageBox.Show("Programı kapatmak istediğinizden eminmisiniz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (giriskapanis == DialogResult.No)
            {
                e.Cancel = true;
                return;

            }
            Environment.Exit(0);*/
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {

        }


    }
}
