using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Generic class for making a js-likeness to gameobjects, with some type safety
/// </summary>
public class PublicProps : MonoBehaviour
{
    //This is very dumb, but bear with me here, i AM dumb
    public Dictionary<string, object> properties;
    /// <summary>
    /// Standard Properties
    /// </summary>
    public Dictionary<string, System.Type> type_dict = new Dictionary<string, System.Type>()
    {
        {"Health", typeof(int)},
        {"Test Prop 1", typeof(string)},
        {"Test Prop 2", typeof(float)}
    };
    //Hey there, person
    //That may be someone on the team, if not me (1248)
    //This code needs some guardrails, such as errors, manual type checking(definitely, if there is any problem using this code, it needs to be checked at the source) and so. 
    //I have some research to do to makes sure that above work as needed
    //Also, i need to use that collection provided by .NET that notifies you where a value is changed

    /// <summary>
    /// Returns the property under the given name
    /// </summary>
    /// <typeparam name="ExpectedType">The expected type of the property</typeparam>
    /// <param name="name">The name of the property</param>
    /// <param name="value"></param>
    /// <returns></returns>
    public ExpectedType ReturnVar<ExpectedType>(string name )
    {   //Oh hey, <generics>? First time? Google it!
        return (ExpectedType)properties[name];
    }
    public void SetVar<ExpectedType>(string name, object value)
    {
        properties[name] = value;
    }
}
