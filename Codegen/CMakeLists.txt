cmake_minimum_required(VERSION 3.22)
project(MyCppServer)

set(CMAKE_CXX_STANDARD 20)

FIND_PACKAGE( Boost 1.40 COMPONENTS program_options REQUIRED )
INCLUDE_DIRECTORIES( ${Boost_INCLUDE_DIR} )

SET(SERVED_PKG_INCLUDE_DIR /usr/local/include)
SET(SERVED_PKG_LIBRARY /usr/local/lib/libserved.so)
#FIND_PACKAGE(PkgConfig REQUIRED)
#pkg_search_module(SERVED_PKG IMPORTED_TARGET served)


include_directories(${SERVED_PKG_INCLUDE_DIR})
add_executable(MyCppServer main.cpp entities/Cat.cpp entities/Cat.h entities/Color.cpp entities/Color.h entities/CatsOwner.cpp entities/CatsOwner.h services/ICatsService.h services/CatsService.cpp services/CatsService.h server/CatsServer.cpp server/CatsServer.h dto/CatClientToServerDto.h dto/CatServerToClientDto.h tools/deserializers/ICatsDeserializer.h tools/deserializers/CatsJsonDeserializer.cpp tools/deserializers/CatsJsonDeserializer.h dto/CatsOwnerClientToServerDto.h tools/serializers/CatsJsonSerializer.cpp tools/serializers/CatsJsonSerializer.h tools/serializers/ICatsSerializer.h tools/ICatsSerializationFactory.h tools/CatsJsonSerializationFactory.cpp tools/CatsJsonSerializationFactory.h)

TARGET_LINK_LIBRARIES( MyCppServer ${BOOST_LIBRARIES} ${SERVED_PKG_LIBRARY} )
