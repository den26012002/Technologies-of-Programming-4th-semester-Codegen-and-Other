package den26012002.catsentities;

import java.util.ArrayList;
import java.util.GregorianCalendar;

public class Cat {
    private int _id;
    private String _name;
    private DateTime _dateOfBirth;
    private Color _color;
    private int _ownerId;
    private ArrayList<Integer> _friendIds;

    public Cat(
            int id,
            String name,
            DateTime dateOfBirth,
            Color color,
            int ownerId)
    {
        _id = id;
        _name = name;
        _dateOfBirth = dateOfBirth;
        _color = color;
        _ownerId = ownerId;
        _friendIds = new ArrayList<>();
    }

    public int getId() {
        return _id;
    }

    public String getName() {
        return _name;
    }

    public DateTime getDateOfBirth() {
        return _dateOfBirth;
    }

    public Color getColor() {
        return _color;
    }

    public int getOwnerId() {
        return _ownerId;
    }

    public ArrayList<Integer> getFriends() {
        return _friendIds;
    }

    public void addFriend(Integer otherId) {
        _friendIds.add(otherId);
    }
}
