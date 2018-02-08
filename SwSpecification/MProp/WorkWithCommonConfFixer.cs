using System.Data;
using System.Diagnostics;
using System.Linq;

namespace SwSpecification
{
    class WorkWithCommonConfFixer
    {

        public static DataTable PropertiesForEachConf()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Конфигурация");
            dt.Columns.Add("Обозначение");
            dt.Columns.Add("Наименование");
            dt.Columns.Add("Раздел");
            dt.Columns.Add("Масса");
            dt.Columns.Add("Исполнение");

            for (int i = 0; i < EditProp.configNames?.Length; i++)
            {
                dt.Rows.Add();
                EditProp.GetProperties(EditProp.configNames[i]);
                Debug.Print(EditProp.configNames[i]);
                dt.Rows[i]["Конфигурация"] = EditProp.configNames[i];
                dt.Rows[i]["Обозначение"] = Propertiy.Designition;
                dt.Rows[i]["Наименование"] = Propertiy.Name;
                dt.Rows[i]["Масса"] = Propertiy.Weight;
                dt.Rows[i]["Раздел"] = Propertiy.Division;
                dt.Rows[i]["Исполнение"] = Propertiy._Version;
            }
            return dt;
        }

        public static void GetValuesFromGrid(DataTable dt)
        {
            string temp;
            foreach (var item in dt.AsEnumerable())
            {
                temp = item["Конфигурация"].ToString();
                Propertiy.Designition = item["Обозначение"].ToString();
                Propertiy.Name = item["Наименование"].ToString();
                Propertiy.Division = item["Раздел"].ToString();
                Propertiy.Weight = item["Масса"].ToString();
                Propertiy._Version = item["Исполнение"].ToString();
                EditProp.SetProperties(temp);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dv">Item source для заполнения грида</param>
        /// <param name="dt">Данные считанные из грида</param>
        public static bool CompareVersion(DataView dv, DataTable dt)
        {
            bool versionHasChanged = false;
            foreach (var sourceItem in dv.Table.AsEnumerable())
            {
                foreach (var readedItem in dt.AsEnumerable())
                {

                    if (sourceItem["Исполнение"].ToString() != readedItem["Исполнение"].ToString())
                    {
                        versionHasChanged = true;
                        string newDesignition = string.Empty;

                        if (sourceItem["Исполнение"].ToString() == "false")
                        {
                            newDesignition = sourceItem["Обозначение"].ToString() + "-" + sourceItem["Конфигурация"].ToString();
                        }
                        else
                        {
                            int startIndex = sourceItem["Обозначение"].ToString().Length - sourceItem["Конфигурация"].ToString().Length - 1;
                            int symbToRemove = sourceItem["Конфигурация"].ToString().Length + 1;
                            
                            newDesignition = sourceItem["Обозначение"].ToString().Remove(startIndex, symbToRemove);
                        }

                        sourceItem["Исполнение"] = newDesignition;
                    }
                }
            }
            return versionHasChanged;
        }
    }
}