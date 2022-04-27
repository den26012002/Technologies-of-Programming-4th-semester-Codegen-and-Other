#include<boost/date_time/gregorian/gregorian.hpp>
#include <boost/property_tree/json_parser.hpp>
#include <boost/property_tree/ptree.hpp>
#include "CatsJsonDeserializer.h"

CatClientToServerDto CatsJsonDeserializer::getCatClientToServerDto(const std::string &serializedCat) {
    auto jsonTree = getJsonPtree(serializedCat);
    CatClientToServerDto resultDto;
    resultDto.name = jsonTree.get<std::string>("Name");
    resultDto.dateOfBirth = getDateOfBirth(jsonTree.get_child("DateOfBirth"));
    resultDto.color = getColor(jsonTree.get_child("Color"));
    resultDto.ownerId = jsonTree.get<int>("OwnerId");
    return resultDto;
}

CatsOwnerClientToServerDto CatsJsonDeserializer::getCatsOwnerClientToServerDto(const std::string &serializedCatsOwner) {
    auto jsonTree = getJsonPtree(serializedCatsOwner);
    CatsOwnerClientToServerDto resultDto;
    resultDto.name = jsonTree.get<std::string>("Name");
    resultDto.dateOfBirth = getDateOfBirth(jsonTree.get_child("DateOfBirth"));
    return resultDto;
}

boost::gregorian::date CatsJsonDeserializer::getDateOfBirth(const boost::property_tree::ptree& dateJsonTree) {
    auto yearOfBirth = boost::gregorian::greg_year(dateJsonTree.get<int>("Year"));
    auto monthOfBirth = boost::gregorian::greg_month(dateJsonTree.get<int>("Month"));
    auto dayOfBirth = boost::gregorian::greg_day(dateJsonTree.get<int>("Day"));
    return boost::gregorian::date(yearOfBirth, monthOfBirth, dayOfBirth);
}

Color CatsJsonDeserializer::getColor(const boost::property_tree::ptree& colorJsonTree) {
    auto r = colorJsonTree.get<int>("Red");
    auto g = colorJsonTree.get<int>("Green");
    auto b = colorJsonTree.get<int>("Blue");
    return Color{r, g, b};
}

boost::property_tree::ptree CatsJsonDeserializer::getJsonPtree(const std::string &serializedSmth) {
    std::stringstream stream(serializedSmth);
    boost::property_tree::ptree jsonTree;
    boost::property_tree::read_json(stream, jsonTree);
    return jsonTree;
}