# Dr. Sillystringz's Factory
## Description

Dr. Sillystringz's Factory is a web application built to manage machine repairs and engineers in the factory. The application allows the factory manager to add engineers and machines, specify which engineers are licensed to repair which machines, and view the relationships between engineers and machines.

## Features

- View a list of all engineers and machines.
- View details of a specific engineer, including the machines they are licensed to repair.
- View details of a specific machine, including the engineers licensed to repair it.
- Add new engineers and machines to the system.
- Remove engineers from machines or machines from engineers.
- Remove engineers from System.
- Remove machine from System.
- Establish many-to-many relationships between engineers and machines.
- Ensure data validation so that forms cannot be submitted with empty or invalid values.

## Getting Started

1. Clone the repository to your local machine:
```
git clone https://github.com/rodeomar/Factory.Solution
```

2. [Import the database](https://github.com/rodeomar/HairSalon.Solution/blob/main/README.md#steps-to-importing-database) using the provided SQL scripts in the `Factory.Solution` Folder.

3. Update the connection string in the `appsettings.json` file with your MySQL database credentials.
```
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=db_name;uid=username;pwd=password;"
  }
```
4. Build and run the application: `dotnet run` or `dotnet watch run` to run in watcher mode.

5. Open your web browser and visit `https://localhost:5000` to access the application.

-----------

## Steps to Importing Database

 1. Go to MySQL workbench and open a connection
 2. Now on the right panel click on the `Administration`.
 3. Next Click on `Data Import/Restore`.
 4. Now check `Import from Self-Contained File.`
 5. Next Browse the file path or type/paste the path of the `.sql` file.
 6. Click `New` button to create new schema, or dump it into existing schema.
 7. Select the `Dump Structure Only` from drop-down list.
 8. Next click `Start Import`.

![image](https://github.com/rodeomar/HairSalon.Solution/assets/120299308/724c8811-92e4-4996-b0b7-fca6b164fec6)

<img src="https://github.com/rodeomar/HairSalon.Solution/assets/120299308/3f316fbd-e961-440b-93c8-31526ccd0e73" alt="image" width=225>
<img src="https://github.com/rodeomar/HairSalon.Solution/assets/120299308/cc7b5621-d0ca-42cc-af94-0a061305a700" alt="image" width="780">


🎉🎉Done


--------------
### Known Bugs 
- None

---
License Please let me know if you have any questions or concerns raed@alkhanbashi.gmail.com

Copyright (c) 2023 Raed Alkhanbashi.
