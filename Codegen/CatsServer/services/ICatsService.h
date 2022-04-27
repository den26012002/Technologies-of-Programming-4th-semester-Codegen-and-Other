#pragma once

#include<boost/date_time/gregorian/gregorian.hpp>
#include"../entities/Cat.h"

class ICatsService {
public:
    virtual const Cat& getCatById(int catId) const = 0;
    virtual const CatsOwner& getCatsOwnerById(int catsOwnerId) const = 0;
    virtual const Cat& registerCat(
            const std::string& catName,
            const boost::gregorian::date& dateOfBirth,
            const Color& color,
            int ownerId) = 0;
    virtual const CatsOwner& registerCatsOwner(
            const std::string& catsOwnerName,
            const boost::gregorian::date& dateOfBirth) = 0;
    virtual void addFriends(int catId1, int catId2) = 0;
    virtual ~ICatsService() = default;
};