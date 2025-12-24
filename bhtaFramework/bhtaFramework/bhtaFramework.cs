using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace bhtaFramework
{
    public class bhtaFramework
    {
        public string SupportURL = "207.180.249.126";
        public string LoginNetURL = "http://207.180.249.126";
        public string DashboardURL = "https://e-iot.eu";
        //public string LoginNetURL = "https://localhost:44340";
        public string SQLIP = "207.180.249.126";

        /// <summary>
        /// Returns a 10-character string representing the current date and time in a serial number format.
        /// </summary>
        /// <returns>A 10-digit serial number string.</returns>
        public string GetDateTimeSerial()
        {
            // Get the current date and time
            DateTime now = DateTime.Now;

            // Combine the components into a single number
            // We use a long to ensure we have enough space for the large number
            long serialNumber = (long)now.Year * 10000000000L +
                                (long)now.Month * 100000000L +
                                (long)now.Day * 1000000L +
                                (long)now.Hour * 10000L +
                                (long)now.Minute * 100L +
                                (long)now.Second;

            // Convert the number to a string and return the last 10 characters
            // This ensures a fixed length of 10 digits
            string serialString = serialNumber.ToString();
            return serialString.Substring(serialString.Length - 10);
        }

        public List<string> CloudSqlServers()
        {
    
            return new List<string> { "207.180.249.126" };
        }

        public string DecimaSeperator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        public string clouduid = "l1usr";
        public string cloudpwd = "41accb27-3922-48b3-869a-69b3d2b8bba6";
       
        public string WatermarkImage(string imagepath, string watermarkpath)
        {
            File.Move(imagepath, imagepath + "_");
            imagepath = imagepath + "_";
            using (Image image = Image.FromFile(imagepath))
            using (Image watermarkImage = Image.FromFile(watermarkpath))
            using (Graphics imageGraphics = Graphics.FromImage(image))
            using (Brush watermarkBrush = new TextureBrush(watermarkImage))
            {
                //int x = (image.Width - watermarkImage.Width) / 2;
                int x = 0;
                //int y = (image.Height - watermarkImage.Height) / 2;
                int y = 0;
                imageGraphics.FillRectangle(watermarkBrush, x, y, watermarkImage.Size.Width - x, watermarkImage.Size.Height - y);
                image.Save(imagepath.Substring(0, imagepath.Length - 1));
                return imagepath.Substring(0, imagepath.Length - 1);
            }
        }

        public Boolean SendEmail(string to, string subject, string body, string from = "notifications@e-iot.eu", string pass = "diHaC1eci+RX", string ip = "mail.e-iot.eu", int port = 465)
        {
            //  notifications@e-iot.eu diHaC1eci+RX mail.e-iot.eu 465
            // megasoft.cc@gmail.com mega==mega smtp.gmail.com 587
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("", from));
                emailMessage.To.Add(new MailboxAddress("", to));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart("html") { Text = body };

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                MailKit.Net.Smtp.SmtpClient smtp1 = new MailKit.Net.Smtp.SmtpClient();

                using (MailKit.Net.Smtp.SmtpClient smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtp.Connect(ip, port, MailKit.Security.SecureSocketOptions.Auto);
                    smtp.Authenticate(from, pass);
                    smtp.Send(emailMessage);
                    smtp.Disconnect(true);
                }
                return true;
            }
            catch(Exception ex)
            {
                string tmp = ex.Message;
                tmp += "";
                return false;
            }
        }
        public Boolean SendEmailOld(string to, string subject, string body, string from = "megasoft.cc@gmail.com", string pass = "mega==mega", string ip = "smtp.gmail.com", int port = 587)
        {
            try
            {
                MailMessage MyEmail = new MailMessage(from, to, subject, body);
                MyEmail.IsBodyHtml = true;
                MyEmail.Bcc.Add(new MailAddress(from));

                //SmtpClient s = new SmtpClient(ip, port);
                //s.UseDefaultCredentials = false;
                //s.Credentials = new System.Net.NetworkCredential(from, pass);
                //s.EnableSsl = false;
                //s.Send(MyEmail);

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Host = ip;
                    smtp.Port = port;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    smtp.Send(MyEmail);
                    // send the email
                }


                return true;
            }
            catch (Exception ex)
            {
                string r = "";
                r = ex.Data.ToString() + ex.Message;

                return false;
            }
        }

        public string WatermarkImage(byte[] block, byte[] rellay, string imagepath, int left, int top, int width, int height)
        {
            Image image = (Bitmap)((new ImageConverter()).ConvertFrom(block));
            Image watermarkImage = (Bitmap)((new ImageConverter()).ConvertFrom(rellay));

            using (Graphics imageGraphics = Graphics.FromImage(image))
            using (Brush watermarkBrush = new TextureBrush(watermarkImage))
            {
                imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(left, top), new Size(width, height)));
                try
                {
                    if (File.Exists(imagepath)) File.Delete(imagepath);
                    image.Save(imagepath);
                    return imagepath;
                }
                catch { return ""; }
            }
        }

        public byte[] WatermarkImage(byte[] block, byte[] rellay, int left, int top, int width, int height)
        {
            Image image = (Bitmap)((new ImageConverter()).ConvertFrom(block));
            Image watermarkImage = (Bitmap)((new ImageConverter()).ConvertFrom(rellay));

            using (Graphics imageGraphics = Graphics.FromImage(image))
            using (Brush watermarkBrush = new TextureBrush(watermarkImage))
            {
                imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(left, top), new Size(width, height)));
                return imageToByteArray(image);
            }
        }

        public static byte[] ReadFromStream(Stream input)
        {
            byte[] buffer = new byte[1024 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Bmp);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public System.Data.DataTable FormatSuppressColumns(System.Data.DataTable dt)
        {
            List<string> cl = new List<string>();

            if (dt.Rows.Count > 0)
                for (int c = 0; c < dt.Columns.Count; c++)
                    cl.Add(dt.Rows[0][c].ToString());

            for (int i = 1; i < dt.Rows.Count; i++)
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    if (dt.Columns[c].DataType.ToString().Equals("System.String"))
                        if (dt.Rows[i][c].ToString().Equals(cl[c]))
                            dt.Rows[i][c] = "";
                        else cl[c] = dt.Rows[i][c].ToString();
                    if (dt.Columns[c].DataType.ToString().Equals("System.String"))
                    { }
                }
            return dt;
        }

        public string ConvertISO(string description)
        {
            description = description.ToLower();
            description = NotValidCharsISO(description);
            description = description.Replace("α", "a").Replace("β", "v").Replace("γ", "g").Replace("δ", "d").Replace("ε", "e").Replace("ζ", "z").Replace("η", "i").Replace("θ", "th").Replace("ι", "i").Replace("κ", "k");
            description = description.Replace("λ", "l").Replace("μ", "m").Replace("ν", "n").Replace("ξ", "x").Replace("ο", "o").Replace("π", "p").Replace("ρ", "r").Replace("σ", "s").Replace("τ", "t").Replace("υ", "y");
            description = description.Replace("φ", "f").Replace("χ", "x").Replace("ψ", "ps").Replace("ω", "o");
            description = description.Replace("ά", "a").Replace("έ", "e").Replace("ή", "i").Replace("ί", "i").Replace("ό", "o").Replace("ύ", "y").Replace("ώ", "o").Replace("ς", "s");
            return description;
        }
        public string NotValidCharsISO(string description, string ch = "-")

        {
            description = description.Replace(@"""", "'");
            description = description.Replace("^", ch).Replace(@"\", ch).Replace("|", ch).Replace("}", ch).Replace("{", ch).Replace("]", ch).Replace("[", ch).Replace(">", ch).Replace("<", ch).Replace("#", ch).Replace("%", ch);
            description = description.Replace("@", ch).Replace("$", ch).Replace("?", ch).Replace("=", ch).Replace(" ", ch).Replace(".", ch).Replace(":", ch).Replace("/", ch).Replace("&", ch).Replace("+", ch).Replace("~", ch);
            description = description.Replace("%", ch);
            return description;
        }

        public void ScreenCapture(IntPtr t, string name)
        {
            ScreenShot.ScreenCapture sc = new ScreenShot.ScreenCapture();
            //Image img = sc.CaptureScreen();
            sc.CaptureWindowToFile(t, chkeckfolders("interface", "captures") + name + ".jpg", ImageFormat.Jpeg);
        }
        public string chkeckfolders(string mytype, string mydirectory = "customization")
        {
            string returnstring = "";
            string mydir_customization = mydirectory;
            try { if (Directory.Exists(mydir_customization) == false) Directory.CreateDirectory(mydir_customization);
                returnstring = mydir_customization + @"\"; }
            catch { }
            try { if (Directory.Exists(returnstring + mytype) == false) Directory.CreateDirectory(returnstring + mytype);
                returnstring = returnstring + mytype + @"\"; }
            catch { }
            return returnstring;
        }

        public string getDataFromString(string str, string fieldName, string endStr)
        {
            try
            {
                int start = str.IndexOf(fieldName);
                int end = str.Substring(start, str.Length - start).IndexOf(endStr);
                return str.Substring(start, end).Replace(fieldName, "");
            }
            catch { return ""; }
        }
    

        public string getResponseFromURL(string URL)
        {
            string s = "";
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            try
            {
                Stream data = client.OpenRead(URL);
                StreamReader reader = new StreamReader(data);
                s = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                s = ex.Message;
            }
            return s;
        }

        public List<string> ExtractSubsets(string inputString, string open="{", string close="}")
        {
            List<string> subsets = new List<string>();
            int startIndex = 0;

            while (startIndex < inputString.Length)
            {
                int openingBraceIndex = inputString.IndexOf(open, startIndex);
                if (openingBraceIndex < 0) // if no opening brace is found, exit loop
                {
                    break;
                }

                int closingBraceIndex = inputString.IndexOf(close, openingBraceIndex);
                if (closingBraceIndex < 0) // if no closing brace is found, exit loop
                {
                    break;
                }

                int subsetLength = closingBraceIndex - openingBraceIndex + 1;
                string subset = inputString.Substring(openingBraceIndex, subsetLength).Replace(open,"").Replace(close,"");
                subsets.Add(subset);

                startIndex = closingBraceIndex + 1;
            }

            return subsets;
        }

        public void Save(string state, string recid)
        {
            try
            {

                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filePath = Path.Combine(documentsPath, recid);
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Dispose();
                }
                File.WriteAllText(filePath, state);
            }
            catch (Exception ex)
            {
                string tmp = ex.Message;
            }
        }

        public static string GetCryptoString(string code, string str)
    {
        string combinedStr = code + str;
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedStr));
            string hashStr = BitConverter.ToString(hashBytes).Replace("-", "");

            // Take the first 13 characters of the hash and return them
            return hashStr.Substring(0, 13);
        }
    }

        public int GetPeriods(DateTime startDate, DateTime endDate, int minutes)
        {
            // Υπολογισμός διαφοράς σε TimeSpan
            TimeSpan timeSpan = endDate - startDate;

            // Υπολογισμός διαφοράς σε λεπτά
            int totalMinutes = (int)timeSpan.TotalMinutes;

            // Υπολογισμός αριθμού περιόδων
            int periods = totalMinutes / minutes;

            // Επιστροφή αριθμού περιόδων
            return periods;
        }
        public List<DateTime> GetTimeIntervals(DateTime startDate, DateTime endDate, int minutes)
        {
            // Calculate the total number of intervals
            var totalIntervals = (int)Math.Ceiling((endDate - startDate).TotalMinutes / minutes);

            // Create a list to store the timestamps
            var timestamps = new List<DateTime>();

            // Iterate through each interval and add the timestamp to the list
            for (var i = 0; i < totalIntervals; i++)
            {
                timestamps.Add(startDate.AddMinutes(i * minutes));
            }

            return timestamps;
        }

        public string GetLocalIPAddress()
        {
            // Gets the host name of the local machine
            var host = Dns.GetHostEntry(Dns.GetHostName());

            // Finds the first IPv4 address in the list
            var ipAddress = host.AddressList
                .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

            if (ipAddress == null)
            {
                throw new Exception("No IPv4 address found for this machine.");
            }

            return ipAddress.ToString();
        }

        public DataTable CsvToDataTable(string filePath, bool hasHeader = true, char delimiter = ',')
        {
            DataTable dt = new DataTable();
            string[] lines = null;

            try
            {
                // Διαβάζουμε όλες τις γραμμές του αρχείου
                lines = File.ReadAllLines(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Σφάλμα: Το αρχείο δεν βρέθηκε στη διαδρομή: {filePath}");
                return dt; // Επιστρέφουμε άδειο DataTable σε περίπτωση σφάλματος
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Σφάλμα κατά την ανάγνωση του αρχείου: {ex.Message}");
                return dt;
            }

            if (lines.Length == 0)
            {
                return dt; // Επιστρέφουμε άδειο αν το αρχείο είναι κενό
            }

            // --- 1. Δημιουργία Στηλών ---

            // Χρησιμοποιούμε την πρώτη γραμμή για τους τίτλους των στηλών
            string headerLine = lines[0];
            string[] columnNames = headerLine.Split(delimiter);

            for (int i = 0; i < columnNames.Length; i++)
            {
                // Καθαρίζουμε τυχόν κενά ή εισαγωγικά από το όνομα της στήλης
                string columnName = columnNames[i].Trim().Replace("\"", "");
                dt.Columns.Add(columnName);
            }

            // --- 2. Προσθήκη Δεδομένων ---

            // Ξεκινάμε από τη γραμμή 0 ή 1 ανάλογα με το αν υπάρχει επικεφαλίδα
            int dataStartLine = hasHeader ? 1 : 0;

            for (int i = dataStartLine; i < lines.Length; i++)
            {
                string line = lines[i];
                // Διαχωρίζουμε τα πεδία της τρέχουσας γραμμής
                string[] fields = line.Split(delimiter);

                // Ελέγχουμε αν έχουμε τον σωστό αριθμό πεδίων (για να αποφύγουμε σφάλματα)
                if (fields.Length == dt.Columns.Count)
                {
                    // Δημιουργούμε μια νέα γραμμή στο DataTable και προσθέτουμε τα δεδομένα
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < fields.Length; j++)
                    {
                        // Καθαρίζουμε τυχόν κενά ή εισαγωγικά
                        string fieldValue = fields[j].Trim().Replace("\"", "");
                        dr[j] = fieldValue;
                    }
                    dt.Rows.Add(dr);
                }
                // Αν τα πεδία δεν ταιριάζουν, η γραμμή παραβλέπεται (ή θα μπορούσε να πεταχτεί εξαίρεση)
            }

            return dt;
        }


        public List<List<string>> XmlToList(string xmlString)
        {
            var resultList = new List<List<string>>();

            if (string.IsNullOrEmpty(xmlString))
            {
                return resultList;
            }

            try
            {
                
                XDocument doc = XDocument.Parse(xmlString);
                var terminalElements = doc.Descendants()
                    .Where(e => !e.HasElements);

                foreach (var element in terminalElements)
                {
                    var nodeData = new List<string>
            {
                element.Name.LocalName, 
                element.Value           
            };

                    resultList.Add(nodeData);
                }
            }
            catch (System.Xml.XmlException ex)
            {
                // Μη έγκυρο XML
                //return ($"Σφάλμα στην επεξεργασία του XML: {ex.Message}");
                return new List<List<string>>();
            }

            return resultList;
        }

        public List<List<string>> XMLToListOfLists(string soapResponse)
        {
            var results = new List<List<string>>();

            try
            {
                // Φόρτωση του XML
                XDocument doc = XDocument.Parse(soapResponse);

                // 1. Εύρεση του βασικού κόμβου απάντησης
                XElement responseNode = doc.Descendants( "retrieveKedeAmountResponse").FirstOrDefault();

                if (responseNode == null)
                {
                    // Επιστρέφει κενή λίστα αν δεν βρει τον βασικό κόμβο
                    return results;
                }

                // 2. Επεξεργασία όλων των άμεσων παιδιών του responseNode
                foreach (var element in responseNode.Elements())
                {
                    string fieldName = element.Name.LocalName;
                    string fieldValue = element.Value.Trim();

                    if (fieldName == "retrieveKedeAmountOutputRecord")
                    {
                        // Επεξεργασία των παιδιών μέσα στον κόμβο <retrieveKedeAmountOutputRecord>
                        foreach (var subElement in element.Elements())
                        {
                            // Προσθήκη ζεύγους: [Όνομα_Πεδίου, Τιμή_Πεδίου]
                            results.Add(new List<string> { subElement.Name.LocalName, subElement.Value.Trim() });
                        }
                    }
                    else
                    {
                        // Προσθήκη ζεύγους: [Όνομα_Πεδίου, Τιμή_Πεδίου]
                        // (Αυτό καλύπτει τα <callSequenceId>, <callSequenceDate>, <errorRecord>)
                        results.Add(new List<string> { fieldName, fieldValue });
                    }
                }
            }
            catch (Exception ex)
            {
                // Αν συμβεί κάποιο σφάλμα στο parsing (π.χ. άκυρο XML)
                Console.WriteLine($"Σφάλμα κατά την ανάλυση του XML: {ex.Message}");
                return new List<List<string>>();
            }

            return results;
        }
    }

    public class googleGraphs
    {
        // Set one Literal_Script (GetLoader + GetScrit + GetScript)
        // Set Literal_GetHtml for all the graphs (GetHtml)

        public string GetLoader()
        { return "<script type='text/javascript' src='https://www.gstatic.com/charts/loader.js'></script>"; }
        public class Gauge
        {
            public string GetScript(string G_VText, 
                                    string G_Value,
                                    string G_Range_greenFrom,                                     
                                    string G_Range_redFrom, 
                                    string G_Id, 
                                    string G_min = "0", 
                                    string G_max = "100", 
                                    string G_width = "180", 
                                    string G_heigh = "180")
            {
                string G_Range = @"greenFrom: @G_Range_greenFrom , 
                                   greenTo: @G_Range_redFrom ,
                                   yellowFrom: @G_min , 
                                   yellowTo: @G_Range_greenFrom, 
                                   redFrom: @G_Range_redFrom , 
                                   redTo: @G_max ".Replace("@G_Range_greenFrom", G_Range_greenFrom).Replace("@G_min", G_min).Replace("@G_Range_redFrom", G_Range_redFrom).Replace("@G_max", G_max);                
                return (@"<script type='text/javascript'>
                                  google.charts.load('current', {'packages':['gauge']}); 
                                  google.charts.setOnLoadCallback(drawChart); 
                                  function drawChart() 
                                         { 
                                            var data = google.visualization.arrayToDataTable([ ['Label', 'Value'], ['@G_VText', @G_Value], ]); 
                                            var options = { 
                                                min: @G_min, 
                                                max: @G_max, 
                                              width: @G_width, 
                                             height: @G_heigh, 
                                             @G_Range, 
                                          minorTicks: 1 }; 
                                           var chart = new google.visualization.Gauge(document.getElementById('@gaug_id')); 
                                               chart.draw(data, options); } 
                           </script>").Replace("@G_VText", G_VText).Replace("@G_Value", G_Value).Replace("@G_Range", G_Range).Replace("@gaug_id", G_Id).Replace("@G_width", G_width).Replace("@G_heigh", G_heigh).Replace("@G_min", G_min).Replace("@G_max", G_max);
            }

            public string GetHtml(string G_Title, string G_Header, string G_Id, int min_width = 180, string sxol="", string c="", string cDesc="", string s="", string sDesc="", string f="", string l="")
            {
                return @"<div class='col-md-3' style='padding: 15px;'>

                             
  <div class='card bg-secondary text-white' style='padding: 15px; min-width: @min_widthpx;'>
    <div class='row card-img-top'>
        <div class='col-md-2'></div>
        <div id='@G_Id' class='col-md-8'></div>
    </div>
    
    <div class='card-body'>
      <h4 class='card-title'>@G_Header</h4>
      <p class='card-text'>@G_Title</p>
      <div class='row'>
           <div class='col-md-8'>@sxol</div>
           <div class='col-md-3'><a href='#' onclick=""showSensorStat('@c', '@cDesc', '@s', '@sDesc', '@f', '@l')""><img src='/images/statistics.png' style='width: 30px;'></a></div>
      </div>
    </div>
  </div>
  
                        </div>
  
                        
                            ".Replace("@cDesc", cDesc).Replace("@sDesc", sDesc).Replace("@G_Title", G_Title).Replace("@G_Header", G_Header).Replace("@G_Id", G_Id).Replace("@min_width", (min_width+10).ToString()).Replace("@sxol",sxol).Replace("@c", c).Replace("@s", s).Replace("@f", f).Replace("@l", l);
            }         
        }

        public class ComboCharts
        {
            public string GetScript(string G_Id, List<string> G_Titles, List<List<string>> G_Data)
            {
                string gTitles = "[";
                string Values = "";
                for (int i = 0; i < G_Titles.Count; i++)
                {
                    gTitles += ("'" + G_Titles[i] + "',");
                    if (i > 0) Values += (G_Titles[i] + "+");
                }
                if(Values.Length > 0) Values = Values.Substring(0, Values.Length - 1);
                gTitles += "'Avarange=(@Values)/".Replace("@Values", Values.Replace("Avarange=", "")) + (G_Titles.Count-1).ToString()+"'],";

                string gData = "";
                for (int i=0; i<G_Data.Count; i++)
                {
                    gData += "[";
                    for(int x=0; x<G_Data[i].Count; x++)
                        gData += (G_Data[i][x]+",");
                    gData += (GetAvg(G_Data[i]).Replace(",", ".")) + "],";
                    //gData += "],";
                }
                if (gData.Length > 0) gData = gData.Substring(0, gData.Length - 1);

                string G_GroupTitle = "";
                if (G_Titles.Count > 0) G_GroupTitle = G_Titles[0];

                string s1 = "<script type='text/javascript'>google.charts.load('current', { 'packages': ['corechart'] });google.charts.setOnLoadCallback(drawVisualization);function drawVisualization() {var data = google.visualization.arrayToDataTable([";
                string s2 = gTitles + gData;
              
                string s3 = "]);var options = { title: '', backgroundColor: 'black', vAxis: { title: '' }, hAxis: { title: '' }, seriesType: 'bars', series: { " + (G_Titles.Count-1).ToString() + ": { type: 'line' } } };";
                string s4 = "var chart = new google.visualization.ComboChart(document.getElementById('@G_Id')); chart.draw(data, options); } </script>".Replace("@G_Id",G_Id);

                return s1+s2+s3+s4;
            }

            public string GetHtml(string G_Id, string G_Heigh="400")
            {
                string tmp = "";
                //tmp += "<div class='card scroll' style='height:@height; opacity:1;'><div class='card-body'>".Replace("@height", (Convert.ToInt16(G_Heigh.Replace("px", "").Trim()) + 50).ToString() + "px");
                tmp += "<div id='@G_Id' style='margin:10px; width:98%; height:@G_Heighpx'></div>".Replace("@G_Id", G_Id).Replace("@G_Heigh", G_Heigh);
                //tmp += "</div></div>";
                return tmp;
            }

            private string GetAvg(List<string> G_Rec)
            {
                double avg = 0;
                for (int i = 1; i < G_Rec.Count; i++)
                    avg += Convert.ToDouble(G_Rec[i].Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace(",", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                return (Math.Round((avg / (G_Rec.Count - 1)), 2).ToString()).Replace(",", ".");
            }
        }

        public class Table
        {
            public string GetScript(string G_Id, List<List<string>> G_Columns, List<List<string>> G_Rows)
            {
                string code = "<script type='text/javascript'> google.charts.load('current', { 'packages': ['table'] }); google.charts.setOnLoadCallback(drawTable); function drawTable() { var data = new google.visualization.DataTable();";
                // string, number, boolean
                for (int i = 0; i < G_Columns.Count; i++)
                    code += ("data.addColumn('"+ G_Columns[i][0]+ "', '" + G_Columns[i][1]+ "'); ");

                code += "data.addRows([";
                for (int i = 0; i < G_Rows.Count; i++)
                {
                    code += "[";
                    for (int x = 0; x < G_Rows[i].Count; x++)
                            code += (G_Rows[i][x]+",");
                    code = code.Substring(0, code.Length - 1);
                    code += "], ";
                }
                code = code.Substring(0, code.Length - 1);

                code += "]); var table = new google.visualization.Table(document.getElementById('@G_Id')); ".Replace("@G_Id", G_Id);
                code += "table.draw(data, { width: '100%', height: '100%' }); } </script>";

                return code;
            }

            public string GetHtml(string G_Id, string G_Heigh="400")
            {
                string code = "<div id='@G_Id' style='color: black; margin: 10px; width: 98 %; height: @G_Heighpx'></div>".Replace("@G_Id",G_Id).Replace("@G_Heigh",G_Heigh);
                return code;
            }
        }

        public class htmlTable
        {
            public string GetHtmlCards(List<List<string>> Rows)
            {
                string tmp = "";
                string html = @"<div class='col-md-3' style='padding: 5px;'>                         

                        <div class='card bg-secondary text-white h-100' style='padding: 10px;'>
                            <div class='card-img-top'>
                                 @1
                            </div>
    
                            <div class='card-body'>
                                <h4 class='card-title'>@0</h4>
                                <p class='card-text'>@2</p>
                                <h3>@3</h3>
                            </div>
                        </div>

                      </div>";

                //if (bg_secondary == false)
                //    html = html.Replace("bg-secondary", "");


                // Rows
                for (int i = 0; i < Rows.Count; i++)
                {
                    string htmltmp = html.Replace("@0", Rows[i][0]).Replace("@1", Rows[i][1]).Replace("@2", Rows[i][2]).Replace("@3", Rows[i][3]);
                    if (htmltmp.IndexOf("controller") > -1) htmltmp = htmltmp.Replace("bg-secondary", "bg-primary");                    
                    tmp += htmltmp;
                }

                
                return tmp;
            }

            public string GetHtml(List<List<string>> columns, List<List<string>> Rows, string Height = "400px")
            {
                string tmp = @"<div class='card bg-secondary text-white' style='height:@height'><div class='card-body'>".Replace("@height", (Convert.ToInt16(Height.Replace("px", "").Trim()) + 50).ToString() + "px");

                tmp += "<table style='margin:10px; width:100%;'>";
                tmp += "<tbody style='display: block; height: @heigh; overflow-y: auto; overflow-x: hidden;'>".Replace("@heigh", Height);

                // Column
                tmp += "<tr>";
                for (int i = 0; i < columns.Count; i++)
                    tmp += "<td style='padding: 4px; text-align: @text-alight;'>@data</td>".Replace("@data", columns[i][0]).Replace("@text-alight", columns[i][1]);
                tmp += "</tr>";


                // Rows 
                for (int i = 0; i < Rows.Count; i++)
                {
                    tmp += "<tr>";
                    for (int ii = 0; ii < Rows[i].Count; ii++)
                        tmp += "<td style='padding: 4px; text-align: @text-alight;'>@data</td>".Replace("@data", Rows[i][ii]).Replace("@text-alight", columns[ii][1]);
                    tmp += "</tr>";
                }

                tmp += "</tbody>";
                tmp += "</table>";

                tmp += "</div></div>";

                return tmp;
            }

            public string GetHtmlOp(List<List<string>> columns, List<List<string>> Rows, string Height = "400px")
            {

                string tmp = "<div class='card bg-secondary text-white scroll' style='height:@height'><div class='card-body'>".Replace("@height", (Convert.ToInt16(Height.Replace("px","").Trim())+50).ToString()+"px");
               
                tmp += "<table style='margin:10px; width:100%;'>";
                tmp += "<tbody id='myTable' style='display: block; height: @heigh; overflow-y: auto; overflow-x: hidden;'>".Replace("@heigh", Height);

                // Column
                tmp += "<tr>";
                for (int i = 0; i < columns.Count; i++)
                    tmp += "<td style='padding: 4px; text-align: @text-alight;'>@data</td>".Replace("@data", columns[i][0]).Replace("@text-alight", columns[i][1]);
                tmp += "</tr>";


                // Rows 
                for (int i = Rows.Count - 1; i >= 0; i--)
                {
                    tmp += "<tr>";
                    for (int ii = 0; ii < Rows[i].Count; ii++)
                        tmp += "<td style='padding: 4px; text-align: @text-alight;'>@data</td>".Replace("@data", Rows[i][ii]).Replace("@text-alight", columns[ii][1]);
                    tmp += "</tr>";
                }

                tmp += "</tbody>";
                tmp += "</table>";

                tmp += "</div></div>";

                return tmp;
            }

        }

        public class DateTimeLineChart
        {
            public class Record
            {
                public DateTime datetime;
                public List<double> values;
            }
            public string GetScript(string G_Id, List<List<string>> G_Titles, List<Record> G_Data)
            {
                string gscript = "<script type='text/javascript'> google.charts.load('current', {'packages':['annotationchart']}); google.charts.setOnLoadCallback(drawChart); function drawChart() { var data = new google.visualization.DataTable(); ";
                string gTitles = "data.addColumn('date', 'Date');";
                for (int i = 0; i < G_Titles.Count; i++)
                    gTitles += "data.addColumn('@type', '@caption');".Replace("@type",G_Titles[i][0]).Replace("@caption", G_Titles[i][1]);

                string gData = "data.addRows([";
                for (int i = 0; i < G_Data.Count; i++)
                {
                    gData += "[new Date(@year , @month , @day , @hour , @minute, @second)".Replace("@year", G_Data[i].datetime.Year.ToString()).Replace("@month", (G_Data[i].datetime.Month-1).ToString()).Replace("@day", G_Data[i].datetime.Day.ToString());
                    gData = gData.Replace("@hour", G_Data[i].datetime.Hour.ToString()).Replace("@minute", G_Data[i].datetime.Minute.ToString()).Replace("@second", G_Data[i].datetime.Second.ToString());
                    for (int ii = 0; ii < G_Data[i].values.Count; ii++)
                        gData += ", @value".Replace("@value", Math.Round(G_Data[i].values[ii],2).ToString().Replace(",","."));
                    gData += "],";
                }
                gData = gData.Substring(0, gData.Length - 1);
                gData += "]);";
                string gEnd = "var chart = new google.visualization.AnnotationChart(document.getElementById('@G_Id')); var options = { displayAnnotations: true }; chart.draw(data, options); } </script>".Replace("@G_Id" , G_Id);

                return gscript + gTitles + gData + gEnd;
            }

            public string GetHtml(string G_Id, string G_Heigh = "400")
            {
                string tmp = @"<div class='card' style='height:@height'>
                                    <div class='card-body'>
                                        <div id='@G_Id' style='margin:5px; width:100%; height:@G_Heighpx'></div>
                                    </div>
                              </div>";

                tmp = tmp.Replace("@height", (Convert.ToInt16(G_Heigh.Replace("px", "").Trim()) + 50).ToString() + "px").Replace("@G_Id", G_Id).Replace("@G_Heigh", G_Heigh);
                return tmp;
            }

           
        }
    }

    public class appexCharts
    {
        public class vanilla_js
        {

            public string GetLoader()
            {
                return @"
                        <script>
                            window.Promise ||
                            document.write(
                                '<script src='https://cdn.jsdelivr.net/npm/promise-polyfill@8/dist/polyfill.min.js'><\/script>'
                            )
                            window.Promise ||
                            document.write(
                                '<script src='https://cdn.jsdelivr.net/npm/eligrey-classlist-js-polyfill@1.2.20171210/classList.min.js'><\/script>'
                            )
                            window.Promise ||
                            document.write(
                                '<script src='https://cdn.jsdelivr.net/npm/findindex_polyfill_mdn'><\/script>'
                            )
                        </script>  
                        <script src='https://cdn.jsdelivr.net/npm/apexcharts'></script>";
            }
            public class Graphs
            {
                public string GetScript(string type_ = "line", string height = "280", string curve = "smooth")
                {
                    string type = type_;
                    string xaxis = "";
                    string tooltip = "";

                    if (type_.IndexOf("timeseries") > -1) { 
                        type = type_.Replace("timeseries", "");
                        xaxis = "type: 'datetime',"; 
                        tooltip = "tooltip: { x: { format: 'dd MMM yyyy HH:mm:ss' } },"; 
                    }

                    string r = @"   <script type='text/javascript'>            
                                            function ChartData(Categories, Values, ChartName, DateTime) {
                                                var options = {
                                                    series: [{ name: 'Values', data: Values }],
                                                    chart: {                                                                 
                                                                type: '@type', 
                                                                height: '@height',
                                                                animations: { 
                                                                            enabled: false, 
                                                                            easing: 'linear',
                                                                            dynamicAnimation: { speed: 1000 }
                                                                            }
                                                            },                        
                                                    dataLabels: { enabled: false },
                                                    stroke: { width: 7, curve: '@curve' },   
                                                    fill: {
                                                            type: 'gradient',
                                                            gradient: {
                                                                        shade: 'dark',
                                                                        gradientToColors: [ '#FDD835'],
                                                                        shadeIntensity: 1,
                                                                        type: 'horizontal',
                                                                        opacityFrom: 1,
                                                                        opacityTo: 1,
                                                                        stops: [0, 100, 100, 100]
                                                                        },
                                                            },
                                                    xaxis: { @xaxis categories: Categories },
                                                    @tooltip
                                                };
                                                var chart = new ApexCharts(document.querySelector('#' + ChartName), options);
                                                chart.render();
                                            }
                                    </script>";

                    r = r.Replace("@type", type);
                    r = r.Replace("@height", height);
                    r = r.Replace("@xaxis", xaxis);
                    r = r.Replace("@tooltip", tooltip);
                    r = r.Replace("@curve", curve);
                    return r;
                }
            }

            #region "Old fashion"
            public class TimeLine
            {
                public string GetScript(string type = "line", string height = "180")
                {
                    return @"<script>
                                function ChartData(Categories, Values, ChartName, DateTime) {

                                    var options = {
                                        series: [{
                                            name: 'Value',
                                            data: Values
                                        }],
                                        chart: {
                                            height: @height,
                                            type: '@type',
                                            animations: {
                                                        enabled: false,
                                                        easing: 'linear',
                                                        dynamicAnimation: {
                                                          speed: 1000
                                                        }
                                            }
                                        },                                        
                                        dataLabels: {
                                            enabled: false
                                        },
                                        stroke: {
                                                width: 7,
                                                curve: 'smooth'
                                            },
                                        fill: {
                                          type: 'gradient',
                                          gradient: {
                                            shade: 'dark',
                                            gradientToColors: [ '#FDD835'],
                                            shadeIntensity: 1,
                                            type: 'horizontal',
                                            opacityFrom: 1,
                                            opacityTo: 1,
                                            stops: [0, 100, 100, 100]
                                          },
                                        },
                                        xaxis: {
                                            categories: Categories,
                                        },
                                        title: {
                                            text: DateTime,
                                            align: 'left'
                                        },
                                    };
                                    
                                    ChartName = '#' + ChartName;
                                    var chart = new ApexCharts(document.querySelector(ChartName), options);           
                                    chart.render();
                             }
                         </script>".Replace("@type", type).Replace("@height", height);
                }
            }
            public class Bar
            {
                public string GetScript()
                {
                    return @"<script>
                                function ChartData(Categories, Values, ChartName, DateTime) {

                                    var options = {
                                        series: [{
                                            name: 'Value',
                                            data: Values
                                        }],
                                        chart: {
                                            height: 180,
                                            type: 'bar',
                                            animations: {
                                                        enabled: false,
                                                        easing: 'linear',
                                                        dynamicAnimation: {
                                                          speed: 1000
                                                        }
                                            }
                                        },                                        
                                        dataLabels: {
                                            enabled: false
                                        },
                                        stroke: {
                                                width: 7,
                                                curve: 'smooth'
                                            },
                                        title: {
                                            text: DateTime,
                                            align: 'left'
                                        },
                                        fill: {
                                          type: 'gradient',
                                          gradient: {
                                            shade: 'dark',
                                            gradientToColors: [ '#FDD835'],
                                            shadeIntensity: 1,
                                            type: 'horizontal',
                                            opacityFrom: 1,
                                            opacityTo: 1,
                                            stops: [0, 100, 100, 100]
                                          },
                                        },
                                        xaxis: {
                                            categories: Categories,
                                        }
                                    };
                                    
                                    ChartName = '#' + ChartName;
                                    var chart = new ApexCharts(document.querySelector(ChartName), options);           
                                    chart.render();
                             }
                         </script>";
                }
            }
            public class TimeSeriesLine
            {
                public string GetScript(List<googleGraphs.DateTimeLineChart.Record> a, List<List<string>> titles)
                {

                    string r= @"

<script type='text/javascript'>
            function showBar(divName, vals, lebs) {
            var options = {
                series: vals,
                chart: {
                    height: 350,
                    type: 'line',
                },
                plotOptions: {
                    bar: {
                        columnWidth: '50%',
                        endingShape: 'rounded'
                    }
                },
                dataLabels: {
                    enabled: false
                },
                stroke: {
					width: 5,
                    curve: 'stepline'
                },

                grid: {
                    row: {
                        colors: ['#fff', '#f2f2f2']
                    }
                },
                xaxis: {
                    labels: {
                        rotate: -45
					},
                    type: 'datetime',
                    categories: lebs,
                    tickPlacement: 'on'
				},
                tooltip: {
                          x: {
                            format: 'dd MMM yyyy HH:mm:ss'
                          }
                        },
                fill: {
                    type: 'gradient',
                    gradient: {
                        shade: 'light',
                        type: ""horizontal"",
                        shadeIntensity: 0.25,
                        gradientToColors: undefined,
                        inverseColors: true,
                        opacityFrom: 0.85,
                        opacityTo: 0.85,
                        stops:[50, 0, 100]
                    },
                }
        };
        var chart = new ApexCharts(document.querySelector(""#"" + divName), options);
        chart.render();
                }

                    ";

                    return r + GetData(a, titles);

                }


                private string GetData(List<googleGraphs.DateTimeLineChart.Record> a, List<List<string>> titles)
                {
                    string r = @"showBar(""barGlobal"", [ @Cols ], [ @Labels ]); </script>";
                    string Col = "{ name: '@name', data:[ @data ] }";
                    string Cols = "";
                    string Labels = "";

                    if (a[0].values.Count > -1)
                    {
                        for (int x = 0; x < a[0].values.Count; x++)
                        {
                            string data = "";
                            string name = titles[x][1];
                            for (int i = 0; i < a.Count; i++)
                            {
                                data += a[i].values[x].ToString().Replace(",", ".");
                                if (i < a.Count - 1) data += ",";
                                if (x == 0)
                                {
                                    //Labels += "new Date(" + a[i].datetime.ToString("yyyy") + "," + a[i].datetime.ToString("MM") + "," + a[i].datetime.ToString("dd") + "," + a[i].datetime.ToString("HH") + "," + a[i].datetime.ToString("mm") + "," + a[i].datetime.ToString("ss") + ").getTime()";
                                    //Labels += @"""" + a[i].datetime.ToString("yyyy") + "-" + a[i].datetime.ToString("MM") + "-" + a[i].datetime.ToString("dd") + "T" + a[i].datetime.ToString("HH") + ":" + a[i].datetime.ToString("mm") + ":" + a[i].datetime.ToString("ss") + @"""";
                                    DateTime tmp = a[i].datetime;
                                    Labels += @"""" + tmp.ToString("yyyy") + "-" + tmp.ToString("MM") + "-" + tmp.ToString("dd") + "T" + tmp.ToString("HH") + ":" + tmp.ToString("mm") + ":" + tmp.ToString("ss") + @"Z""";
                                    if (i < a.Count - 1) Labels += ",";
                                }
                            }
                            Cols += Col.Replace("@name", name).Replace("@data", data);
                            if (x < a[0].values.Count - 1) Cols += ",";

                        }
                    }

                    r = r.Replace("@Cols", Cols).Replace("@Labels", Labels);
                    return r;
                }
            }           
            public class rangeCompairBar
            {
                public string GetScript(List<List<string>> data)
                {
                    string tmp = @"
    <script>  
        var options = {
            series: [{
				data: [
					@data
				]
            }],
            chart: {
                type: 'rangeBar',
                height: 350,
                toolbar: { show: true },
                tooltip: { x: { show: true } }, 
            },
            plotOptions: {
                bar: {
                    horizontal: false
                }
            },
            dataLabels: {
                enabled: false
            }
        };
        var chart = new ApexCharts(document.querySelector('#compair'), options);
        chart.render();
    </script>
                    ";

                    string datarec = "{ x: @title, y: [@from, @to] }";
                    string datarecs = "";

                    for (int i = 0; i < data.Count; i++)
                    {
                        datarecs += datarec.Replace("@title", data[i][0]).Replace("@from", data[i][1]).Replace("@to", data[i][3]);
                        if (i < data.Count - 1) datarecs += ",";
                    }
                    tmp = tmp.Replace("@data", datarecs);

                    return tmp;
                }
            }
            #endregion
        }
    }

    public class gauge
    {
        public string GetLoader()
        {
            return @" <link href='/Content/gauge.css' rel='stylesheet'/>
                      <script type='text/jscript' src='/Content/gauge.js'></script >";
        }

        public string GetScript()
        {
            return @"
             <script>
                  function NGauge(gName, gValue, minvalue, maxvalue, greenFrom, redFrom) {
                    var myGauge = new Gauge(document.getElementById(gName));
                    myGauge.minValue = minvalue
                    myGauge.maxValue = maxvalue
                    var opts = {
                          staticZones: [
                              { strokeStyle: 'yellow', min: myGauge.minValue, max: greenFrom },
                              { strokeStyle: 'green', min: greenFrom, max: redFrom },
                              { strokeStyle: 'red', min: redFrom, max: myGauge.maxValue }
                          ]
                     };
                    myGauge.set(gValue);
                    myGauge.setOptions(opts);
                    if(gValue.toString() != '-99999')
                         document.getElementById(gName + '_title').innerHTML = '<h4>' + gValue.toString() + '</h4>';
                    else
                         document.getElementById(gName + '_title').innerHTML = '<h4>Not Found</h4>';
                  }
             </script>
            ";           
        }

        public string GetHtml(string G_Controller, string G_Sensor,  string G_Id,  string sxol = "", string c = "", string cDesc = "", string s = "", string sDesc = "", string f = "", string l = "", string lChange = "", string lSend = "", string G_Caption="")
        {
            if (G_Caption.Equals("Value")) G_Caption = "";

            return @"<div class='col-md-4' style='padding: 5px;'>                         

                        <div class='card bg-secondary text-white h-100' style='padding: 5px;'>
                            <div class='row card-img-top' style='padding-top: 10px;'>
                                <div class='col-md-6'>
                                    @sxol &nbsp; @G_Controller 
                                    <h4 style='padding: 15px;'>@G_Sensor</h4>
                                    <span style='padding: 15px;'>@caption</span>
                                </div>
                                <div class='col-md-6'>
                                    <div class='gauge'>
                                        <canvas id='@G_Id' class='gauge-preview'></canvas>
                                        <p id='@G_Id_title' class='gauge-value'></p>
                                    </div> 
                                </div>
                            </div>
    

                            <div class='card-body'>
                                <div class='row'>
                                    <div class='col-md-8'><small>@lSend<br><span style='color:black'>@lChange</span></small></div>
                                    <div class='col-md-2'></div>
                                    <div class='col-md-2'><a href='#' onclick=""showSensorStat('@c', '@cDesc', '@s', '@sDesc', '@f', '@l')""><img src='/images/statistics.png' style='width: 30px;'></a></div>
                                </div>
                            </div>
                        </div>

                      </div>".Replace("@caption", G_Caption).Replace("@cDesc", cDesc).Replace("@sDesc", sDesc).Replace("@G_Sensor", G_Sensor).Replace("@G_Controller", G_Controller).Replace("@G_Id", G_Id).Replace("@sxol", sxol).Replace("@c", c).Replace("@s", s).Replace("@lChange", lChange).Replace("@lSend", lSend).Replace("@f", f).Replace("@l", l);
        }

    }

    public class ImageHandler
    {
        private string _bitmapPath;
        private Bitmap _currentBitmap;
        private Bitmap _bitmapbeforeProcessing;
        private Bitmap _bitmapPrevCropArea;

        public ImageHandler()
        {

        }

       
        public void ByteArrayToCurrentBitmap(Byte[] CB)
        {
            Image img = new bhtaFramework().byteArrayToImage(CB);
            _currentBitmap = new Bitmap(img);
        }

        public Byte[] CurrentBitmapToByteArray()
        {
            Image img = (Image)_currentBitmap;
            Byte[] ba = new bhtaFramework().imageToByteArray((Image)img);
            return ba;
        }
    

        public Bitmap CurrentBitmap
        {
            get
            {
                if (_currentBitmap == null)
                    _currentBitmap = new Bitmap(1, 1);
                return _currentBitmap;
            }
            set { _currentBitmap = value; }
        }

        public Bitmap BitmapBeforeProcessing
        {
            get { return _bitmapbeforeProcessing; }
            set { _bitmapbeforeProcessing = value; }
        }

        public string BitmapPath
        {
            get { return _bitmapPath; }
            set { _bitmapPath = value; }
        }

        public enum ColorFilterTypes
        {
            Red,
            Green,
            Blue
        };

        public void ResetBitmap()
        {
            if (_currentBitmap != null && _bitmapbeforeProcessing != null)
            {
                Bitmap temp = (Bitmap)_currentBitmap.Clone();
                _currentBitmap = (Bitmap)_bitmapbeforeProcessing.Clone();
                _bitmapbeforeProcessing = (Bitmap)temp.Clone();
            }
        }

        public void SaveBitmap(string saveFilePath)
        {
            _bitmapPath = saveFilePath;
            if (System.IO.File.Exists(saveFilePath))
                System.IO.File.Delete(saveFilePath);
            _currentBitmap.Save(saveFilePath);
        }

        public void ClearImage()
        {
            _currentBitmap = new Bitmap(1, 1);
        }

        public void RestorePrevious()
        {
            _bitmapbeforeProcessing = _currentBitmap;
        }

        public void SetColorFilter(ColorFilterTypes colorFilterType)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int nPixelR = 0;
                    int nPixelG = 0;
                    int nPixelB = 0;
                    if (colorFilterType == ColorFilterTypes.Red)
                    {
                        nPixelR = c.R;
                        nPixelG = c.G - 255;
                        nPixelB = c.B - 255;
                    }
                    else if (colorFilterType == ColorFilterTypes.Green)
                    {
                        nPixelR = c.R - 255;
                        nPixelG = c.G;
                        nPixelB = c.B - 255;
                    }
                    else if (colorFilterType == ColorFilterTypes.Blue)
                    {
                        nPixelR = c.R - 255;
                        nPixelG = c.G - 255;
                        nPixelB = c.B;
                    }

                    nPixelR = Math.Max(nPixelR, 0);
                    nPixelR = Math.Min(255, nPixelR);

                    nPixelG = Math.Max(nPixelG, 0);
                    nPixelG = Math.Min(255, nPixelG);

                    nPixelB = Math.Max(nPixelB, 0);
                    nPixelB = Math.Min(255, nPixelB);

                    bmap.SetPixel(i, j, Color.FromArgb((byte)nPixelR, (byte)nPixelG, (byte)nPixelB));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void SetGamma(double red, double green, double blue)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            byte[] redGamma = CreateGammaArray(red);
            byte[] greenGamma = CreateGammaArray(green);
            byte[] blueGamma = CreateGammaArray(blue);
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j, Color.FromArgb(redGamma[c.R], greenGamma[c.G], blueGamma[c.B]));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        private byte[] CreateGammaArray(double color)
        {
            byte[] gammaArray = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                gammaArray[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / color)) + 0.5));
            }
            return gammaArray;
        }

        public void SetBrightness(int brightness)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    bmap.SetPixel(i, j, Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void SetContrast(double contrast)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmap.SetPixel(i, j, Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void SetGrayscale()
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);

                    bmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void SetInvert()
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void Resize(int newWidth, int newHeight)
        {
            if (newWidth != 0 && newHeight != 0)
            {
                Bitmap temp = (Bitmap)_currentBitmap;
                Bitmap bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                double nWidthFactor = (double)temp.Width / (double)newWidth;
                double nHeightFactor = (double)temp.Height / (double)newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1 = new Color();
                Color color2 = new Color();
                Color color3 = new Color();
                Color color4 = new Color();
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (int x = 0; x < bmap.Width; ++x)
                {
                    for (int y = 0; y < bmap.Height; ++y)
                    {

                        fr_x = (int)Math.Floor(x * nWidthFactor);
                        fr_y = (int)Math.Floor(y * nHeightFactor);
                        cx = fr_x + 1;
                        if (cx >= temp.Width) cx = fr_x;
                        cy = fr_y + 1;
                        if (cy >= temp.Height) cy = fr_y;
                        fx = x * nWidthFactor - fr_x;
                        fy = y * nHeightFactor - fr_y;
                        nx = 1.0 - fx;
                        ny = 1.0 - fy;

                        color1 = temp.GetPixel(fr_x, fr_y);
                        color2 = temp.GetPixel(cx, fr_y);
                        color3 = temp.GetPixel(fr_x, cy);
                        color4 = temp.GetPixel(cx, cy);

                        // Blue
                        bp1 = (byte)(nx * color1.B + fx * color2.B);

                        bp2 = (byte)(nx * color3.B + fx * color4.B);

                        nBlue = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Green
                        bp1 = (byte)(nx * color1.G + fx * color2.G);

                        bp2 = (byte)(nx * color3.G + fx * color4.G);

                        nGreen = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        // Red
                        bp1 = (byte)(nx * color1.R + fx * color2.R);

                        bp2 = (byte)(nx * color3.R + fx * color4.R);

                        nRed = (byte)(ny * (double)(bp1) + fy * (double)(bp2));

                        bmap.SetPixel(x, y, System.Drawing.Color.FromArgb(255, nRed, nGreen, nBlue));
                    }
                }
                _currentBitmap = (Bitmap)bmap.Clone();
            }
        }

        public void RotateFlip(RotateFlipType rotateFlipType)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            bmap.RotateFlip(rotateFlipType);
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void Crop(int xPosition, int yPosition, int width, int height)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            if (xPosition + width > _currentBitmap.Width)
                width = _currentBitmap.Width - xPosition;
            if (yPosition + height > _currentBitmap.Height)
                height = _currentBitmap.Height - yPosition;
            Rectangle rect = new Rectangle(xPosition, yPosition, width, height);
            _currentBitmap = (Bitmap)bmap.Clone(rect, bmap.PixelFormat);
        }

        public void DrawOutCropArea(int xPosition, int yPosition, int width, int height)
        {
            _bitmapPrevCropArea = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)_bitmapPrevCropArea.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            Brush cBrush = new Pen(Color.FromArgb(150, Color.White)).Brush;
            Rectangle rect1 = new Rectangle(0, 0, _currentBitmap.Width, yPosition);
            Rectangle rect2 = new Rectangle(0, yPosition, xPosition, height);
            Rectangle rect3 = new Rectangle(0, (yPosition + height), _currentBitmap.Width, _currentBitmap.Height);
            Rectangle rect4 = new Rectangle((xPosition + width), yPosition, (_currentBitmap.Width - xPosition - width), height);
            gr.FillRectangle(cBrush, rect1);
            gr.FillRectangle(cBrush, rect2);
            gr.FillRectangle(cBrush, rect3);
            gr.FillRectangle(cBrush, rect4);
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void RemoveCropAreaDraw()
        {
            _currentBitmap = (Bitmap)_bitmapPrevCropArea.Clone();
        }

        public void InsertText(string text, int xPosition, int yPosition, string fontName, float fontSize, string fontStyle, string colorName1, string colorName2)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            if (string.IsNullOrEmpty(fontName))
                fontName = "Times New Roman";
            if (fontSize.Equals(null))
                fontSize = 10.0F;
            Font font = new Font(fontName, fontSize);
            if (!string.IsNullOrEmpty(fontStyle))
            {
                FontStyle fStyle = FontStyle.Regular;
                switch (fontStyle.ToLower())
                {
                    case "bold":
                        fStyle = FontStyle.Bold;
                        break;
                    case "italic":
                        fStyle = FontStyle.Italic;
                        break;
                    case "underline":
                        fStyle = FontStyle.Underline;
                        break;
                    case "strikeout":
                        fStyle = FontStyle.Strikeout;
                        break;

                }
                font = new Font(fontName, fontSize, fStyle);
            }
            if (string.IsNullOrEmpty(colorName1))
                colorName1 = "Black";
            if (string.IsNullOrEmpty(colorName2))
                colorName2 = colorName1;
            Color color1 = Color.FromName(colorName1);
            Color color2 = Color.FromName(colorName2);
            int gW = (int)(text.Length * fontSize);
            gW = gW == 0 ? 10 : gW;
            LinearGradientBrush LGBrush = new LinearGradientBrush(new Rectangle(0, 0, gW, (int)fontSize), color1, color2, LinearGradientMode.Vertical);
            gr.DrawString(text, font, LGBrush, xPosition, yPosition);
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void InsertImage(string imagePath, int xPosition, int yPosition)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            if (!string.IsNullOrEmpty(imagePath))
            {
                Bitmap i_bitmap = (Bitmap)Bitmap.FromFile(imagePath);
                Rectangle rect = new Rectangle(xPosition, yPosition, i_bitmap.Width, i_bitmap.Height);
                gr.DrawImage(i_bitmap, rect);
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }
        public void InsertImage(Image imageImage, int xPosition, int yPosition)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            if (imageImage.ToString().Length > 1)
            {
                Bitmap i_bitmap = new Bitmap(imageImage);
                Rectangle rect = new Rectangle(xPosition, yPosition, i_bitmap.Width, i_bitmap.Height);
                gr.DrawImage(i_bitmap, rect);
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }
        public void InsertImage(Byte[] imageBytes, int xPosition, int yPosition)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            if (imageBytes.Length > 1)
            {
                Image img = new bhtaFramework().byteArrayToImage(imageBytes);
                Bitmap i_bitmap = new Bitmap(img);
                Rectangle rect = new Rectangle(xPosition, yPosition, i_bitmap.Width, i_bitmap.Height);
                gr.DrawImage(i_bitmap, rect);
            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void InsertShape(string shapeType, int xPosition, int yPosition, int width, int height, string colorName)
        {
            Bitmap temp = (Bitmap)_currentBitmap;
            Bitmap bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            if (string.IsNullOrEmpty(colorName))
                colorName = "Black";
            Pen pen = new Pen(Color.FromName(colorName));
            switch (shapeType.ToLower())
            {
                case "filledellipse":
                    gr.FillEllipse(pen.Brush, xPosition, yPosition, width, height);
                    break;
                case "filledrectangle":
                    gr.FillRectangle(pen.Brush, xPosition, yPosition, width, height);                                       
                    break;
                case "ellipse":
                    gr.DrawEllipse(pen, xPosition, yPosition, width, height);
                    break;
                case "rectangle":
                default:
                    gr.DrawRectangle(pen, xPosition, yPosition, width, height);
                    break;

            }
            _currentBitmap = (Bitmap)bmap.Clone();
        }
       
    }


namespace ScreenShot
    {
        public class ScreenCapture
        {
            public Image CaptureScreen()
            {
                return CaptureWindow(User32.GetDesktopWindow());
            }
            public Image CaptureWindow(IntPtr handle)
            {
                IntPtr hdcSrc = User32.GetWindowDC(handle);
                User32.RECT windowRect = new User32.RECT();
                User32.GetWindowRect(handle, ref windowRect);
                int width = windowRect.right - windowRect.left;
                int height = windowRect.bottom - windowRect.top;
                IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
                IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
                IntPtr hOld = GDI32.SelectObject(hdcDest, hBitmap);
                GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
                GDI32.SelectObject(hdcDest, hOld);
                GDI32.DeleteDC(hdcDest);
                User32.ReleaseDC(handle, hdcSrc);
                Image img = Image.FromHbitmap(hBitmap);
                GDI32.DeleteObject(hBitmap);
                return img;
            }
            public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
            {
                Image img = CaptureWindow(handle);
                img.Save(filename, format);
            }
            public void CaptureScreenToFile(string filename, ImageFormat format)
            {
                Image img = CaptureScreen();
                img.Save(filename, format);
            }
            private class GDI32
            {

                public const int SRCCOPY = 0x00CC0020;
                [DllImport("gdi32.dll")]
                public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                    int nWidth, int nHeight, IntPtr hObjectSource,
                    int nXSrc, int nYSrc, int dwRop);
                [DllImport("gdi32.dll")]
                public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                    int nHeight);
                [DllImport("gdi32.dll")]
                public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
                [DllImport("gdi32.dll")]
                public static extern bool DeleteDC(IntPtr hDC);
                [DllImport("gdi32.dll")]
                public static extern bool DeleteObject(IntPtr hObject);
                [DllImport("gdi32.dll")]
                public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
            }

            private class User32
            {
                [StructLayout(LayoutKind.Sequential)]
                public struct RECT
                {
                    public int left;
                    public int top;
                    public int right;
                    public int bottom;
                }
                [DllImport("user32.dll")]
                public static extern IntPtr GetDesktopWindow();
                [DllImport("user32.dll")]
                public static extern IntPtr GetWindowDC(IntPtr hWnd);
                [DllImport("user32.dll")]
                public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
                [DllImport("user32.dll")]
                public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
            }
        }
    }



}
