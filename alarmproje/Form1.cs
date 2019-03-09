using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace alarmproje
{
    /*
    Bir form üzerinde girilen tarih ve saat (saat ve dakika) geldiğinde hatırlatacak bir alarm uygulaması hazırlayınız.
Form üzerinde tarih seçimi için DateTimePicker, saat ve dakika girişi için MaskedTextBox kullanınız.
Ayrıca çok satırlı bir hatırlatma notu girilecek metin alanı oluşturunuz.
Form üzerinde Alarm Kur butonuna tıklandığında form gizlenip, ikon halinde beklemeli, alarm zamanı geldiğinde ekran ön plana gelmeli. O anda ekranda başka açık programlar olabileceği için form her şeyin önüne gelmeli.
Alarm kurulmadan önce ve sonra form açıkken şimdiki zaman saat, dakika ve saniye bilgisi form başlığında gösterilmeli.
Alarm başladığında tekrar tekrar bir ses çalınmalı, ekranda hatırlatma notu alanının arka planı kırmızı ve beyaz renkler arasında değişmeli ve form üzerindeki bir zil resmi kendi etrafında küçük hareketler yaparak sarsılma etkisi oluşturulmalı. Bu hareketler için Timer nesnesi kullanınız.
Form üzerinde Alarmı durdur butonuna tıklanınca Alarm hareketleri ve ses durdurulmalı.
Ses çalmak için SoundPlayer sınıfını ve C:\Windows klasöründeki WAV dosyalarından birisini kullanabilirsiniz.

    */
    public partial class Form1 : Form
    {
        SoundPlayer ses = new SoundPlayer();
        bool renkChanged = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           
            if (maskedTextBox1.Text == DateTime.Now.ToString("HH:mm"))
            {
                
                string alarmmuzigi = Application.StartupPath + "\\alarm.wav"; //alarm sesinin yolunu verdik
                ses.SoundLocation = alarmmuzigi; 
                ses.Play();
                timer3.Start();
                Random rnd = new Random(); //random sınıfından instance aldık
                pictureBox1.Top = rnd.Next(panel1.ClientSize.Height/3); //Panel içerisinde alarm resmi rastgele gidip gelecek
                pictureBox1.Left = rnd.Next(panel1.ClientSize.Width/3);
                this.Visible = true; // alarm çalmaya başladığında arkaplandaki ikon ekrana sayfa şeklinde gelecek. 
                
            }
        }
        private void btn_Acma_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            //Ekranın görünürlüğünü kapattık.İkonu arka plana attık
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.Text = DateTime.Now.ToString();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {//notifyIcon toolboxtan ekledik. İkon halinde göstermeye yarar.
            this.Visible = true;
            //ikona çift tıklarsak ekranın görünürlüğünü açar.
        }

        private void btn_Kapat_Click(object sender, EventArgs e)
        {//btn_Kapat klik eventinde 
            timer2.Stop();
            ses.Stop(); // alarm sesini kapattık
            timer3.Stop();
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (renkChanged==false)
            {
                richTextBox1.BackColor = Color.White; //richtextboxtaki yazı ve arkaplan rengi kırmızı beyaz arasında alarm çaldığı sürece değişecek
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.BackColor = Color.Red;
                richTextBox1.ForeColor = Color.White;
                renkChanged = true;
            }
            else
            {
                richTextBox1.BackColor = Color.Red;
                richTextBox1.ForeColor = Color.White;
                richTextBox1.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Red;
                renkChanged = false;
            }
        }
    }
}
