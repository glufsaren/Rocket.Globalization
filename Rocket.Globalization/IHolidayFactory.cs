namespace Rocket.Globalization
{
    public interface IHolidayFactory
    {
        IHolidayFactory Create(Country country);
    }
}