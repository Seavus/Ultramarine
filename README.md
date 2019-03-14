# Ultramarine
Platform independent to platform specific transformation tools

### Overview
Simply put, Ultramarine is a platform-independent model to platform-specific model transformation set of tools. These tools, once installed in Visual Studio or Visual Studio Code will help Seavus developers analyze, maintain, generate and build maintainable code that follows structural and behavioral design patterns and Seavus best practices. 

Visual Studio with Ultramarine will help Seavus developers become more productive by automating the process of implementation and leaving them to concentrate on business logic only. 


### Technology
Ultramarine is a set of tools but it can be divided into two technological stacks each one following their own host.

Visual Studio tooling will be built using these technologies:

* VSIX 
* DSL Tools
* Visual Studio Modelling SDK
* C# as a default language

Visual Studio Code tooling will be built using these technologies:

* VSCode Extensions
* Workbench
* Webview
* Language and Debugger extensions
* Javascript and React/Redux as default language/framework

### Architecture
In short, Ultramarine is being built around DDD. The only difference here is that clients are other developers.

Architecturally, the project is split into 4 things:

* Code analyzer and generator server
* The Ultramarine extension - a processor for the analysis and generation
* TaskFlow DSL that will help developers graphically represent the analysis and generation process
* Custom Nuget repository that holds templates and schema for the best practices

Architectural diagrams will be provided later.

Deployment
We plan to use Jenkins and directly distribute the artifacts on https://marketplace.visualstudio.com/
