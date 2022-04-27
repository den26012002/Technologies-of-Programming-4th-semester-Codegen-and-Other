#pragma once
#include<string>
#include<vector>
#include<boost/date_time/gregorian/gregorian.hpp>
#include "Color.h"

class CatsOwner;

class Cat {
public:
    Cat(
            int id,
            const std::string& name,
            const boost::gregorian::date dateOfBirth,
            const Color& color,
            CatsOwner* owner);
    int id() const;
    const std::string& name() const;
    const boost::gregorian::date& dateOfBirth() const;
    const Color& color() const;
    const CatsOwner* owner() const;
    const std::vector<const Cat*>& friends() const;
    void addFriend(Cat* other);

private:
    int _id;
    std::string _name;
    boost::gregorian::date _dateOfBirth;
    Color _color;
    CatsOwner* _owner;
    std::vector<const Cat*> _friends;
};