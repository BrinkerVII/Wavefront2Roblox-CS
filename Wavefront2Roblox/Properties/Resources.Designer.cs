﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wavefront2Roblox.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Wavefront2Roblox.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;roblox xmlns:xmime=&quot;http://www.w3.org/2005/05/xmlmime&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xsi:noNamespaceSchemaLocation=&quot;http://www.roblox.com/roblox.xsd&quot; version=&quot;4&quot;&gt;
        ///	&lt;External&gt;null&lt;/External&gt;
        ///	&lt;External&gt;nil&lt;/External&gt;
        ///	&lt;Item class=&quot;UnionOperation&quot; referent=&quot;RBX6D4263AE7DA64DA8B96B050666CD620B&quot;&gt;
        ///		&lt;Properties&gt;
        ///			&lt;bool name=&quot;Anchored&quot;&gt;false&lt;/bool&gt;
        ///			&lt;Content name=&quot;AssetId&quot;&gt;&lt;null&gt;&lt;/null&gt;&lt;/Content&gt;
        ///			&lt;float name=&quot;BackParamA&quot;&gt;-0.5&lt;/float&gt;
        ///			&lt;float name=&quot;BackParamB&quot;&gt;0.5&lt;/float&gt;
        ///			&lt;toke [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string rbxmtemplate {
            get {
                return ResourceManager.GetString("rbxmtemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///TriaCalc={
        ///	WIDTH = .2,
        ///	GetMetrics=(function(n1, n2, n3)
        ///		local Node1, Node2, Node3;
        ///		local InterimNode;
        ///
        ///		local d1, d2, d3 = (n1.Position - n2.Position).magnitude, (n2.Position - n3.Position).magnitude, (n3.Position - n1.Position).magnitude
        ///		if d1 &gt; d2 and d1 &gt; d3 then
        ///			Node1, Node2, Node3 = n2.Position, n3.Position, n1.Position
        ///		elseif d2 &gt; d3 then
        ///			Node1, Node2, Node3 = n3.Position, n1.Position, n2.Position
        ///		else
        ///			Node1, Node2, Node3 = n1.Position, n2.Position, n3.Position
        ///		e [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string rebuilder {
            get {
                return ResourceManager.GetString("rebuilder", resourceCulture);
            }
        }
    }
}
