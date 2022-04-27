#include "serializers/CatsJsonSerializer.h"
#include "deserializers/CatsJsonDeserializer.h"
#include "CatsJsonSerializationFactory.h"

ICatsSerializer* CatsJsonSerializationFactory::getSerializer() {
    return new CatsJsonSerializer();
}

ICatsDeserializer* CatsJsonSerializationFactory::getDeserializer() {
    return new CatsJsonDeserializer();
}