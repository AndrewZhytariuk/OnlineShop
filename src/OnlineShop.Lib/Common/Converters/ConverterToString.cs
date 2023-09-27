using System.Text;

namespace OnlineShop.Lib.Common.Converters
{
    public static class ConverterToString<T>
    {
        public static string IdsToString(IEnumerable<T> ids)
        {
            StringBuilder sbIds = new StringBuilder();

            foreach(T id in ids)
            {
                sbIds.Append(id + ".");
            }

            return sbIds.ToString();
        }
    }
}
