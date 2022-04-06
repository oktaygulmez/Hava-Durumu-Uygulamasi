using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string apikey = "b39763eab635c9fcd8ab9fdf54ae0845";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid="+apikey;


            XDocument weather = XDocument.Load(connection);
            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var weatherstate = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
            label1.Text = "İstanbulda hava " + temp + " derece ve " + weatherstate;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         //   timer1.Start();
        }
        static HttpWebRequest requestCollectAPI;
        static StreamReader requestCollectAPIReader;

        static HttpWebRequest requestCollectAPI2;
        static StreamReader requestCollectAPIReader2;

        static HttpWebRequest requestCollectAPI3;
        static StreamReader requestCollectAPIReader3;
        private void button2_Click(object sender, EventArgs e)
        {
            requestCollectAPI = WebRequest.Create("https://api.collectapi.com/weather/getWeather?data.lang=tr&data.city=istanbul") as HttpWebRequest; //API URL'sini alıyorum.
            requestCollectAPI.ContentType = "application/json"; //Content'ini JSON yapıyorum.
            requestCollectAPI.Headers["authorization"] = "apikey 11ARlKSqZOhcuSosjstXem:3uHdsoTZIE7TJBnsXilt3c"; //APIKey giriyorum.
            requestCollectAPI.Method = "GET"; //Veriler için GET metodunu

            requestCollectAPIReader = new StreamReader((requestCollectAPI.GetResponse() as HttpWebResponse).GetResponseStream());

            JObject requestCollectAPIJSONData = JObject.Parse(requestCollectAPIReader.ReadToEnd()); //JSON verisini Parse ediyoruz.
            JArray requestCollectAPIJSONDataArray = (JArray)requestCollectAPIJSONData["result"]; //result bölgesini bi' Array'e atıyoruz.
            Int32 requestCollectAPICountryCount = requestCollectAPIJSONDataArray.Count - 1;

            for (Int32 count = 0; count <= requestCollectAPICountryCount; ++count)
            {
              //  label1.Text = (requestCollectAPIJSONDataArray[count]["date"]).ToString();
             //   label1.Text += " " + (requestCollectAPIJSONDataArray[count]["day"]).ToString();
                label11.Text = (requestCollectAPIJSONDataArray[count]["degree"]).ToString() + " °C Derece";
                label12.Text = (requestCollectAPIJSONDataArray[count]["max"]).ToString() + " °C Derece";
                label13.Text = (requestCollectAPIJSONDataArray[count]["min"]).ToString() + " °C Derece";
                label14.Text = "% " + (requestCollectAPIJSONDataArray[count]["degree"]).ToString();
                label15.Text = (requestCollectAPIJSONDataArray[count]["description"]).ToString();             
            }
            //Ankara
            requestCollectAPI2 = WebRequest.Create("https://api.collectapi.com/weather/getWeather?data.lang=tr&data.city=ankara") as HttpWebRequest; //API URL'sini alıyorum.
            requestCollectAPI2.ContentType = "application/json"; //Content'ini JSON yapıyorum.
            requestCollectAPI2.Headers["authorization"] = "apikey 11ARlKSqZOhcuSosjstXem:3uHdsoTZIE7TJBnsXilt3c"; //APIKey giriyorum.
            requestCollectAPI2.Method = "GET"; //Veri çekeceğimiz için GET metodunu kullandık.

            requestCollectAPIReader2 = new StreamReader((requestCollectAPI2.GetResponse() as HttpWebResponse).GetResponseStream());

            JObject requestCollectAPIJSONData2 = JObject.Parse(requestCollectAPIReader2.ReadToEnd()); //JSON verisini Parse ediyoruz.
            JArray requestCollectAPIJSONDataArray2 = (JArray)requestCollectAPIJSONData2["result"]; //result bölgesini bi' Array'e atıyoruz.
            Int32 requestCollectAPICountryCount2 = requestCollectAPIJSONDataArray2.Count - 1;

            for (Int32 count = 0; count <= requestCollectAPICountryCount2; ++count)
            {
                label20.Text = (requestCollectAPIJSONDataArray2[count]["degree"]).ToString() + " °C Derece";
                label19.Text = (requestCollectAPIJSONDataArray2[count]["max"]).ToString() + " °C Derece";
                label18.Text = (requestCollectAPIJSONDataArray2[count]["min"]).ToString() + " °C Derece";
                label17.Text = "% " + (requestCollectAPIJSONDataArray2[count]["degree"]).ToString();
                label16.Text = (requestCollectAPIJSONDataArray2[count]["description"]).ToString();
            }
            //İzmir
            requestCollectAPI3 = WebRequest.Create("https://api.collectapi.com/weather/getWeather?data.lang=tr&data.city=izmir") as HttpWebRequest; //API URL'sini alıyoruz.
            requestCollectAPI3.ContentType = "application/json"; //Content'ini JSON yapıyoruz.
            requestCollectAPI3.Headers["authorization"] = "apikey 11ARlKSqZOhcuSosjstXem:3uHdsoTZIE7TJBnsXilt3c"; //APIKey'imizi buraya ekliyeceğiz.
            requestCollectAPI3.Method = "GET"; //Veri çekeceğimiz için GET metodunu kullandık.

            requestCollectAPIReader3 = new StreamReader((requestCollectAPI3.GetResponse() as HttpWebResponse).GetResponseStream());

            JObject requestCollectAPIJSONData3 = JObject.Parse(requestCollectAPIReader3.ReadToEnd()); //JSON verisini Parse ediyoruz.
            JArray requestCollectAPIJSONDataArray3 = (JArray)requestCollectAPIJSONData3["result"]; //result bölgesini bi' Array'e atıyoruz.
            Int32 requestCollectAPICountryCount3 = requestCollectAPIJSONDataArray3.Count - 1;

            for (Int32 count = 0; count <= requestCollectAPICountryCount3; ++count)
            {
                label31.Text = (requestCollectAPIJSONDataArray3[count]["degree"]).ToString() + " °C Derece";
                label30.Text = (requestCollectAPIJSONDataArray3[count]["max"]).ToString() + " °C Derece";
                label29.Text = (requestCollectAPIJSONDataArray3[count]["min"]).ToString() + " °C Derece";
                label28.Text = "% " + (requestCollectAPIJSONDataArray3[count]["degree"]).ToString();
                label27.Text = (requestCollectAPIJSONDataArray3[count]["description"]).ToString();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.Hour.ToString()  + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
        }
    }
}
