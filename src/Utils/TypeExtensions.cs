namespace Bogoware.Utils;

public static class TypeExtensions
{
    /// <summary>
    /// Check if a type is a subclass of a generic type
    /// </summary>
    /// <example>
    /// <code>
    /// class A&lt; T &gt; {}
    /// class B : A&lt; int &gt; {}
    ///
    /// var isSubclass = typeof(B).IsSubclassOfRawGeneric(typeof(A&lt;&gt;)); // true
    /// </code>
    /// </example>
    public static bool IsSubclassOfRawGeneric(this Type type, Type generic) {
        var toCheck = type;
        while (toCheck != null && toCheck != typeof(object)) {
            var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
            if (generic == cur) {
                return true;
            }
            toCheck = toCheck.BaseType;
        }
        return false;
    }
}