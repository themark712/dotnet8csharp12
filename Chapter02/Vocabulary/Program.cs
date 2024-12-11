﻿// See https://aka.ms/new-console-template for more information
using System.Reflection;

// Declare some unused variable using types in
// additional assemblies to make them load too
System.Data.DataSet ds = new();
HttpClient client = new();

// Get the assembly that is the entry point for this app
Assembly? myApp = Assembly.GetEntryAssembly();

// If the previous line returned nothing then end thte app
if (myApp is null) return;

// Loop through the assemblies that my app references
foreach (AssemblyName name in myApp.GetReferencedAssemblies())
{
  // Load the assembly so we can read its details
  Assembly a = Assembly.Load(name);

  // Declare a variable to count the number of methods
  int methodCount = 0;
  
  // Loop through all the types in the assembly
  foreach(TypeInfo t in a.DefinedTypes) {
    // Add up the counts of all the methods
    methodCount += t.GetMethods().Length;
  }

  // Output the count of types and their methods
  Console.WriteLine("{0:N0} types with {1:N0} methods in {2} assembly.", arg0: a.DefinedTypes.Count(), arg1: methodCount, arg2:name.Name);

  Console.OutputEncoding = System.Text.Encoding.UTF8;
  string grinningEmoji = char.ConvertFromUtf32(0x1F600);
  Console.WriteLine(grinningEmoji);
}