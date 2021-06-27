using Newtonsoft.Json.Converters;

namespace Infrastructure.Data
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "dd-MM-yy";
        }
    }
}