#pragma once
#include"ICatsSerializationFactory.h"

class CatsJsonSerializationFactory : public ICatsSerializationFactory {
public:
    ICatsSerializer* getSerializer() override;
    ICatsDeserializer* getDeserializer() override;
};
