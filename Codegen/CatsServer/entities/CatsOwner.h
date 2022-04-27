#pragma once
#include<string>
#include<vector>
#include<boost/date_time/gregorian/gregorian.hpp>

class Cat;

class CatsOwner {
public:
    CatsOwner(
            int id,
            const std::string& name,
            const boost::gregorian::date dateOfBirth);
    int id() const;
    const std::string& name() const;
    const boost::gregorian::date& dateOfBirth() const;
    const std::vector<const Cat*>& cats() const;
    void addCat(Cat* cat);
private:
    int _id;
    std::string _name;
    boost::gregorian::date _dateOfBirth;
    std::vector<const Cat*> _cats;
};
