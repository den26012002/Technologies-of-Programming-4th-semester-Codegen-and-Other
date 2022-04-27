#include<string>
#include "CatsServer.h"
#include"../dto/CatClientToServerDto.h"
#include"../tools/deserializers/CatsJsonDeserializer.h"

CatsServer::CatsServer(ICatsService *service, ICatsSerializationFactory* factory) :
    _service(service),
    _factory(factory)
{
    _multiplexer.handle("/cats/get/{id}").get([this](served::response& response, const served::request& request) {
        auto catJsonSerializer = _factory->getSerializer();
        auto serializedCat = catJsonSerializer->getSerializeCat(_service->getCatById(std::stoi(request.params["id"])));
        delete catJsonSerializer;
        response << serializedCat;
    });
    _multiplexer.handle("/cats_owners/get/{id}").get([this](served::response& response, const served::request& request) {
        try {
            auto catJsonSerializer = _factory->getSerializer();
            auto serializedCatsOwner = catJsonSerializer->getSerializedCatsOwner(_service->getCatsOwnerById(std::stoi(request.params["id"])));
            delete catJsonSerializer;
            response << serializedCatsOwner;
        } catch (...) {
            response << "Error";
        }
        response << "Hello";
    });
    _multiplexer.handle("/cats/register").post([this](served::response& response, const served::request& request) {
        auto catJsonDeserializer = _factory->getDeserializer();
        auto catRegisterInfo = catJsonDeserializer->getCatClientToServerDto(request.body());
        delete catJsonDeserializer;
        _service->registerCat(catRegisterInfo.name, catRegisterInfo.dateOfBirth, catRegisterInfo.color, catRegisterInfo.ownerId);
    });
    _multiplexer.handle("/cats_owners/register").post([this](served::response& response, const served::request& request) {
        auto catJsonDeserializer = _factory->getDeserializer();
        auto catsOwnerRegisterInfo = catJsonDeserializer->getCatsOwnerClientToServerDto(request.body());
        delete catJsonDeserializer;
        _service->registerCatsOwner(catsOwnerRegisterInfo.name, catsOwnerRegisterInfo.dateOfBirth);
    });
    _multiplexer.handle("/cats/add_friends").post([this](served::response& response, const served::request& request) {
        _service->addFriends(std::stoi(request.query["id1"]), std::stoi(request.query["id2"]));
    });
}

void CatsServer::run(const std::string &url, int port, int threads) {
    served::net::server server(url, std::to_string(port), _multiplexer);
    server.run(threads);
}