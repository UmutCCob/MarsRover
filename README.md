# MarsRover

I tried to write my code as clean as possible, avoiding unnecessary duplicate code, long if else lines. I tried to avoid comment lines instead make it clear with method names/unit tests etc.

My goal was to handle the problem purely by commands. Instead of creating instances of objects in the main.cs i let commands do that for me using CommandFactory.

OperationCenter used as main hub of operations, getting instances of both CommandFactory and CommandParser from DI container.

I aimed to make adding new commands easily as possible by using FactoryPattern.

RoverFactory used to create multiple rovers on command also can be used to add different types of rover if needed.

Also tried to use State Pattern on handling directions of rover, instead of long if/else code. This can be also helpful adding new directions if  needed.

I added multiple ways to run the program, you can run it with default acceptence inputs or enter inputs yourself and lastly use inputs from configuration file. I added OperationConfiguration implementation to use it easily.


Possible Additions:

Better input validation,  Increasing unit test coverage  

