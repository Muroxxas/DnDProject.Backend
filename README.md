# Jacob Lavarnway's DnD Project backend

This class library contains the backend functionality for my DnD Web application, including repositories, units of work, user access facades, services & processes, IoC containerization, and more.

**The state of this project is in constant flux! All designs and implementations are subject to change!**

As I discover, study, design, and implement new design patterns, tools, and other things, the software design and implementation of the backend services can and likely *will* change drastically. 
If I discover a major design pattern or tool that I should have implemented, expect a new branch to be created as I practice and attempt to gain experience with this tool. 

## Current work
As of Feb. 15, 2021, I am currently working on redesigning and reorganizing my business logic to work with the user access proxy. Specifically, I am working on the Character creation implementation.
## Finished work
As of Feb. 12, 2021, I have finished implementing a Repository Pattern and Unit of Access Pattern for data access, as well as a base Proxy pattern for controlling user access. The access this proxy pattern has may change at some later point

As of Feb. 25th, 2012, I have implemented a basic SendGrid email sender for registration of user accounts.

View the UML diagram for the data access system [here.](https://drive.google.com/file/d/1jHCdhodi_AWYTLdqENzGg1fTXOY5xlLs/view?usp=sharing)
The Services UML diagram can be viewed [here](https://drive.google.com/file/d/1e_J5MP612-L2YUqSoDnyMLoCW8Es6ufL/view?usp=sharing)
## Planned Work
At some point during my work on the character creation implementations, I will most likely switch to working on moving and updating content creation implementations and view models, to test the waters. 
Please note that this process will not begin until my Repositories and User Access green tests have all successfully passed.
