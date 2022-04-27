#pragma once
#include"serializers/ICatsSerializer.h"
#include"deserializers/ICatsDeserializer.h"

class ICatsSerializationFactory {
public:
    virtual ICatsSerializer* getSerializer() = 0;
    virtual ICatsDeserializer* getDeserializer() = 0;
    virtual ~ICatsSerializationFactory() = default;
};
