#pragma once
#include"ICatsService.h"

class CatsService : public ICatsService {
public:
    const Cat& getCatById(int catId) const override;
    const CatsOwner& getCatsOwnerById(int catsOwnerId) const override;
    const Cat& registerCat(
            const std::string& catName,
            const boost::gregorian::date& dateOfBirth,
            const Color& color,
            int ownerId) override;
    const CatsOwner& registerCatsOwner(
            const std::string& catsOwnerName,
            const boost::gregorian::date& dateOfBirth) override;
    void addFriends(int catId1, int catId2) override;
private:
    int _nextCatId = 0;
    int _nextCatsOwnerId = 0;
    std::vector<Cat> _cats;
    std::vector<CatsOwner> _catsOwners;
};