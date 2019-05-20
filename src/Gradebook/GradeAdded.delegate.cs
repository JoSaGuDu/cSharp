using System;

namespace Gradebook
{
//Will match any method that returns void with anyName an that receive two parameters (object paramNAme, EventArgs paramName)
public delegate void  GradeAddedDelegate(object sender, EventArgs args);
}