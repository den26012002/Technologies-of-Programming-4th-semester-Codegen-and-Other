package den26012002.catsdto;

import den26012002.catsentities.Cat;
import den26012002.catsentities.CatsOwner;
import den26012002.catsentities.Color;
import den26012002.catsentities.DateTime;

import java.util.ArrayList;
import java.util.GregorianCalendar;

public class CatToServerDto {
    private String _name;
    private DateTime _dateOfBirth;
    private Color _color;
    private int _ownerId;

    public CatToServerDto(String name, DateTime dateOfBirth, Color color, int ownerId)
    {
        _name = name;
        _dateOfBirth = dateOfBirth;
        _color = color;
        _ownerId = ownerId;
    }

    public String getName()
    {
        return _name;
    }

    public DateTime getDateOfBirth()
    {
        return _dateOfBirth;
    }

    public Color getColor()
    {
        return _color;
    }

    public int getOwnerId()
    {
        return _ownerId;
    }
}
