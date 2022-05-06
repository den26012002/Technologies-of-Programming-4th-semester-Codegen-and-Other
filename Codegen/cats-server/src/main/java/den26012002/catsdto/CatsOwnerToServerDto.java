package den26012002.catsdto;

import den26012002.catsentities.Cat;
import den26012002.catsentities.DateTime;

import java.util.ArrayList;
import java.util.GregorianCalendar;

public class CatsOwnerToServerDto {
    private String _name;
    private DateTime _dateOfBirth;

    public CatsOwnerToServerDto(String name, DateTime dateOfBirth)
    {
        _name = name;
        _dateOfBirth = dateOfBirth;
    }

    public String getName()
    {
        return _name;
    }

    public DateTime getDateOfBirth()
    {
        return _dateOfBirth;
    }
}
