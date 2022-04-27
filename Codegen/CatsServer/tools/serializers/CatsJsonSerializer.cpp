#include<string>
#include<boost/property_tree/ptree.hpp>
#include<boost/property_tree/json_parser.hpp>
#include"CatsJsonSerializer.h"

std::string CatsJsonSerializer::getSerializeCat(const Cat &cat) {
    boost::property_tree::ptree catJsonTree;
    catJsonTree.put("Id", cat.id());
    catJsonTree.put("Name", cat.name());
    catJsonTree.push_back({"DateOfBirth", getSerializedDate(cat.dateOfBirth())});
    catJsonTree.push_back({"Color", getSerializedColor(cat.color())});
    catJsonTree.put("OwnerId", cat.owner()->id());
    catJsonTree.push_back({"FriendsIds", getSerializedCatsIds(cat.friends())});
    std::stringstream stream;
    write_json(stream, catJsonTree);
    return stream.str();
}

std::string CatsJsonSerializer::getSerializedCatsOwner(const CatsOwner &catsOwner) {
    boost::property_tree::ptree catsOwnerJsonTree;
    catsOwnerJsonTree.put("Id", catsOwner.id());
    catsOwnerJsonTree.put("Name", catsOwner.name());
    catsOwnerJsonTree.push_back({"DateOfBirth", getSerializedDate(catsOwner.dateOfBirth())});
    catsOwnerJsonTree.push_back({"Cats", getSerializedCatsIds(catsOwner.cats())});
    std::stringstream stream;
    write_json(stream, catsOwnerJsonTree);
    return stream.str();
}

boost::property_tree::ptree CatsJsonSerializer::getSerializedDate(const boost::gregorian::date &dateOfBirth) {
    boost::property_tree::ptree dateJsonTree;
    dateJsonTree.put("Year", dateOfBirth.year());
    dateJsonTree.put("Month", dateOfBirth.month());
    dateJsonTree.put("Day", dateOfBirth.day());
    return dateJsonTree;
}

boost::property_tree::ptree CatsJsonSerializer::getSerializedColor(const Color &color) {
    boost::property_tree::ptree colorJsonTree;
    colorJsonTree.put("Red", color.r);
    colorJsonTree.put("Green", color.g);
    colorJsonTree.put("Blue", color.b);
    return colorJsonTree;
}

boost::property_tree::ptree CatsJsonSerializer::getSerializedCatsIds(const std::vector<const Cat*>& cats) {
    boost::property_tree::ptree catsJsonTree;
    for (const auto& cat : cats)
    {
        boost::property_tree::ptree  catJsonTree;
        catJsonTree.put("Id", cat->id());
        catsJsonTree.push_back({"", catJsonTree});
    }
    return catsJsonTree;
}