# Jacob Lavarnway's DnD Project backend

This class library contains the backend functionality for my DnD Web application, including repositories, units of work, user access facades, services, IoC containerization, and more.

**The state of this project is in constant flux! All designs and implementations are subject to change!**

As I discover, study, design, and implement new design patterns, tools, and other things, the software design and implementation of the backend services can and likely *will* change drastically. 
If I discover a major design pattern or tool that I should have implemented, expect a new branch to be created as I practice and attempt to gain experience with this tool. 

## Current work
As of Feb. 10, 2021, I am currently implementing classes using the Repository Pattern and Unit of Access Pattern for data access, as well as to make the system overall more easily unit tested. 
Laid over top of the Unit of Work are various classes of the User Access namespace. These classes will act as facades for the different access capabilities different types of users will have to the database.
For example, standard users will be capable of getting the information regarding a spell, or having their character learn a spell. However, only Spell Managers can create spells.


View the UML diagram for the data access system [here.](https://drive.google.com/file/d/1jHCdhodi_AWYTLdqENzGg1fTXOY5xlLs/view?usp=sharing)
## Planned Work
After I have removed all models and data access from the [primary project](https://github.com/Muroxxas/DnD-Project), I intend to begin redesigning my business logic, 
such that it should work with the User Access classes properly, obscuring the implementation of data access from business logic entirely. 
Please note that this process will not begin until my Repositories and User Access green tests have all successfully passed.
