using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Xml;

namespace SwSpecification
{
    public partial class MPropUcProfil : Window
    {
        public MPropUcProfil()
        {
            InitializeComponent();
        }

        readonly string XmlPathName = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "\\SW-Complex\\Profile.xml";
        readonly string[] _colArr = { "DrawnBy", "Chkd", "TSuperv", "ExaminedBy" };


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CreateXml()
        {
            try
            {
                if (Propertiy.DevelopedBy == "" && Propertiy.ChechedBy == "" && Propertiy.TControl == "" && Propertiy.ApprovedBy == "") return;

                //System.IO.MemoryStream myMemoryStream;
                XmlTextWriter myXml = new XmlTextWriter(XmlPathName, Encoding.UTF8);
                //создаем XML
                myXml.WriteStartDocument();

                // устанавливаем параметры форматирования xml-документа
                myXml.Formatting = Formatting.Indented;

                // длина отступа
                myXml.Indentation = 2;

                // создаем элементы
                // имя тэга
                myXml.WriteStartElement("xml");

                var txtBoxArr = new[] { Propertiy.DevelopedBy, Propertiy.ChechedBy, Propertiy.TControl, Propertiy.ApprovedBy };

                for (var i = 0; i <= txtBoxArr.GetUpperBound(0); i++)
                {
                    myXml.WriteStartElement(_colArr[i]);
                    myXml.WriteString(txtBoxArr[i]);
                    myXml.WriteEndElement();
                }
                
                myXml.WriteEndElement(); // xml

                // заносим данные в myMemoryStream 
                myXml.Flush();
                myXml.Close();

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            ReadDataForm();
            CheckSwComlepFolder(); //проверять есть ли таккая папка
           
            if (File.Exists(XmlPathName) == false)
            {
                CreateXml();
            }
            else
            {
                ReadXML();
            }
            EditProp.SetProperties(EditProp.configuracione);
            Close();
        }

        private void ReadXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XmlPathName);

            var txtBoxArr = new[] { Propertiy.DevelopedBy, Propertiy.ChechedBy, Propertiy.TControl, Propertiy.ApprovedBy };

            XmlNode nodeDrawnBy = doc.SelectSingleNode("//DrawnBy");
            XmlNode nodeChkd = doc.SelectSingleNode("//Chkd");
            XmlNode nodeTSuperv = doc.SelectSingleNode("//TSuperv");
            XmlNode nodeExaminedBy = doc.SelectSingleNode("//ExaminedBy");

            if (nodeDrawnBy != null) nodeDrawnBy.InnerText = txtBoxArr[0];
            if (nodeChkd != null) nodeChkd.InnerText = txtBoxArr[1];
            if (nodeTSuperv != null) nodeTSuperv.InnerText = txtBoxArr[2];
            if (nodeExaminedBy != null) nodeExaminedBy.InnerText = txtBoxArr[3];

            doc.Save(XmlPathName);
        }


        private void GridMPropUc_Loaded(object sender, RoutedEventArgs e)
        {
            string NodeDrawnByName = String.Empty;
            string NodeChkdName = String.Empty;
            string NodeTSupervName = String.Empty;
            string NodeExaminedByName = String.Empty;

            try
            {
                TxtBoxTKontrol.IsEnabled = true;
                if (!File.Exists(XmlPathName)) return;

                var doc = new XmlDocument();
                doc.Load(XmlPathName);

                //rus
                XmlNode nodeDrawnBy = doc.SelectSingleNode("//DrawnBy");
                if (nodeDrawnBy != null) NodeDrawnByName = nodeDrawnBy.InnerText;
                XmlNode nodeChkd = doc.SelectSingleNode("//Chkd");
                if (nodeChkd != null) NodeChkdName = nodeChkd.InnerText;
                XmlNode nodeTSuperv = doc.SelectSingleNode("//TSuperv");
                if (nodeTSuperv != null) NodeTSupervName = nodeTSuperv.InnerText;
                XmlNode nodeExaminedBy = doc.SelectSingleNode("//ExaminedBy");
                if (nodeExaminedBy != null) NodeExaminedByName = nodeExaminedBy.InnerText;

                TxtBoxRazrab.Text = NodeDrawnByName;
                TxtBoxProv.Text = NodeChkdName;
                TxtBoxTKontrol.Text = NodeTSupervName;
                TxtBoxYtv.Text = NodeExaminedByName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckSwComlepFolder()
        {
            bool ex = Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + @"\SW-Complex");

            if (!ex)
            {
                DirectoryInfo di = Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + @"\SW-Complex");
            }
        }

        private void ReadDataForm()
        {
            Propertiy.DevelopedBy = TxtBoxRazrab.Text;
            Propertiy.ApprovedBy = TxtBoxYtv.Text;
            Propertiy.ChechedBy = TxtBoxProv.Text;
            Propertiy.TControl = TxtBoxTKontrol.Text;
        }
    }
}