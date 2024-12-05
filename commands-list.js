const commands = {
    cpp: {
        str: "Defines a string variable, e.g., 'str: name John Doe'",
        int: "Defines an integer variable, e.g., 'int: age 30'",
        print: "Prints the value of the specified variable, e.g., 'print name'"
    },
    docker: {
        mod_new: "Starts a new Docker container, e.g., 'mod new'",
        run: "Runs a previously created Docker container, e.g., 'run'"
    }
};

// Example of printing the commands
console.log("C++ Interpreter Commands:");
console.log(`- str: ${commands.cpp.str}`);
console.log(`- int: ${commands.cpp.int}`);
console.log(`- print: ${commands.cpp.print}`);

console.log("\nCommand Prompt for Docker:");
console.log(`- mod new: ${commands.docker.mod_new}`);
console.log(`- run: ${commands.docker.run}`);
