#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle(@"")]
[assembly: AssemblyDescription(@"")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(@"Seavus")]
[assembly: AssemblyProduct(@"Ultramarine")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.Resources.NeutralResourcesLanguage("en")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion(@"1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]

//
// Make the Dsl project internally visible to the DslPackage assembly
//
[assembly: InternalsVisibleTo(@"Ultramarine.Generators.Language.DslPackage, PublicKey=0024000004800000940000000602000000240000525341310004000001000100398AB5D58FC8185A70E69E65272F5709CE8CEF9403922D7236DFCC58CC9C929E3934BD02A9BA595633315EAB891AED906F55625426286EAAC8A5841997D3155BF87067A8B6043B9D96CFC19569E5E2D9A8921CA30A027E0161D922247B908CE6AF924BB70CC91D0991164B0B72F2F843244D0F93ACB1194FE439E66918C6D2E2")]