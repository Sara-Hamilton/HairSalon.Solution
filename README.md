# Hair Salon

#### .NET MVC app that allows the user to compile a list of stylists and a list of clients who belong to each stylist, 2-23-18

#### _By Sara Hamilton_

## Description
_This is the Epicodus weekly project for week 3 of the C# course. Its purpose is to demonstrate understanding of SQL and databases._

#### _Hair Salon_
* Allows the user to add a new stylist
* Allows the user to add a new client and assign the client to an existing stylist
* Allows the user to see a list of all stylists
* Allows the user to select a stylist, see their details, and see a list of clients who belong to that stylist

### Specifications
* User can add a new stylist
  * sample input: stylist name "Jane Smith"
  * sample output: new stylist with the name "John Smith" is created
* User can add a new client to the list of clients and select and assign a stylist to the client
  * sample input: Create new client with name "Joe Blankenship" and stylist "John Smith"
  * sample output: The client Joe Blenkenship is added to the list of clients for John Smith
* User can see a list of all stylists
  * sample input: click on the navbar link labeled "Stylists"
  * sample output: a list of all stylists is displayed
* User can select a stylist, see their details, and see a list of clients who belong to that stylist
  * sample input: click on the stylist's name in the list of stylists
  * sample output: a list of all clients for that stylist is displayed


  ## Setup/Installation Requirements

  * _Clone this GitHub repository_

  ```
  git clone https://github.com/Sara-Hamilton/HairSalon.git
  ```

  * _Install the .NET Framework and MAMP_

    .NET Core 1.1 SDK (Software Development Kit)

    .NET runtime.

    MAMP

    See https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c for instructions and links.

  *    _Import the data into the database_
    See https://www.learnhowtoprogram.com/c/database-basics-ee7c9fd3-fcd9-4fff-8b1d-5ff7bfcbf8f0/database-practice-and-world-data for instructions and links.
    Download the zipfile that is located inside this github repository.

  * _Start the Apache and MySql Servers in MAMP_

  * _Run the program_
    1. In the command line, cd into the project folder.
    2. In the command line, type dotnet restore. Enter.  It make take a few minutes to complete this process.
    3. In the command line, type dotnet build. Enter. Any errror messages will be displayed in red.  Errors will need to be corrected before the app can be run. After correcting errors and saving changes, type dotnet build again.  When message says Build succeeded in green, proceed to the next step.
    4. In the command line, type dotnet run. Enter.

  * _View program on web browser at port localhost:5000/_

  * _Follow the prompts._

  ## Support and contact details

_To suggest changes, submit a pull request in the GitHub repository._

## Technologies Used

* HTML
* Bootstrap
* C#
* MAMP
* .Net Core 1.1
* Razor
* MySQL

### License

*MIT License*

Copyright (c) 2018 **_Sara Hamilton_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
