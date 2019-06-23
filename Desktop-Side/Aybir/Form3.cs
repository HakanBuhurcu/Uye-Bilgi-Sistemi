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
   
    public partial class Form3 : Form
    {
        string baglantiYolu = @"Data Source=localhost;Initial Catalog=Aybirveri;Integrated Security=True";

        public Form3()
        {
            InitializeComponent();
        }

        
        DateTimePicker dtpicket1;
        Form4 frm4 = new Form4();
        public static int kayitid;
        public static int kisiID;
        public static string veri;
        public static DateTime baslangic,bitis;
        string parametre = "";
        
        
        public static int deger = 0;
        
        private void button1_Click(object sender, EventArgs e)
        {
            baslangic = dateTimePicker1.Value.Date;
            bitis = dateTimePicker2.Value.Date;

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;

          
            


            if (radioButton1.Checked == true)
            {
                parametre = "eskipetek";
                frm4.label3.Text = "ESKİ PETEK (kg):";
                dataGridView1.Columns[6].Visible = true;
                deger = 6;
                frm4.label3.Location = new Point(87, 402);
                frm4.textBox3.Location = new Point(316, 402);
                veri = "eskipetek";
            }

            if (radioButton2.Checked == true)
            {

                parametre = "alinantakoz";
                dataGridView1.Columns[7].Visible = true;
                deger = 7;
                frm4.label3.Text = "ALINAN TAKOZ MUM (kg):";
                frm4.label3.Location = new Point(89, 402);
                frm4.textBox3.Location = new Point(418, 396);
                veri = "alinantakoz";

            }

            if (radioButton3.Checked == true)
            {
                parametre = "yerinemum";
                dataGridView1.Columns[8].Visible = true;
                deger = 8;
                frm4.label3.Text = "YERİNE VERİLEN MUM (kg):";
                frm4.label3.Location = new Point(89, 402);
                frm4.textBox3.Location = new Point(445, 399);
                veri = "yerinemum";

                
            }
            if (radioButton4.Checked == true)
            {
                parametre = "dusurulenfire";
                dataGridView1.Columns[9].Visible = true;
                deger = 9;
                frm4.label3.Text = "DÜŞÜRÜLEN FİRE (kg):";
                frm4.label3.Location = new Point(89, 402);
                frm4.textBox3.Location = new Point(397, 399);
                veri = "dusurulenfire";

               
            }

            if (radioButton5.Checked == true)
            {
                parametre = "satilanpetek";
                dataGridView1.Columns[10].Visible = true;
                deger = 10;
                frm4.label3.Text = "SATILAN PETEK";
                frm4.label3.Location = new Point(89, 402);
                frm4.textBox3.Location = new Point(373, 402);
                veri = "satilanpetek";

                
            }
            if (radioButton6.Checked == true)
            {
                parametre = "oduncpetek";
                dataGridView1.Columns[11].Visible = true;
                deger = 11;
                frm4.label3.Text = "ÖDÜNÇ VERİLEN PETEK";
                frm4.label3.Location = new Point(89, 402);
                frm4.textBox3.Location = new Point(421, 399);
                veri = "oduncpetek";


            }
            if (radioButton7.Checked == true)
            {
                parametre = "odenentakoz";
                dataGridView1.Columns[12].Visible = true;
                deger = 12;
                frm4.label3.Text = "ÖDENEN BORÇ TAKOZ";
                frm4.label3.Location = new Point(89, 402);
                frm4.textBox3.Location = new Point(406, 396);
                veri = "odenentakoz";

            }
            if (radioButton8.Checked == true)
            {
                parametre = "odenenkarapetek";
                dataGridView1.Columns[13].Visible = true;
                deger = 13;
                frm4.label3.Text = "ÖDENEN BORÇ KARAPETEK:";
                frm4.label3.Location = new Point(74, 399);
                frm4.textBox3.Location = new Point(445, 393);
                veri = "odenenkarapetek";
            }
            if (radioButton9.Checked == true)
            {
                parametre = "alinanpara";
                dataGridView1.Columns[14].Visible = true;
                deger = 14;
                frm4.label3.Text = "ALINAN PARA:";
                frm4.label3.Location = new Point(87, 402);
                frm4.textBox3.Location = new Point(269, 399);
                veri = "alinanpara";
            }
            if (radioButton10.Checked == true)
            {
                DataSet kayitlar2 = TumunuListele(baslangic, bitis);
                dataGridView1.DataSource = kayitlar2.Tables[0];


                deger = 6;
                dataGridView1.Columns[6].Visible = true;
                dataGridView1.Columns[7].Visible = true;
                dataGridView1.Columns[8].Visible = true;
                dataGridView1.Columns[9].Visible = true;
                dataGridView1.Columns[10].Visible = true;
                dataGridView1.Columns[11].Visible = true;
                dataGridView1.Columns[12].Visible = true;
                dataGridView1.Columns[13].Visible = true;
                dataGridView1.Columns[14].Visible = true;
            }
            else
            {
                if (parametre == "")
                    MessageBox.Show("HERHANGİ BİR ALAN SEÇMEDİNİZ","UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    DataSet kayitlar1 = Listele(baslangic, bitis, parametre);
                    dataGridView1.DataSource = kayitlar1.Tables[0];
                
                }
            }

         
            

            dataGridView1.Visible = true;
            label5.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
        }

        public  DataSet Listele(DateTime baslangic, DateTime bitis,string parametre)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "select kayitlar.kayitID,kayitlar.kisiID,kayitlar.tarih,Kisiler.Ad,Kisiler.Soyad,Kisiler.Telefon,kayitlar.eskipetek,kayitlar.alinantakoz,kayitlar.yerinemum,kayitlar.dusurulenfire,kayitlar.satilanpetek,kayitlar.oduncpetek,kayitlar.odenentakoz,kayitlar.odenenkarapetek,kayitlar.alinanpara from kayitlar inner join Kisiler on kayitlar.kisiID = kisiler.kisiID where tarih>=@pbaslangic and tarih<=@pbitis and " + parametre + "!=0";

            komut.Parameters.AddWithValue("@pbaslangic", baslangic);
            komut.Parameters.AddWithValue("@pbitis", bitis);

            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;

            DataSet sonuclar = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonuclar);
            baglanti.Close();

            return sonuclar;


        }

        public DataSet TumunuListele(DateTime baslangic, DateTime bitis)
        {
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            komut.CommandText = "select kayitlar.kayitID,kayitlar.kisiID,kayitlar.tarih,Kisiler.Ad,Kisiler.Soyad,Kisiler.Telefon,kayitlar.eskipetek,kayitlar.alinantakoz,kayitlar.yerinemum,kayitlar.dusurulenfire,kayitlar.satilanpetek,kayitlar.oduncpetek,kayitlar.odenentakoz,kayitlar.odenenkarapetek,kayitlar.alinanpara from kayitlar inner join Kisiler on kayitlar.kisiID = kisiler.kisiID where tarih>=@pbaslangic and tarih<=@pbitis";

            komut.Parameters.AddWithValue("@pbaslangic", baslangic);
            komut.Parameters.AddWithValue("@pbitis", bitis);

            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;

            DataSet sonuclar = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonuclar);
            baglanti.Close();

            return sonuclar;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
                MessageBox.Show("LİSTEDEN BİR KAYIT SEÇİN.LİSTEDE İSTEDİĞİNİZ SATIRIN EN SOLUNDAKİ BOŞLUĞA TIKLAYARAK KAYDI SEÇEBİLİRSİNİZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {

                kayitid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                kisiID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
                DateTime tarih = (DateTime)dataGridView1.SelectedRows[0].Cells[2].Value;
                string ad = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string soyad = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string telefon = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                string sayi = dataGridView1.SelectedRows[0].Cells[deger].Value.ToString();

                frm4.textBox1.Text = ad;
                frm4.textBox12.Text =  soyad;
                frm4.textBox2.Text = telefon;
                frm4.dateTimePicker1.Value = tarih;
                frm4.textBox3.Text = sayi;


                if (radioButton10.Checked == true)
                {
                    frm4.label6.Visible = true;
                    frm4.label7.Visible = true;
                    frm4.label8.Visible = true;
                    frm4.label9.Visible = true;
                    frm4.label10.Visible = true;
                    frm4.label11.Visible = true;
                    frm4.label12.Visible = true;
                    frm4.label13.Visible = true;
                    frm4.textBox4.Visible = true;
                    frm4.textBox5.Visible = true;
                    frm4.textBox6.Visible = true;
                    frm4.textBox7.Visible = true;
                    frm4.textBox8.Visible = true;
                    frm4.textBox9.Visible = true;
                    frm4.textBox10.Visible = true;
                    frm4.textBox11.Visible = true;
                    frm4.button1.Visible = false;
                    frm4.button3.Visible = true;

                    string alinantakoz = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                    string yerinemum = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                    string dusurulenfire = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                    string satilanpetek = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                    string oduncpetek = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                    string odenentakoz = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                    string odenenkarapetek = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
                    string alinanpara = dataGridView1.SelectedRows[0].Cells[14].Value.ToString();

                    frm4.textBox4.Text = alinantakoz;
                    frm4.textBox5.Text = yerinemum;
                    frm4.textBox6.Text = dusurulenfire;
                    frm4.textBox7.Text = satilanpetek;
                    frm4.textBox8.Text = oduncpetek;
                    frm4.textBox9.Text = odenentakoz;
                    frm4.textBox10.Text = odenenkarapetek;
                    frm4.textBox11.Text = alinanpara;

                    frm4.Show();
                    this.Close();
                }
                else
                {

                    frm4.Show();
                    this.Close();

                }
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if ((dataGridView1.Focused) && (dataGridView1.CurrentCell.ColumnIndex == 1))
                {
                    dtpicket1.Location = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex,e.RowIndex,false).Location;
                    dtpicket1.Visible = true;

                    if (dataGridView1.CurrentCell.Value != DBNull.Value)
                    {
                        dtpicket1.Value = (DateTime)dataGridView1.CurrentCell.Value;

                    }
                    else
                    {
                        dtpicket1.Value = DateTime.Today;
                    }



                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


            try
            {
                if ((dataGridView1.Focused) && (dataGridView1.CurrentCell.ColumnIndex == 1))
                {
                    dataGridView1.CurrentCell.Value = dtpicket1.Value.Date;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }



        }

        private void dtpicket1_ValueChanged(object sender, EventArgs e)
        {

            dataGridView1.CurrentCell.Value = dtpicket1.Text;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dtpicket1 = new DateTimePicker();
            dtpicket1.Format = DateTimePickerFormat.Short;
            dtpicket1.Visible = false;
            dtpicket1.Width = 150;

            dataGridView1.Controls.Add(dtpicket1);

            dtpicket1.ValueChanged += this.dtpicket1_ValueChanged;
            dataGridView1.CellBeginEdit += this.dataGridView1_CellBeginEdit;
            dataGridView1.CellEndEdit += this.dataGridView1_CellEndEdit;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglantim = new SqlConnection(baglantiYolu);
            if (dataGridView1.SelectedRows.Count != 1)
                MessageBox.Show("LİSTEDEN BİR KAYIT SEÇİN.LİSTEDE İSTEDİĞİNİZ SATIRIN EN SOLUNDAKİ BOŞLUĞA TIKLAYARAK KAYDI SEÇEBİLİRSİNİZ!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {

                int kayitidsi = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                if (radioButton10.Checked == true)
                {

                    SqlCommand komutSil = new SqlCommand();
                    komutSil.Connection = baglantim;
                    komutSil.CommandType = CommandType.Text;
                    komutSil.CommandText = "delete from kayitlar where kayitID=@pkayitid";
                    komutSil.Parameters.AddWithValue("@pkayitid", kayitidsi);
                    baglantim.Open();
                    komutSil.ExecuteNonQuery();
                    baglantim.Close();

                    DataSet kayitlar2 = TumunuListele(baslangic, bitis);
                    dataGridView1.DataSource = kayitlar2.Tables[0];

                }
                else
                {
                    SqlCommand sifirKomut = new SqlCommand();
                    sifirKomut.Connection = baglantim;
                    sifirKomut.CommandType = CommandType.Text;
                    sifirKomut.CommandText = "update kayitlar set " + parametre + "=0 where kayitID=@pkayitid";
                    sifirKomut.Parameters.AddWithValue("@pkayitid", kayitidsi);
                    baglantim.Open();
                    sifirKomut.ExecuteNonQuery();
                    baglantim.Close();

                    DataSet kayitlar2 = Listele(baslangic, bitis, parametre);
                    dataGridView1.DataSource = kayitlar2.Tables[0];

                }
                MessageBox.Show("KAYIT SİLİNMİŞTİR", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*DialogResult giriskapanis = MessageBox.Show("Programı kapatmak istediğinizden eminmisiniz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (giriskapanis == DialogResult.No)
            {
                e.Cancel = true;
                return;

            }
            Environment.Exit(0);*/
        }

       

       

    }
}
