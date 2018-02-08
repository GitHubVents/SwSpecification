using SolidWorks.Interop.swconst;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SwSpecification
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window
    {
        FixAllConfig window1;
        private MPropUcProfil _profilForm;

        public MainWindow()
        {
            InitializeComponent();
            SwSpecification.EditProp.GetSolidObject();
            SwSpecification.EditProp.FixPropertys();
            SwSpecification.EditProp.GetProperties(SwSpecification.EditProp.configuracione);

            if (SwSpecification.EditProp.docType == swDocumentTypes_e.swDocDRAWING)
            {
                SwSpecification.EditProp.GetPropsFromModelFromDRW();
            }
            FillControlsWithDefaultValues();
            FillForm();
        }

        private void ReadPropFromForm()
        {
            Propertiy.Designition = TxtNumber.Text;
            Propertiy.Name = DescriptionTxtBox.Text;
            Propertiy.Division = ComboBoxSection?.SelectedItem?.ToString();
            Propertiy.Letter = CboLit.SelectedItem?.ToString();
            Propertiy.Weight = TxtMass.SelectedItem?.ToString();
            Propertiy.Changing = txtChanging.Text;
            Propertiy.Notification = txtNotif.Text;
        }

        private void FillControlsWithDefaultValues()
        {
            //КОНФИГУРАЦИЯ
            CboConfig.ItemsSource = SwSpecification.EditProp.configNames;
           
            if (SwSpecification.EditProp.lockForConf == true) { CboConfig.IsEnabled = false; }

            //ЛИТЕРА
            string[] literaarray = new string[] { "", "П", "Э", "Т", "И", "О", "О1", "О2", "А", "Б" };
            CboLit.ItemsSource = literaarray;

            // CboDrawingDoc
            //string[] drDoc = { "ГК", "ЕК", "МК", "ПК", "Е3", "Е4", "Е5", "Л3", "ВС", "ВП", "ТУ", "ПМ", "ТБ", "РР", "КЕ", "ФО", "ПС", "ЗІ", "КР", "ПЕ3", "ТЗ", "СК" };
            //CboDrawingDoc.ItemsSource = drDoc;

            //РАЗДЕЛ
            ComboBoxSection.ItemsSource = SwSpecification.EditProp.razdel;

            // МАССА
            TxtMass.ItemsSource = SwSpecification.EditProp.massaValues;

            //ИСПОЛНЕНИЕ
            if (SwSpecification.EditProp.docType == swDocumentTypes_e.swDocDRAWING) { CheckBox_Version.IsEnabled = false; };

        }

        private void FillForm()
        {
            Clear();
            TxtNumber.Text = Propertiy.Designition;
            DescriptionTxtBox.Text = Propertiy.Name;
            ComboBoxSection.SelectedItem = Propertiy.Division;
            CboLit.SelectedItem = Propertiy.Letter;
            CboConfig.SelectedItem = SwSpecification.EditProp.configuracione;
            TxtMass.SelectedItem = Propertiy.Weight;
            CheckBox_Version.IsChecked = (Propertiy._Version == "1") ? true : false;
            txtNotif.Text = Propertiy.Notification;
            txtChanging.Text = Propertiy.Changing;
        }


        private void Clear()
        {
            TxtNumber.Text = "";
            DescriptionTxtBox.Text = "";
            ComboBoxSection.SelectedItem = "";
            CboLit.SelectedItem = "";
            TxtMass.Text = "";
            CboConfig.SelectedItem = "";
            CheckBox_Version.IsChecked = false;
        }
      

        private void ChkFont_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (ChkFont.IsChecked == true)
            {
                DescriptionTxtBox.FontSize = 14;
            }
            else
            {
                DescriptionTxtBox.FontSize = 18;
            }*/
        }


        private void Version_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBox_Version.IsChecked == true)
            {
                Propertiy._Version = "1";
                Propertiy.Designition += "-" + SwSpecification.EditProp.configuracione;
                TxtNumber.Text = Propertiy.Designition;
            }
            else
            {
                Propertiy._Version = "0";
                Propertiy.Designition = Propertiy.Designition.Remove(Propertiy.Designition.Length - 1 - SwSpecification.EditProp.configuracione.Length, SwSpecification.EditProp.configuracione.Length + 1);
                TxtNumber.Text = Propertiy.Designition;
            }
        }
       

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            ReadPropFromForm();
            SwSpecification.EditProp.SetProperties(CboConfig.Text);
        }
        private void ApplyAndClose_Click(object sender, RoutedEventArgs e)
        {
            Apply_Click(true, e);

            Close();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            window1 = new FixAllConfig();
            window1.ShowDialog();
        }

        private void CboConfig_DropDownClosed(object sender, EventArgs e)
        {
            SwSpecification.EditProp.configChanged = true;
            if(CboConfig.SelectedItem.ToString() != SwSpecification.EditProp.configuracione)
            {
                SwSpecification.EditProp.configuracione = CboConfig.SelectedItem.ToString();
                SwSpecification.EditProp.GetProperties(SwSpecification.EditProp.configuracione);
                FillControlsWithDefaultValues();
                FillForm();

                SwSpecification.EditProp.configChanged = false;
            }
        }

        private void DeleteProperties_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            _profilForm = new MPropUcProfil();
            _profilForm.ShowDialog();
        }
                
        private void EditProp_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void TxtMass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SwSpecification.EditProp.DefineMassaFormat(TxtMass.SelectedIndex, SwSpecification.EditProp.unitsType);
        }
    }
}