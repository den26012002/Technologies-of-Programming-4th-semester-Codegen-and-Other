package den26012002.catsservice;

import den26012002.catsentities.*;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.GregorianCalendar;

@Service
public class CatsService implements ICatsService{
    private int _nextCatId = 0;
    private int _nextCatsOwnerId = 0;
    private final ArrayList<Cat> _cats = new ArrayList<>();
    private final ArrayList<CatsOwner> _catsOwners = new ArrayList<>();

    @Override
    public Cat getCatById(int catId) {
        return _cats.stream().filter(cat -> cat.getId() == catId).findFirst().get();
    }

    @Override
    public CatsOwner getCatsOwnerById(int catsOwnerId) {
        return _catsOwners.stream().filter(catsOwner -> catsOwner.getId() == catsOwnerId).findFirst().get();
    }

    @Override
    public Cat registerCat(String catName, DateTime dateOfBirth, Color color, int ownerId) {
        var newCat = new Cat(_nextCatId++, catName, dateOfBirth, color, ownerId);
        _cats.add(newCat);
        var catsOwner = getCatsOwnerById(ownerId);
        catsOwner.addCat(newCat.getId());
        return newCat;
    }

    @Override
    public CatsOwner registerCatsOwner(String catsOwnerName, DateTime dateOfBirth) {
        var newCatsOwner = new CatsOwner(_nextCatsOwnerId++, catsOwnerName, dateOfBirth);
        _catsOwners.add(newCatsOwner);
        return newCatsOwner;
    }

    @Override
    public void addFriends(int catId1, int catId2) {
        Cat cat1 = getCatById(catId1);
        Cat cat2 = getCatById(catId2);
        cat1.addFriend(catId2);
        cat2.addFriend(catId1);
    }
}
