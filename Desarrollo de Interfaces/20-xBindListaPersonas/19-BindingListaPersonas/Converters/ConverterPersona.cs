using _19_BindingListaPersonas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _19_BindingListaPersonas.Converters
{
    public class ConverterPersona:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Persona persona = null;
            try
            {
                persona = (Persona) value;               
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);              
            }
            return persona;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }


    }
}
