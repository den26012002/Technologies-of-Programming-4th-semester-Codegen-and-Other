#pragma once
#include <boost/property_tree/ptree.hpp>
#include"ICatsDeserializer.h"
#include"../../entities/Color.h"

class CatsJsonDeserializer : public ICatsDeserializer {
public:
    CatClientToServerDto getCatClientToServerDto(const std::string& serializedCat) override;
    CatsOwnerClientToServerDto getCatsOwnerClientToServerDto(const std::string& serializedCatsOwner) override;
    boost::gregorian::date getDateOfBirth(const boost::property_tree::ptree& dateJsonTree);
    Color getColor(const boost::property_tree::ptree& colorJsonTree);
private:
    boost::property_tree::ptree getJsonPtree(const std::string& serializedSmth);
};