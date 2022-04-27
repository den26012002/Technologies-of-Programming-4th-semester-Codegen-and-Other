#pragma once
#include<string>
#include<vector>
#include<boost/date_time/gregorian/gregorian.hpp>
#include<boost/property_tree/ptree.hpp>
#include"ICatsSerializer.h"

class CatsJsonSerializer : public ICatsSerializer {
public:
    std::string getSerializeCat(const Cat& cat) override;
    std::string getSerializedCatsOwner(const CatsOwner& catsOwner) override;
    boost::property_tree::ptree getSerializedDate(const boost::gregorian::date& dateOfBirth);
    boost::property_tree::ptree getSerializedColor(const Color& color);
    boost::property_tree::ptree getSerializedCatsIds(const std::vector<const Cat*>& cats);
};