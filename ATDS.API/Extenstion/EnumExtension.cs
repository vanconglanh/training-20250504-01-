namespace ATDS.API.Extenstion
{
    public static class EnumExtensions
    {
        public static string Value(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue).ToString();
        }
    }

}
