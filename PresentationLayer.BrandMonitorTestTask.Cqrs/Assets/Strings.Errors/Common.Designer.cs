//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PresentationLayer.BrandMonitorTestTask.Cqrs.Assets.Strings.Errors {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Common {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Common() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PresentationLayer.BrandMonitorTestTask.Cqrs.Assets.Strings.Errors.Common", typeof(Common).Assembly);
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
        ///   Looks up a localized string similar to Параметр запроса у ключа/команды не может быть пустым..
        /// </summary>
        internal static string REQUEST_ARGUMENT_IS_MISSING {
            get {
                return ResourceManager.GetString("REQUEST_ARGUMENT_IS_MISSING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Пользователь с заданым идентификатором не найдено в системе..
        /// </summary>
        internal static string USER_NOT_FOUND {
            get {
                return ResourceManager.GetString("USER_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Сессия пользователя имеет некоректный формат..
        /// </summary>
        internal static string USER_SESSION_HAS_INCORRECT_FORMAT {
            get {
                return ResourceManager.GetString("USER_SESSION_HAS_INCORRECT_FORMAT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Информация о сессии пользователя не найдена..
        /// </summary>
        internal static string USER_SESSION_NOT_FOUND {
            get {
                return ResourceManager.GetString("USER_SESSION_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Информация о пользователе не найдена в сессии пользователя..
        /// </summary>
        internal static string USER_SESSION_USER_INFORMATION_NOT_FOUND {
            get {
                return ResourceManager.GetString("USER_SESSION_USER_INFORMATION_NOT_FOUND", resourceCulture);
            }
        }
    }
}