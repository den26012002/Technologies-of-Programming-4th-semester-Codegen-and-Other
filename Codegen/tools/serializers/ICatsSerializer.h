#pragma once
#include<string>
#include"../../entities/Cat.h"
#include"../../entities/CatsOwner.h"

class ICatsSerializer {
public:
    virtual std::string getSerializeCat(const Cat& cat) = 0;
    virtual std::string getSerializedCatsOwner(const CatsOwner& catsOwner) = 0;
    virtual ~ICatsSerializer() = default;
};