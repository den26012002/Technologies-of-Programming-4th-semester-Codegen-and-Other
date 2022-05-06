package den26012002.catsentities;

public class DateTime {
    private int _day;
    private int _month;
    private int _year;

    public DateTime(int day, int month, int year)
    {
        _day = day;
        _month = month;
        _year = year;
    }

    public int getDay()
    {
        return _day;
    }

    public int getMonth()
    {
        return _month;
    }

    public int getYear()
    {
        return _year;
    }
}
