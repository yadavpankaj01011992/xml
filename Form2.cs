using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace XML_Testing
{
    public partial class Form2 : Form
    {
        DataTable dt;
        public Form2()
        {
            InitializeComponent();

            //using (XmlWriter writer = XmlWriter.Create("D:\\test2.xml"))
            //{
            //    writer.WriteStartElement("book");
            //    writer.WriteElementString("title", "Graphics Programming using GDI+");
            //    writer.WriteElementString("author", "Mahesh Chand");
            //    writer.WriteElementString("publisher", "Addison-Wesley");
            //    writer.WriteElementString("price", "64.95");
            //    writer.WriteEndElement();
            //    writer.Flush();0
            //}  

            DataSet ds = new DataSet();
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Product_ID", Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("Product_Name", Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("product_Price", Type.GetType("System.Int32")));
            fillRows(1, "product1", 1111);
            fillRows(2, "product2", 2222);
            fillRows(3, "product3", 3333);
            fillRows(4, "product4", 4444);
            ds.Tables.Add(dt);
            ds.Tables[0].TableName = "product";
            ds.WriteXml("D:\\test3.xml");
            MessageBox.Show("Done");
        }
        private void fillRows(int pID, string pName, int pPrice)
        {
            DataRow dr;
            dr = dt.NewRow();
            dr["Product_ID"] = pID;
            dr["Product_Name"] = pName;
            dr["product_Price"] = pPrice;
            dt.Rows.Add(dr);
        } 
    }
}
