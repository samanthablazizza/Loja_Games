namespace Loja_Games.Util;

public class DateOnlyJsonConverter : Newtonsoft.Json.Converters.IsoDateTimeConverter
{
    public DateOnlyJsonConverter()
    {
        DateTimeFormat = "yyyy-MM-dd";
    }
}
