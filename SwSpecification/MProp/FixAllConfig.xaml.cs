using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;
using System.Windows.Input;
using System.Diagnostics;

namespace SwSpecification
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class FixAllConfig : Window
    {

        public FixAllConfig()
        {
            InitializeComponent();
            FillGrid();
        }

        DataView dv = null;

        //delegate void My(object sender, MouseButtonEventArgs e);


        delegate RoutedEvent My();
        My delegatik;

        event My myEvent;


        private void FillGrid()
        {
            EditProp.configChanged = false;
            EditProp.configIterator = 0;
            DataGridCheckBoxColumn checkVersion;
            DataGridComboBoxColumn cmbBoxCol;
            DataGridTextColumn textColumn;
           
            string[] colNames = new string[] { "Конфигурация", "Обозначение", "Наименование", "Масса" };
            foreach (var item in colNames)
            {
                textColumn = new DataGridTextColumn();
                textColumn.Header = item;
                textColumn.Binding = new Binding(item);
                if (item == "Конфигурация") { textColumn.IsReadOnly = true; }

                dataGrid.Columns.Add(textColumn);
            }

            // COMBOBOX
            cmbBoxCol = new DataGridComboBoxColumn();
            cmbBoxCol.Header = "Раздел";
            cmbBoxCol.ItemsSource = EditProp.razdel;
            cmbBoxCol.SelectedItemBinding = new Binding("Раздел");
            dataGrid.Columns.Add(cmbBoxCol);
            

            //CHECHBOX
            checkVersion = new DataGridCheckBoxColumn();
            checkVersion.Header = "Исполнение";
            checkVersion.Binding = new Binding("Исполнение");
            dataGrid.Columns.Add(checkVersion);
            
            
            /*delegatik = new My(MakeChangesToGrid);
            
            EventSetter setter = new EventSetter();
            
            setter.Event = TapEvent;
            
            setter.Handler = delegatik;
            Style style = checkVersion.CellStyle;
            style.Setters.Add(setter);
           */


            dv = WorkWithCommonConfFixer.PropertiesForEachConf().AsDataView();
            dataGrid.ItemsSource = dv;
        }

        

        private void SaveChangesOnGrid_Click(object sender, RoutedEventArgs e)
        {
            DataView dt = (DataView)dataGrid.ItemsSource;
            WorkWithCommonConfFixer.GetValuesFromGrid(dt.Table);
        }
        private void UndoChanges_Click(object sender, RoutedEventArgs e)
        {
            DataView dt = (DataView)dataGrid.ItemsSource;
            WorkWithCommonConfFixer.GetValuesFromGrid(dt.Table);
            this.Close();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void dataGrid_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("I'm doing MouseButtonEventArgs in row");
        }


        private void MakeChangesToGrid(object sender, MouseButtonEventArgs e)
        {
            DataView dt = (DataView)dataGrid.ItemsSource;

            if (WorkWithCommonConfFixer.CompareVersion(dv, dt.Table))
            {
                dataGrid.ItemsSource = dv;
            }

            System.Diagnostics.Debug.WriteLine("I'm awesome guy");
        }

        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent("Tap", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FixAllConfig));

        public event RoutedEventHandler Tap
        {
            add { AddHandler(TapEvent, value); }
            remove { RemoveHandler(TapEvent, value); }
        }
        void RaiseTapEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(FixAllConfig.TapEvent);
            RaiseEvent(newEventArgs);
        }

    }
}