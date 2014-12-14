namespace Rocket.Globalization
{
    public class Holiday
    {
        public static object For(Country country)
        {
            return null;
        }

        public static object Swedish
        {
            get
            {
                return For(Country.Sweden);
            }
        }
    }
}