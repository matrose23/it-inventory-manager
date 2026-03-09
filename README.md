IT Inventory Manager:
--------------------
A simple console application for managing IT devices such as laptops, monitors, and printers.
The application allows users to create, view, update, and delete devices and assign them to users.

Features:
--------
Create new IT devices
View all devices
Edit device information
Delete devices
Assign devices to users
Show device status (available / assigned)
Search devices by manufacturer
Search devices by location
Find devices by serial number
Filter devices by status
General search function

Technologies:
------------
C#
.NET Console Application
In-memory data storage (List<Device>)
Git & GitHub

Project Structure:
-----------------
```
it-inventory-manager
│
├── Models
│   ├── Device.cs
│   └── User.cs
│
├── Services
│   └── InventoryService.cs
│
├── Data
│   └── data.json
│
├── Program.cs
└── README.md
```

How to Run:
----------
Clone the repository
Open the project in Visual Studio
Run the application
Use the console menu to manage devices

Example Use Case:
----------------
Add a new laptop to the inventory
Assign the device to a user
Change the device status to assigned
View all devices in the system

Project Progress:
----------------

Tag 1 – Project setup  
Tag 2 – Device model and service structure  
Tag 3 – Add and display devices  
Tag 4 – Update, delete and change device status  
Tag 5 – Search and filtering features

Author:
------
Hasan Tuncay
