﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpendingReport.L10n {
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
    internal class enumsL10n {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal enumsL10n() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SpendingReport.L10n.enumsL10n", typeof(enumsL10n).Assembly);
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
        ///   Looks up a localized string similar to Výber z bankomatu.
        /// </summary>
        internal static string ATMWithdrawall {
            get {
                return ResourceManager.GetString("ATMWithdrawall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Platba kartou.
        /// </summary>
        internal static string CardPayment {
            get {
                return ResourceManager.GetString("CardPayment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Platba v hotovosti.
        /// </summary>
        internal static string CashPayment {
            get {
                return ResourceManager.GetString("CashPayment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Poštová Banka.
        /// </summary>
        internal static string PostovaBanka {
            get {
                return ResourceManager.GetString("PostovaBanka", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tatra Banka.
        /// </summary>
        internal static string TatraBanka {
            get {
                return ResourceManager.GetString("TatraBanka", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Zuno.
        /// </summary>
        internal static string Zuno {
            get {
                return ResourceManager.GetString("Zuno", resourceCulture);
            }
        }
    }
}
