using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SwSpecification
{
   class EditProp
   {
        static SldWorks swApp;
        static ModelDoc2 swModel;
        public static swDocumentTypes_e docType;
        static View swView;
        static DrawingDoc drw;
        static int m;
        private static string configName = String.Empty;
        public static string[] massaValues = null;
        public static int unitsType = 0;
        public static bool configChanged = false;
        public static string[] configNames;
        public static int configIterator = 99;
        public static bool lockForConf;
        internal static string[] razdel = { "Документация", "Комплексы", "Сборочные единицы", "Детали", "Комплекты", "ЭМ-Сборочные-единицы", "ЭМ-Детали", "Материалы"};

        public static string configuracione
        {
            get { return configName; }
            set { configName = value; }
        }

        public static void GetSolidObject()
        {
            swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            swModel = swApp.ActiveDoc;
            
            // Проверка открытого документа
            if (swModel == null)
            {
                swApp.SendMsgToUser2("Откройте модель, сборку или чертеж!", (int)swMessageBoxIcon_e.swMbStop, (int)swMessageBoxBtn_e.swMbOk);

                return;
            }
            
            if (string.IsNullOrEmpty(swModel.GetPathName()))
            {
                swApp.SendMsgToUser2("Сохраните файл!", (int)swMessageBoxIcon_e.swMbStop, (int)swMessageBoxBtn_e.swMbOk);

                return;
            }

            docType = (swDocumentTypes_e)swModel.GetType();


            if (docType != swDocumentTypes_e.swDocDRAWING)
            {
                configName = swModel.GetActiveConfiguration().Name;//при первом вызове присваеваеться активная конфигурация
                EditProp.configNames = EditProp.GetAllConfigurations();
            }
            else
            {
                #region Если открыт чертеж
                
                lockForConf = true;//нельзя изменить конфигурацию на формочке

                drw = (DrawingDoc)swModel;
                // Получение первого листа
                Sheet swSheet = drw.GetCurrentSheet();

                Propertiy.Format = GetFormat(swSheet);
                Propertiy.Sheets = drw.GetSheetCount().ToString();
                Propertiy.Sheet = swSheet.GetName();
                // Узнаем имя активного листа
                string[] vSheetNames = drw.GetSheetNames();
                drw.ActivateSheet(vSheetNames[0]);
                swSheet = drw.GetCurrentSheet();
                swView = drw.GetFirstView();
                Propertiy.Scale = swView.ScaleRatio[0].ToString() + ":" + swView.ScaleRatio[1].ToString();
                
                m = 0;

                if (swSheet.CustomPropertyView == "По умолчанию" | swSheet.CustomPropertyView == "Default")
                {
                    // Получаем первый вид
                    swView = swView.GetNextView();
                }
                else
                {
                    while (swView != null)
                    {
                        if (swView.GetName2() == swSheet.CustomPropertyView)
                        {
                            m = 1;
                        }
                        swView = swView.GetNextView();
                    }
                    if (m == 0)
                    {
                        swView = drw.GetFirstView();
                        swView = swView.GetNextView();
                        swApp.SendMsgToUser2("Не удалось определить вид из свойств листа. Ипользуется первый вид.", (int)swMessageBoxIcon_e.swMbStop, (int)swMessageBoxBtn_e.swMbOk);
                    }
                }

                if (swView == null)
                {
                    swApp.SendMsgToUser2("Отсутсвует модель!", (int)swMessageBoxIcon_e.swMbStop, (int)swMessageBoxBtn_e.swMbOk);
                    // Возвращение активного листа
                    drw.ActivateSheet(Propertiy.Sheet);
                    return;
                }

                if (swView.ReferencedDocument == null)
                {
                    swApp.SendMsgToUser2("Отсутсвует модель!", (int)swMessageBoxIcon_e.swMbStop, (int)swMessageBoxBtn_e.swMbOk);
                    // Возвращение активного листа
                    drw.ActivateSheet(Propertiy.Sheet);
                    return;
                }
                #endregion 
            }
        }
        

        static CustomPropertyManager cust;
        static CustomPropertyManager cust2;

        /// <summary>
        /// Удаляет свойства, если они не в своей категории 
        /// </summary>
        public static void FixPropertys()
        {
            string ValOut;
            string ResValOut;
            bool WasResolved;

            cust = swModel.Extension.CustomPropertyManager[""];
            cust2 = swModel.Extension.CustomPropertyManager[EditProp.configuracione];
            
            cust.Delete2("Обозначение");
            cust.Delete2("Наименование");
            cust.Delete2("Наименование_ФБ");
            cust.Delete2("Number");
            cust.Delete2("RenameSWP");
            cust.Delete2("DescriptionEng");
            cust.Delete2("Сборка");
            cust.Delete2("Примечание");
            cust.Delete2("Формат");
            cust.Delete2("DrawnBy");

            cust2.Get5("Проверил", true, out ValOut, out ResValOut, out WasResolved);
            Propertiy.ChechedBy = ResValOut;
            cust2.Delete2("Проверил");
            cust.Add3("Проверил", 30, Propertiy.ChechedBy, (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);

            cust2.Get5("Утвердил", true, out ValOut, out ResValOut, out WasResolved);
            Propertiy.ApprovedBy = ResValOut;
            cust2.Delete2("Утвердил");
            cust.Add3("Утвердил", 30, ResValOut, (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);

            cust2.Get5("Техконтроль", true, out ValOut, out ResValOut, out WasResolved);
            Propertiy.TControl = ResValOut;
            cust2.Delete2("Техконтроль");
            cust.Add3("Техконтроль", 30, ResValOut, (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);

            cust2.Get5("Масса_Таблица", true, out ValOut, out ResValOut, out WasResolved);
            Propertiy.Weight = ResValOut;
            cust2.Delete2("Масса_Таблица");
            cust2.Add3("Масса", 30, ResValOut, (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);


            cust2.Delete2("CheckedBy");
            cust2.Delete2("EngineeringApproval");
            swModel.ForceRebuild3(false);
        }


        public static void GetProperties(string ConfigName)
        {
            string ValOut;
            string ResValOut;
            bool WasResolved;

            cust = swModel.Extension.CustomPropertyManager[""];
            cust2 = swModel.Extension.CustomPropertyManager[ConfigName];


            if (docType != swDocumentTypes_e.swDocDRAWING)
            {
                cust.Get5("Код документа", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.DocCode = ResValOut;
                cust.Get5("Тип документа", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.DocType = ResValOut;
                cust.Get5("Конструктор", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.DevelopedBy = ResValOut;
                cust.Get5("Проверил", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.ChechedBy = ResValOut;
                cust.Get5("Техконтроль", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.TControl = ResValOut;
                cust.Get5("Нормоконтроль", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.NControl = ResValOut;
                cust.Get5("Нач.отд.", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.NachOtd = ResValOut;
                cust.Get5("Утвердил", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.ApprovedBy = ResValOut;
                cust.Get5("Контора", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.Subvision = ResValOut;
                cust.Get5("Изменение", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.Changing = ResValOut;
                cust.Get5("N извещения", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.Notification = ResValOut;
                cust.Get5("MassaFormat", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.MassaFormat = ResValOut;
            }
            else
            {
               // Drawing
                cust.Get5("Литера", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.Letter2 = ResValOut;
                cust.Get5("Материал", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.Material = ResValOut;
                cust.Get5("Тип документа1", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.DocType1 = ResValOut;
                cust.Get5("Литера2", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.Letter2 = ResValOut;
                cust.Get5("Литера3", false, out ValOut, out ResValOut, out WasResolved);
                Propertiy.Letter3 = ResValOut;
            }

            cust2.Get5("Исполнение", false, out ValOut, out ResValOut, out WasResolved);
            Propertiy._Version = (ResValOut == String.Empty) ? "0" : ResValOut;
            cust2.Get5("Обозначение", true, out ValOut, out ResValOut, out WasResolved);
            Propertiy.Designition = ResValOut;
            cust2.Get5("Раздел", false, out ValOut, out ResValOut, out WasResolved);
            Propertiy.Division = ResValOut;
            cust2.Get5("Масса", false, out ValOut, out ResValOut, out WasResolved);
            Propertiy.Weight = ResValOut;
            cust2.Get5("Наименование", true, out ValOut, out ResValOut, out WasResolved);
            Propertiy.Name = ResValOut;
            cust2.Get5("PDMflag", true, out ValOut, out ResValOut, out WasResolved);
            Propertiy.PDMflag = ResValOut;

            AddPropertiesFromModel();
        }
       
        public static void GetPropsFromModelFromDRW()
        {
            // подтягиваем свойства из модельки в чертеж
            swModel = swView.ReferencedDocument;
            docType = (swDocumentTypes_e)swModel.GetType();
            EditProp.configuracione = swView.ReferencedConfiguration;
            EditProp.FixPropertys();
            EditProp.GetProperties(EditProp.configuracione);
            swModel = swApp.ActiveDoc; // дальше опять работаем с чертежом
            EditProp.configuracione = "";
            docType = (swDocumentTypes_e)swModel.GetType();
        }

        public static void AddPropertiesFromModel()
        {
            
            if (Propertiy.Designition == String.Empty)
            {
                GetModelName();
            }
            
            if (Propertiy.Division == String.Empty)
            {
                if (EditProp.docType == swDocumentTypes_e.swDocASSEMBLY)
                {
                    Propertiy.Division = "Сборочные еденицы";
                }
                else if (EditProp.docType == swDocumentTypes_e.swDocPART)
                {
                    Propertiy.Division = "Детали";
                }
            }
            
            massaValues = EditProp.GetModelWeight();
            if (massaValues.Length > 1)
            {
                // МАССА
                if (Propertiy.MassaFormat != String.Empty)
                {

                    switch (Propertiy.MassaFormat.Substring(1,1)) // проверяем последнюю цифру свойства MassaFormat
                    {
                        case "0":
                            Propertiy.Weight = massaValues[1].ToString();
                            break;
                        case "1":
                            Propertiy.Weight = massaValues[2].ToString();
                            break;
                        case "2":
                            Propertiy.Weight = massaValues[3].ToString();
                            break;
                        case "3":
                            Propertiy.Weight = massaValues[4].ToString();
                            break;
                        case "4":
                            Propertiy.Weight = massaValues[5].ToString();
                            break;
                    }
                }
                else
                {
                    Propertiy.Weight = massaValues[1].ToString(); 
                }
            }
        }
        public static void DefineMassaFormat(int selectedIndex, int unitsType)
        {
            int accuracyType = 0;
            switch (selectedIndex)
            {
                case 0:
                    if (unitsType == (int)MassaFormatUnits.kilo)
                    {
                        accuracyType = (int)MassaFormatAccuracy.without_ext;
                        unitsType = (int)MassaFormatUnits.grams;
                    }
                    else
                    {
                        accuracyType = (int)MassaFormatAccuracy._3_symbol_after_point;
                        unitsType = (int)MassaFormatUnits.kilo;
                    }
                    break;
                case 1:
                    accuracyType = (int)MassaFormatAccuracy.without_ext;
                    break;
                case 2:
                    accuracyType = (int)MassaFormatAccuracy._1_symbol_after_point;
                    break;
                case 3:
                    accuracyType = (int)MassaFormatAccuracy._2_symbol_after_point;
                    break;
                case 4:
                    accuracyType = (int)MassaFormatAccuracy._3_symbol_after_point;
                    break;
                default:
                    accuracyType = (int)MassaFormatAccuracy._4_symbol_after_point;
                    break;
            }

            Propertiy.MassaFormat = unitsType.ToString() + accuracyType.ToString();
        }

        public static void SetProperties(string confName)
        {

            cust = swModel.Extension.CustomPropertyManager[""];
            cust2 = swModel.Extension.CustomPropertyManager[confName];


            cust.Add3("Конструктор", 30, Propertiy.DevelopedBy, 2);
            cust.Add3("Проверил", 30, Propertiy.ChechedBy, 2);
            cust.Add3("Техконтроль", 30, Propertiy.TControl, 2);
            cust.Add3("Нормоконтроль", 30, Propertiy.NControl, 2);
            cust.Add3("Утвердил", 30, Propertiy.ApprovedBy, 2);
            cust.Add3("Контора", 30, Propertiy.Subvision, 2);

            cust.Add3("N извещения", 30, Propertiy.Notification, 2);
            cust.Add3("Изменение", 30, Propertiy.Changing, 2);
            cust.Add3("MassaFormat", 30, Propertiy.MassaFormat, 2);
            cust.Add3("Код документа", 30, Propertiy.DocCode, 2);

            if (confName != "")//  свойства для Configuration
            {
                cust2.Add3("Обозначение", 30, Propertiy.Designition, 2);
                cust2.Add3("Раздел", 30, Propertiy.Division, 2);
                cust2.Add3("Масса", 30, Propertiy.Weight, 2);
                cust2.Add3("Наименование", 30, Propertiy.Name, 2);
                cust2.Add3("Исполнение", 30, Propertiy._Version, 2);

                if (Propertiy.Division == "Материалы")
                {
                    cust2.Add3("PDMFlag", 30, "5", 2);
                }
            }
            else
            {
                if (docType != swDocumentTypes_e.swDocDRAWING)
                {
                    cust.Add3("Тип документа", 30, Propertiy.DocType, 2);
                }
                else if (docType == swDocumentTypes_e.swDocDRAWING)
                {
                    cust2.Add3("Обозначение", 30, Propertiy.Designition, 2);
                    cust2.Add3("Раздел", 30, Propertiy.Division, 2);
                    cust2.Add3("Масса", 30, Propertiy.Weight, 2);
                    cust2.Add3("Наименование", 30, Propertiy.Name, 2);

                    cust.Add3("Литера", 30, Propertiy.Letter, 2);
                    cust.Add3("Масштаб", 30, Propertiy.Scale, 2);
                    cust.Add3("Материал", 30, Propertiy.Material, 2);
                    cust.Add3("Тип документа1", 30, Propertiy.DocType1, 2);
                    cust.Add3("Литера2", 30, Propertiy.Letter2, 2);
                    cust.Add3("Литера3", 30, Propertiy.Letter3, 2);
                    cust.Add3("Раздел", 30, Propertiy.Division, 2);
                    cust.Add3("Лист", 30, Propertiy.Sheet, 2);
                    cust.Add3("Листов", 30, Propertiy.Sheets, 2);
                    cust.Add3("Формат", 30, Propertiy.Format, 2);

                    CustFromDRWToModel();
                    SetProperties(EditProp.configuracione);
                    CustFromModelToDRW();
                }
            }
            
            swModel.ForceRebuild3(false);
        }
        

        //значение обозначения из модели/чертежа
        private static void GetModelName()
        {
            string name = swModel.GetTitle();

            if (name.ToUpper().Contains(".SLD"))
            {
                if (docType == swDocumentTypes_e.swDocDRAWING)
                {
                    Propertiy.Designition = name.Remove(name.Length - 15, 15);
                }
                else
                {
                    Propertiy.Designition = name.Remove(name.Length - 7, 7);
                }
            }
            else
            {
                if (docType == swDocumentTypes_e.swDocDRAWING)
                {
                    Propertiy.Designition = name.Remove(name.Length - 7, 7);
                }
            }
        }
        public static string[] GetModelWeight()
        {
            string path = swModel.GetPathName();

            if (EditProp.configChanged  == true || EditProp.configIterator == 99)
            {
               swModel.ShowConfiguration2(EditProp.configuracione);
            }
            else 
            {
                swModel.ShowConfiguration2(EditProp.configNames[configIterator]);
                configIterator++;
            }

            int status = 99;
            double[] masProperties = swModel.Extension.GetMassProperties2(1, out status, true);
            double massa = Convert.ToDouble(masProperties?[5]); // в килограммах
            double mass = massa * 1000; //в граммах

            if (mass > 0)// если деталь имеет массу
            {
                string[] resMas = new string[7];

                string mantisa = String.Empty;
                string integerVal = String.Empty;
                string tempValue = String.Empty;

                if (mass < 1000)
                {
                    unitsType = (int)MassaFormatUnits.grams;

                    mantisa = (mass - (1* (Math.Floor(mass/ 1) * Math.Sign(mass)))).ToString();
                    integerVal = Math.Truncate(mass).ToString() + ",";

                    if (mantisa != "0")// г-кг
                    {
                        resMas[0] = massa.ToString().Substring(0, 5); // в кг с точностью 3 знака

                        resMas[1] = Math.Truncate(mass).ToString() + "  г";

                        tempValue = mantisa.Substring(2, 1);
                        resMas[2] = integerVal + tempValue; // 1 знак после запятой

                        tempValue = mantisa.Substring(2, 2);
                        resMas[3] = integerVal + tempValue; // 2 знака после запятой

                        tempValue = mantisa.Substring(2, 3);
                        resMas[4] = integerVal + tempValue; // 3 знака после запятой

                        tempValue = mantisa.Substring(2, 4);
                        resMas[5] = integerVal + tempValue; // 4 знака после запятой
                    }
                    else
                    {
                        resMas[0] = massa.ToString().Substring(0, 5); // в кг с точностью 3 знака

                        resMas[1] = Math.Truncate(mass * 1000).ToString();

                        tempValue = "0";
                        resMas[2] = integerVal + tempValue; // 1 знак после запятой

                        tempValue = "00";
                        resMas[3] = integerVal + tempValue; // 2 знака после запятой

                        tempValue = "000";
                        resMas[4] = integerVal + tempValue; // 3 знака после запятой

                        tempValue = "0000";
                        resMas[5] = integerVal + tempValue; // 4 знака после запятой
                    }
                }
                else
                {
                    unitsType = (int)MassaFormatUnits.kilo;

                    integerVal = Math.Truncate(massa).ToString() + ",";
                    mantisa = (massa - (1 * (Math.Floor(massa / 1) * Math.Sign(massa)))).ToString();

                    if (mantisa != "0") // т-кг
                    {
                        resMas[0] = Math.Truncate(mass).ToString(); // в грамах

                        resMas[1] = Math.Truncate(massa).ToString() + "  кг";

                        tempValue = mantisa.Substring(2, 1);
                        resMas[2] = integerVal + tempValue; // 1 знак после запятой

                        tempValue = mantisa.Substring(2, 2);
                        resMas[3] = integerVal + tempValue; // 2 знака после запятой

                        tempValue = mantisa.Substring(2, 3);
                        resMas[4] = integerVal + tempValue; // 3 знака после запятой

                        tempValue = mantisa.Substring(2, 4);
                        resMas[5] = integerVal + tempValue; // 4 знака после запятой

                    }
                    else
                    {
                        resMas[0] = Math.Truncate(mass).ToString(); // в грамах

                        resMas[1] = Math.Truncate(massa).ToString() + "  кг";

                        tempValue = "0";
                        resMas[2] = integerVal + tempValue; // 1 знак после запятой

                        tempValue = "00";
                        resMas[3] = integerVal + tempValue; // 1 знак после запятой

                        tempValue = "000";
                        resMas[4] = integerVal + tempValue; // 3 знака после запятой

                        tempValue = "000";
                        resMas[5] = integerVal + tempValue; // 4 знака после запятой
                    }
                }
                return resMas;
            }
            return new string[1];
        }
        public static string [] GetAllConfigurations()
        {
            string[] allNames = {};
            List<string> notDerivedConf = new List<string>();

            allNames = swModel.GetConfigurationNames();

            for (int i = 0; i < allNames.Length; i++)
            {
                Configuration swConf = swModel.GetConfigurationByName(allNames[i]);

                if (swConf.IsDerived() == false)
                {
                    notDerivedConf.Add(allNames[i]);
                }
                else
                {
                    swModel.Extension.CustomPropertyManager[allNames[i]].Add3("PDMFlag", 30, "2", 0);
                }
             }

            configNames = (string[])swModel.GetConfigurationNames();


            
            return notDerivedConf.ToArray();
        }

        public enum MassaFormatAccuracy
        {
            without_ext = 0,
            _1_symbol_after_point = 1,
            _2_symbol_after_point = 2,
            _3_symbol_after_point = 3,
            _4_symbol_after_point = 4
        }
        public enum MassaFormatUnits
        {
            grams = 1,
            kilo = 2
        }

        public static void CustFromDRWToModel()
        {
            if (docType == swDocumentTypes_e.swDocDRAWING)
            {
                swModel = swView.ReferencedDocument;
                EditProp.configuracione = swView.ReferencedConfiguration;
            }
        }

        public static void CustFromModelToDRW()
        {
            if (docType != swDocumentTypes_e.swDocDRAWING)
            {
                swModel = swApp.ActiveDoc; ;
                EditProp.configuracione = swModel.GetActiveConfiguration().Name;
            }
        }
        private static string GetFormat(Sheet swSheet)
        {
            string format = string.Empty;
            double width = 0; double height = 0;
            swSheet.GetSize(ref width, ref height);
            string y = width.ToString();
            switch (y)
            {
                case "0,841":
                    format = "A1";
                    break;
                case "0,594":
                    format = "A2";
                    break;
                case "0,42":
                    format = "A3";
                    break;
                case "0,21":
                    format = "A4";
                    break;
            }
            return format;
        }
    }
}