#include <iostream>
#include <string>
#include <sstream>
#include <unordered_map>

std::unordered_map<std::string, std::string> str_variables;
std::unordered_map<std::string, int> int_variables;

void process_line(const std::string& line) {
    std::istringstream iss(line);
    std::string command;
    iss >> command;

    if (command == "str:") {
        std::string var_name, value;
        iss >> var_name >> std::ws;
        std::getline(iss, value);
        str_variables[var_name] = value;
    } else if (command == "int:") {
        std::string var_name;
        int value;
        iss >> var_name >> value;
        int_variables[var_name] = value;
    } else if (command == "print") {
        std::string var_name;
        iss >> var_name;
        if (str_variables.find(var_name) != str_variables.end()) {
            std::cout << str_variables[var_name] << std::endl;
        } else if (int_variables.find(var_name) != int_variables.end()) {
            std::cout << int_variables[var_name] << std::endl;
        } else {
            std::cerr << "Undefined variable: " << var_name << std::endl;
        }
    } else {
        std::cerr << "Unknown command: " << command << std::endl;
    }
}

int main() {
    std::string line;
    while (std::getline(std::cin, line)) {
        process_line(line);
    }
    return 0;
}
