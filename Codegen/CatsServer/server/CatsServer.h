#pragma once
#include<served/served.hpp>
#include"../services/ICatsService.h"
#include"../tools/ICatsSerializationFactory.h"

class CatsServer {
public:
    CatsServer(ICatsService* service, ICatsSerializationFactory* factory);
    void run(const std::string& url, int port, int threads);
private:
    ICatsService* _service;
    ICatsSerializationFactory* _factory;
    served::multiplexer _multiplexer;
};
