# Introduction

Hi there! I don't know why I am writing this. Maybe for future me. Maybe for someone with same problems. 
Or I did powerful solution which could kill `ScreenMeter` application. Srsly, hate this one.

# Core functionality

1. Sends screenshots and syncing time according to screen meter configuration
2. It selects screenshots FROM YOURS repository and sends it
    0. Repository located at `wwwroot/images`
    1. It selects screenshot which the most date time (ignoring year, month, day) to current nearest time (UTC+0)
    2. It is has simple authorization
    3. It is has super simple control panel (use swagger)
   
For more minor thing please, welcome to swagger. Swagger located at www.root.com/swagger

# Configuration

Look at `appsettings.json` it is have all required settings to launch this application

`SMConfiguration` section:

This is quite simple: fill login / password as is and Anti Screen Meter (ASM) module is configured

`RepeaterConfiguration` section:

It is initial startup configuration for Cron/Repeater. 
I recommend start everything manually, but if you don't care, then switch `isPaused` trigger.

`WhiteListAuthSchemeOptions` section:

In `keys` list fill every appropriate password for swagger. This is all

`FilesServiceConfiguration` section:

Use path to define where located images for 'ScreenShotsFilesService' within your environment

# Other technical stuff and other things (skip if don't want to do changes)

Projects:
1. ASM.ApiServices. This project have modules which is consumed by WebApi project / controllers
2. ASM.Models. This project contains all business models for current solution
3. ASM.Tests. This project contains semi-automatic tests to trigger logic separately from testing panel
4. ASM.WebApi. Nothing special. Just controllers and configuration for services. This is all
5. Tools.Library.Analyzers. This project contains data type analyzers. For example: string similarity module
6. Tools.Library.Authorization. This project contains reusable modules for authorization flow
7. Tools.Library.HttpClient. This project contains wrappers on HttpClients, for example, wrapper for `RestClient`

# Architecture

As usual. Nothing in WebApi projects except configurations.

Models project should contains reusable models for specific business area.

Tools should contain modules which could be reused across multiple solutions.

ProjectName.ModuleName should contain module which could be used only in specific business area
