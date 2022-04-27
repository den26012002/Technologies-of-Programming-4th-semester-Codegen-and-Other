#include "Cat.h"

Cat::Cat(
        int id,
        const std::string& name,
        const boost::gregorian::date dateOfBirth,
        const Color& color,
        CatsOwner* owner) :
        _id(id),
        _name(name),
        _dateOfBirth(dateOfBirth),
        _color(color),
        _owner(owner)
{
}

int Cat::id() const {
    return _id;
}

const std::string& Cat::name() const {
    return _name;
}

const boost::gregorian::date& Cat::dateOfBirth() const {
    return _dateOfBirth;
}
const Color& Cat::color() const {
    return _color;
}

const CatsOwner* Cat::owner() const {
    return  _owner;
}

const std::vector<const Cat*>& Cat::friends() const {
    return _friends;
}

void Cat::addFriend(Cat* other) {
    _friends.push_back(other);
}