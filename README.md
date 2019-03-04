# README #

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/0388f25bcf6e461aa351d78f1ece4ee1)](https://app.codacy.com/app/LechuckThePirate/EntityFramework_TPT?utm_source=github.com&utm_medium=referral&utm_content=LechuckThePirate/EntityFramework_TPT&utm_campaign=Badge_Grade_Dashboard)

This project demontrates the use of Entity Framework Code First TPT (Table Per Type) possibilities.

Table Per Type allows you to have a given collection of objects inheriting from the same ancestor class and mapping them to be written to different tables based on their type.

To make it clear, this demo project creates a DbContext where the main entity is a car, that owns a list of "car parts". This list of car parts can contain objects of class Door, Wheel or Seat and using TPT each object will be written to and read from its own table.

# IMPORTANT #

Updated to Visual Studio 2015 C#6 on 25/02/2016 (commit 32e9117). Now you need Visual Studio 2015 to run the project, or change string interpolations ($"xxxxx") to string.Format()