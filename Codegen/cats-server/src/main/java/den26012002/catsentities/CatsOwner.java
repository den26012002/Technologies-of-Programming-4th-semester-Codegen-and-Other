package den26012002.catsentities;

import java.util.ArrayList;
import java.util.GregorianCalendar;

public class CatsOwner {
    private int _id;
    private String _name;
    private DateTime _dateOfBirth;
    private ArrayList<Integer> _catIds;

    public CatsOwner(
            int id,
            String name,
            DateTime dateOfBirth)
    {
        _id = id;
        _name = name;
        _dateOfBirth = dateOfBirth;
        _catIds = new ArrayList<>();
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

    public ArrayList<Integer> getCats() {
        return _catIds;
    }

    public void addCat(Integer cat) {
        _catIds.add(cat);
    }
}
