using System;
using System.Windows.Forms;
using Aurora.Forms.CustomDataGrid;

namespace Aurora.Forms
{
    /// <summary>
    ///     Comboboxes filled with the Values and Texts from a given enumeration
    /// </summary>
    /// <typeparam name="T">enumerationtype to be used for this combobox</typeparam>
    public class EnumComboBox<T> : ComboBox
    {
        /// <summary>
        ///     init the Displaymember and Datasource with the values from the enumeration
        /// </summary>
        public EnumComboBox()
        {
            DisplayMember = "Text";
            DataSource = Enumerations;
        }

        /// <summary>
        ///     Property to access the enumerationvalues
        /// </summary>
        public static ComboTypes Enumerations
        {
            get { return GetComboTypes(); }
        }

        /// <summary>
        ///     Retreive the enumerationvalues from the enumeration given
        /// </summary>
        /// <typeparam name="T">Enumeration to get the data from</typeparam>
        /// <returns>Datatable derivate to store the enumerationdata</returns>
        private static ComboTypes GetComboTypes()
        {
            String[] EnumNames = Enum.GetNames(typeof (T));
            Array EnumValues = Enum.GetValues(typeof (T));

            object[][] EnumElements = new object[EnumNames.Length][];
            for (int EnumCounter = 0; EnumCounter < EnumNames.Length; EnumCounter++)
            {
                EnumElements[EnumCounter] = new object[] {EnumValues.GetValue(EnumCounter), EnumNames[EnumCounter]};
            }

            return (new ComboTypes(EnumElements));
        }
    }
}
