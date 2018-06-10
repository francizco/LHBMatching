# LHBMatching

The problem: how do you automatically match campers to their lodgings based on a series of preferences? Treat it as a constraint satisfaction problem. The program will build the mock data and use it to build a list of campers and their preferences. Then, it will pull a camper from the list and place it into a room. It will then grab the next camper and attempt to place it in a lodge based on their preferences. If no lodges matching their preferences are available, it will add them into an empty lodge. If no empty lodges remain, it will add the camper to an unmatched list for manual sorting. Everything should be straight forward. Campers, lodges, rooms, constraints all have their own classes. The matching algorithm itself resides in Match.cs. After testing and ensuring it worked, this code was heavily adapted into web application on Azure using ASP.Net. Could use some refactoring.

## Getting Started

Everything to test and run the example is included here. 

### Prerequisites

Created in Visual Studio Community for Mac but also tested on Visual Studio 2017 (Windows).

### Installing

Clone and build in Visual Studio.


## Author

* **Frank Fuentes** - *Initial work* - [Seattle University, Senior Capstone Project](https://github.com/francizco)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
