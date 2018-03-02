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

* Allows the user to delete stylists (all and single)
* Allows the user to delete clients (all and single)
* Allows the user to view all clients, select one client and see the details for that particular client
* Allows the user to edit the name and/or phone number of a stylist
* Allows the user to edit all or some information for a client

* Allows the user to add a specialty
* Allows the user to view all specialties
* Allows the user to add a specialty to a stylist
* Allows the user to select a specialty and see all stylists with that specialty
* Allows the user to view the stylist's specialties on the stylist's details page
* Allows the user to add a stylist to a specialty

### Specifications
* User can add a new stylist
  * sample input: stylist name "John Smith"
  * sample output: new stylist with the name "John Smith" is created
* User can add a new client to the list of clients and select and assign a stylist to the client
  * sample input: create new client with name "Joe Blankenship" and stylist "John Smith"
  * sample output: the client Joe Blankenship is added to the list of clients for John Smith
* User can see a list of all stylists
  * sample input: click on the navbar link labeled "Stylists"
  * sample output: a list of all stylists is displayed
* User can select a stylist, and see their details
  * sample input: click on the stylist's name in the list of stylists
  * sample output: the stylist's details are displayed
* User can select a stylist, and see a list of clients who belong to that stylist
  * sample input: click on the area that says "View all clients of this stylist" under the stylist's name
  * sample output: a list of all clients for that stylist is displayed

* User can delete a single stylist
  * sample input: click on the button labeled "Delete this Stylist" on the stylists page next to a stylist's name
  * sample output: the stylist is deleted
* User can delete all stylists
  * sample input: click on the button labeled "Clear All Stylists" at the bottom of the stylist's page
  * sample output: all stylists are deleted
  * User can delete a single client
    * sample input: click on the button labeled "Delete this Client" on the clients page next to a client's name
    * sample output: the client is deleted
  * User can delete all clients
    * sample input: click on the button labeled "Clear All Clients" at the bottom of the client's page
    * sample output: all clients are deleted


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

* _Start the Apache and MySql Servers in MAMP_

*   _Setup the database_

  Either type the following commands into SQL on the command line or download the zipfile of the database that is included in this Github repository.  
  ```
  CREATE DATABASE hair_salon;
  USE hair_salon;
  CREATE TABLE stylists ( id serial PRIMARY KEY, name VARCHAR(255), hire_date DATE, phone VARCHAR(255));
  CREATE TABLE clients ( id serial PRIMARY KEY, name VARCHAR(255), phone VARCHAR(255), notes VARCHAR(255), stylist_id INT);
  CREATE TABLE TABLE specialties ( id serial PRIMARY KEY , name VARCHAR(255));
  CREATE TABLE stylists_specialties ( id serial PRIMARY KEY , stylist_id INT , specialty_id INT);
  ```

    See https://www.learnhowtoprogram.com/c/database-basics-ee7c9fd3-fcd9-4fff-8b1d-5ff7bfcbf8f0/database-practice-and-world-data for instructions and links explaining how to download the file that is located inside this github repository.

  * _Run the program_
    1. In the command line, cd into the project folder.
    ```
    cd HairSalon.Solution
    cd HairSalon
    ```
    2. In the command line, type dotnet restore. Enter.  It make take a few minutes to complete this process.
    ```
    dotnet restore
    ```
    3. In the command line, type dotnet build. Enter. Any errror messages will be displayed in red.  Errors will need to be corrected before the app can be run. After correcting errors and saving changes, type dotnet build again.  When message says Build succeeded in green, proceed to the next step.
    ```
    dotnet build
    ```
    4. In the command line, type dotnet run. Enter.
    ```
    dotnet run
    ```

  * _View program on web browser at port localhost:5000/stylists_

  * _Follow the prompts._

  ## Testing

  * _Start the Apache and MySql Servers in MAMP_

  *   _Setup the database_

   Either type the following commands into SQL on the command line or download the zipfile of the database that is included in this Github repository.  
   ```
   CREATE DATABASE hair_salon_test;
   USE hair_salon_test;
   CREATE TABLE stylists ( id serial PRIMARY KEY, name VARCHAR(255), hire_date DATE, phone VARCHAR(255));
   CREATE TABLE clients ( id serial PRIMARY KEY, name VARCHAR(255), phone VARCHAR(255), notes VARCHAR(255), stylist_id INT);
   CREATE TABLE TABLE specialties ( id serial PRIMARY KEY , name VARCHAR(255));
   CREATE TABLE stylists_specialties ( id serial PRIMARY KEY , stylist_id INT , specialty_id INT);
   ```

   See https://www.learnhowtoprogram.com/c/database-basics-ee7c9fd3-fcd9-4fff-8b1d-5ff7bfcbf8f0/database-practice-and-world-data for instructions and links explaining how to download the file that is located inside this github repository.

   * _Run the program_
     1. In the command line, cd into the project folder.
      ```
      cd HairSalon.Solution
      cd HairSalon.Tests
      ```
     2. In the command line, type dotnet restore. Enter.  It make take a few minutes to complete this process.
      ```
      dotnet restore
      ```
     3. In the command line, type dotnet test. Enter. The tests will run.  When the tests are finished, output stating how many tests were run, how many tests passed, and how many tests were skipped will be displayed.  If any tests fail, details about the failures will be described in the console.  
      ```
      dotnet test
      ```

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
