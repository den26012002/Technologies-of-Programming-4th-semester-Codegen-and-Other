#pragma once
#include<string>
#include"../../dto/CatClientToServerDto.h"
#include"../../dto/CatsOwnerClientToServerDto.h"

class ICatsDeserializer {
public:
    virtual CatClientToServerDto getCatClientToServerDto(const std::string& serializedCat) = 0;
    virtual CatsOwnerClientToServerDto getCatsOwnerClientToServerDto(const std::string& serializedCatsOwner) = 0;
    virtual ~ICatsDeserializer() = default;
};