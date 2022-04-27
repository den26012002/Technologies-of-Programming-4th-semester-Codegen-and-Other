#pragma once
#include<string>
#include<boost/date_time/gregorian/gregorian.hpp>

struct CatsOwnerClientToServerDto {
    std::string name;
    boost::gregorian::date dateOfBirth;
};
