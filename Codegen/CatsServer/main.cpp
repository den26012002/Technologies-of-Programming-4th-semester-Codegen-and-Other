#include <served/served.hpp>
#include <string>
#include<boost/date_time/gregorian/gregorian.hpp>
#include <boost/property_tree/json_parser.hpp>
#include <boost/property_tree/ptree.hpp>
#include <boost/foreach.hpp>
//#include "entities/Cat.h"
//#include "entities/CatsOwner.h"
#include"server/CatsServer.h"
#include"services/CatsService.h"
#include"tools/CatsJsonSerializationFactory.h"

int main(int argc, char const* argv[]) {
    //CatsOwner catsOwner(1, "bbb", boost::gregorian::date());
    //Cat cat(1, "aaa", boost::gregorian::date(), {10, 20, 30}, &catsOwner);
    //cat.friends()[0];
	// Create a multiplexer for handling requests
	/*served::multiplexer mux;

	// GET /hello
	mux.handle("/hello")
		.get([](served::response & res, const served::request & req) {

			res << "Hello world!";
		});
    mux.handle("/users")
            .get([](served::response & res, const served::request & req) {
                res << "User: " << req.query["id"];
            });
    mux.handle("/posts/{id}")
            .post([](served::response & res, const served::request & req) {
                if (req.header("Content-Type") != "application/json") {
                    served::response::stock_reply(400, res);
                    return;
                }
                res << "Hello";
            });

	// Create the server and run with 10 handler threads.
	served::net::server server("127.0.0.1", "8080", mux);
	server.run(10);*/
    /*std::string str = "{\"ID\":0,\"Student\":{\"Name\":\"April\"}}";
    std::stringstream stream(str);
    boost::property_tree::ptree strTree;
    try {
        read_json(stream, strTree);
    }
    catch (boost::property_tree::ptree_error & e) {
        return (EXIT_FAILURE);
    }
    std::cout << strTree.get_child("Student").get<std::string>("Name");

    boost::property_tree::ptree subject_info;
    boost::property_tree::ptree array1, array2, array3;
    array1.put("course", "Java");
    array2.put("course", "C++");
    array3.put("course", "MySql");
    subject_info.push_back(make_pair("", array1));
    //subject_info.push_back(make_pair("", array2));
    //subject_info.push_back(make_pair("", array3));

    strTree.put_child("Subject", subject_info);
    std::stringstream s;
    write_json(s, strTree);
    std::cout << s.str();*/

    /*boost::gregorian::date date(boost::gregorian::greg_year(1400), boost::gregorian::greg_month(10), boost::gregorian::greg_day(10));
    std::cout << date.day_of_year();*/
    CatsService catsService;
    catsService.registerCatsOwner("Aboba", boost::gregorian::date(boost::gregorian::greg_year(1400), boost::gregorian::greg_month(10), boost::gregorian::greg_day(10)));
    CatsJsonSerializationFactory factory;
    CatsServer server(&catsService, &factory);
    server.run("127.0.0.1", 8081, 10);

	return (EXIT_SUCCESS);
}