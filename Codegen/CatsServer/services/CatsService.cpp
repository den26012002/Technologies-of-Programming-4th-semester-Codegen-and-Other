#include<algorithm>
#include "CatsService.h"
#include "../entities/Cat.h"
#include "../entities/CatsOwner.h"

const Cat& CatsService::getCatById(int catId) const {
    auto catIt = std::find_if(_cats.begin(), _cats.end(), [catId](const Cat& cat) { return cat.id() == catId;});
    if (catIt == _cats.end()) {
        throw "Error";
    }
    return *catIt;
}

const CatsOwner& CatsService::getCatsOwnerById(int catsOwnerId) const {
    return *std::find_if(_catsOwners.begin(), _catsOwners.end(), [catsOwnerId](const CatsOwner& catsOwner) { return catsOwner.id() == catsOwnerId; });
}

const Cat& CatsService::registerCat(
        const std::string& catName,
        const boost::gregorian::date& dateOfBirth,
        const Color& color,
        int ownerId) {
    _cats.push_back(Cat(_nextCatId++, catName, dateOfBirth, color, const_cast<CatsOwner*>(&getCatsOwnerById(ownerId))));
    const_cast<CatsOwner&>(getCatsOwnerById(ownerId)).addCat(&*_cats.end());
    return *_cats.end();
}
const CatsOwner& CatsService::registerCatsOwner(
        const std::string& catsOwnerName,
        const boost::gregorian::date& dateOfBirth) {
    _catsOwners.push_back(CatsOwner(_nextCatsOwnerId++, catsOwnerName, dateOfBirth));
    return *_catsOwners.end();
}

void CatsService::addFriends(int catId1, int catId2) {
    Cat& cat1 = const_cast<Cat&>(getCatById(catId1));
    Cat& cat2 = const_cast<Cat&>(getCatById(catId2));
    cat1.addFriend(&cat2);
    cat2.addFriend(&cat1);
}