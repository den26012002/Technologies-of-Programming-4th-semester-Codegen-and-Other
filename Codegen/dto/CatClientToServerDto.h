#pragma once
#include<string>
#include"../entities/Color.h"
#include"../entities/CatsOwner.h"

struct CatClientToServerDto {
    std::string name;
    boost::gregorian::date dateOfBirth;
    Color color;
    int ownerId;
};
