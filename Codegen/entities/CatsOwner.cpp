#include "CatsOwner.h"

CatsOwner::CatsOwner(
        int id,
        const std::string& name,
        const boost::gregorian::date dateOfBirth) :
        _id(id),
        _name(name),
        _dateOfBirth(dateOfBirth)
{

}

int CatsOwner::id() const {
    return _id;
}

const std::string& CatsOwner::name() const {
    return _name;
}

const boost::gregorian::date& CatsOwner::dateOfBirth() const {
    return _dateOfBirth;
}

const std::vector<const Cat*>& CatsOwner::cats() const {
    return _cats;
}

void CatsOwner::addCat(Cat *cat) {
    _cats.push_back(cat);
}