# The Razor's Edge Project

A WPF Applicaction (server) and console application (client) to comunicate using Named Pipes for Network Interprocess Communication.

## Description

A WPF (Windows Presentation Foundation) Applicaction (server) and console application (client) to comunicate using Named Pipes for Network Interprocess Communication. 
A wind farm simulator with wind turbines. 

Each wind turbine implements a observer patternto future works with metric recived from a pipeline. The console application (client) send metrics (randomly generated) through a pipeline (NamedPipeline) to server (the graphic application). The objetive is simulate changing weather conditions.

![Example of Graphinc application](https://github.com/jke94/TheRazorsEdge/blob/dev/ProjectImages/ServerWPFApplicationApplication.PNG)

## Getting Started

### Dependencies

* .NET Framework 4.7.2

### Installing

* Clone project.
* Open TheRazorEdge.sln


### Executing program

* Select WFPApp project and 'Set as Startup Project'
* Select target Debug or Release (open then WPF.exe application)
* Open AutoClienteConsole.exe and run form cmd, for example to see the info in the cmd.


## Help

Any advise for common problems or issues.


## Authors

Javier Carracedo 

Twitter Profile: [@JaviKarra94](https://twitter.com/JaviKarra94)

## Version History


## License

This project is licensed under the [NAME HERE] License - see the LICENSE.md file for details

## Acknowledgments
* [ACDC - The Razors Edge](https://www.youtube.com/watch?v=l_7SxoQW11g). The origin of the project name because the song was sounding in the creation of the project.
* [El patrón Observador en C#](https://albertcapdevila.net/patron-observador-csharp/). Good explanation about observer pattern design.
