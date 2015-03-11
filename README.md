# README #

This project demontrates the use of Entity Framework Code First TPT (Table Per Type) possibilities.

Table Per Type allows you to have a given collection of objects inheriting from the class and mapping them to be written to different tables based on their type.

To make it clear, this demo project creates a DbContext where the main entity is a car, that owns a list of "car parts". This list of car parts can contain objects of class Door, Wheel or Seat and using TPT each object will be written to and read from its own table.

