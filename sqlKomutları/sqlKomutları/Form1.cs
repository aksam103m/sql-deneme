using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sqlKomutları
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //global alana bağlantı adesini tanımladık...
       SqlConnection baglantim=new SqlConnection("Data Source=103A-7;Initial Catalog=KUTUPHANE;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kUTUPHANEDataSet.kitap' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kitapTableAdapter.Fill(this.kUTUPHANEDataSet.kitap);

        }

        private void button2_Click(object sender, EventArgs e)
        {//DİsConnection mimari
            SqlDataAdapter dk=new SqlDataAdapter("select*from kitap",baglantim);
            //sqlAddapter dataset ile sql arasında bağlantı kurarak istenilen  eylemi tabloda yapar
            DataSet ds =new DataSet();
            dk.Fill(ds, "kitap");
            //dk.Fill(ds) metodu doldurmak için ........Adapter in bir metodu....
            //   dataGridView1.DataSource = ds.Tables[0]; ile de çalışır.....

            dataGridView1.DataSource = ds.Tables["kitap"];



            

        }

        private void button1_Click(object sender, EventArgs e)
        {//Connection mimari open -close
            baglantim.Open();
            SqlCommand kayitekle = new SqlCommand
            ("insert into kitap(kitapno,kitapadi,sayfasayisi,yazaradi,vergi,kitapfiyat)" +
            "values(@k1,@k2,@k3,@k4,@k5,@k6)",baglantim);


           
            kayitekle.Parameters.AddWithValue("@k1", textBox1.Text);
            kayitekle.Parameters.AddWithValue("@k2", textBox2.Text);
            kayitekle.Parameters.AddWithValue("@k3", textBox3.Text);
            kayitekle.Parameters.AddWithValue("@k4", textBox4.Text);
            kayitekle.Parameters.AddWithValue("@k5", textBox5.Text);
            kayitekle.Parameters.AddWithValue("@k6", textBox7.Text);
  
          

            kayitekle.ExecuteNonQuery();// girilen değerleri sqle göndermeye yarar....
            MessageBox.Show("Kayıt eklendi.");
            baglantim.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            SqlCommand kayitsil = new SqlCommand("delete from kitap where kitapadi=@ad", baglantim);
            kayitsil.Parameters.AddWithValue("@ad", textBox2.Text);    
            MessageBox.Show("Kayıt silindi");
            kayitsil.ExecuteNonQuery();
            baglantim.Close();

        }
    }
}
