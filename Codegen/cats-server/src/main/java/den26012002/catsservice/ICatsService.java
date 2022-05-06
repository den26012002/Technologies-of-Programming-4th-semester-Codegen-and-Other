package den26012002.catsservice;

import den26012002.catsentities.*;

import java.util.GregorianCalendar;

public interface ICatsService {
    Cat getCatById(int catId);
    CatsOwner getCatsOwnerById(int catsOwnerId);
    Cat registerCat(
            String catName,
            DateTime dateOfBirth,
            Color color,
            int ownerId);
    CatsOwner registerCatsOwner(
            String catsOwnerName,
            DateTime dateOfBirth);
    void addFriends(int catId1, int catId2);
}
