#pragma once
#include<vector>
#include<string>
#include<boost/date_time/gregorian/gregorian.hpp>
#include"../entities/Color.h"


class CatServerToClientDto {
    int id;
    std::string name;
    boost::gregorian::date dateOfBirth;
    Color _color;
    int ownerId;
    std::vector<int> friendsIds;
};
