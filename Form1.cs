using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XML_Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            

            createDir(@"D:\test2");

            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\test2.xml");
            ArrayList list = new ArrayList();
            ArrayList list1 = new ArrayList();
            XmlNode idNodes = doc.SelectSingleNode("book");
            foreach (XmlNode node1 in idNodes.ChildNodes)
            {
                list.Add(node1.InnerText);
                list1.Add(node1);
                string f = node1.LocalName;
            }
            
            string filePath = @"D:\test2.xml";

            DataTable dt2 = new DataTable("book");

            dt2.Columns.Add("title", typeof(System.String));

            dt2.Columns.Add("author", typeof(System.String));

            dt2.Columns.Add("publisher", typeof(System.String));
            dt2.Columns.Add("price", typeof(System.String));

            //dt2.Columns.Add("Student_DOB", typeof(System.String));

            //dt2.Columns.Add("Gender", typeof(System.String));
            dt2.ReadXml(filePath);


            

            DataTable dt = new DataTable("Table");
            dt.Clear();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Marks", typeof(string));
            dt.Columns.Add("roll", typeof(decimal));
            dt.Columns.Add("subject", typeof(double));
            dt.Columns.Add("class", typeof(Int32));
            dt.Columns.Add("section", typeof(string));


            DataRow _ravi = dt.NewRow();
            _ravi["Name"] = "ravi";
            _ravi["Marks"] = "500";
            _ravi["roll"] = "1001.1";
            _ravi["subject"] = "10.23";
            _ravi["class"] = "5";
            _ravi["section"] = "A";

            dt.Rows.Add(_ravi);

            DataRow _ravi1 = dt.NewRow();
            _ravi1["Name"] = "ravi";
            _ravi1["Marks"] = "500";
            _ravi1["roll"] = "1001";
            _ravi1["subject"] = "20.23";
            _ravi1["class"] = "5";
            _ravi1["section"] = "A";

            dt.Rows.Add(_ravi1);

            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    string f = dt.Columns[i].DataType.Name;
            //    string temp2 = dt.Columns[i].ColumnName.ToString();

            //}
            ConvertDatatableToXML(dt);
        }

        public static void createDir(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
            {
                Directory.CreateDirectory(path);
            }
        }

        // By using this method we can convert datatable to xml
        public string ConvertDatatableToXML(DataTable dt)
        {
            MemoryStream str = new MemoryStream();
            dt.WriteXml(str, true);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlstr);
            doc.Save(@"D:\test.xml"); 
            return (xmlstr);
        }

        public DataTable ReadXML(string file)
        {
            //create the DataTable that will hold the data
            DataTable table = new DataTable(@"D:\test2.xml");
            try
            {
                //open the file using a Stream
                using (Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    //create the table with the appropriate column names
                    table.Columns.Add("title", typeof(string));
                    table.Columns.Add("author", typeof(int));
                    table.Columns.Add("publisher", typeof(string));
                    table.Columns.Add("price", typeof(string));
                   
                    //use ReadXml to read the XML stream
                    table.ReadXml(stream);

                    //return the results
                    return table;
                }
            }
            catch (Exception ex)
            {
                return table;
            }
        }
    }
}
