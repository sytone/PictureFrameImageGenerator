﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GenerateFrameImages.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\Libraries\\Photos")]
        public string ImageSourcePath {
            get {
                return ((string)(this["ImageSourcePath"]));
            }
            set {
                this["ImageSourcePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\HOME\\picturebox\\")]
        public string ImageDestinationPath {
            get {
                return ((string)(this["ImageDestinationPath"]));
            }
            set {
                this["ImageDestinationPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("60000")]
        public int SleepPeriod {
            get {
                return ((int)(this["SleepPeriod"]));
            }
            set {
                this["SleepPeriod"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int ImagesToGenerate {
            get {
                return ((int)(this["ImagesToGenerate"]));
            }
            set {
                this["ImagesToGenerate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1024")]
        public int ImageWidth {
            get {
                return ((int)(this["ImageWidth"]));
            }
            set {
                this["ImageWidth"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("768")]
        public int ImageHeight {
            get {
                return ((int)(this["ImageHeight"]));
            }
            set {
                this["ImageHeight"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("u")]
        public string DateFormat {
            get {
                return ((string)(this["DateFormat"]));
            }
            set {
                this["DateFormat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Arial")]
        public string DateFont {
            get {
                return ((string)(this["DateFont"]));
            }
            set {
                this["DateFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("36")]
        public int DateSize {
            get {
                return ((int)(this["DateSize"]));
            }
            set {
                this["DateSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100")]
        public int DateLeftPadding {
            get {
                return ((int)(this["DateLeftPadding"]));
            }
            set {
                this["DateLeftPadding"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("400")]
        public int DateTopPadding {
            get {
                return ((int)(this["DateTopPadding"]));
            }
            set {
                this["DateTopPadding"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("White")]
        public global::System.Drawing.Color DateColor {
            get {
                return ((global::System.Drawing.Color)(this["DateColor"]));
            }
            set {
                this["DateColor"] = value;
            }
        }
    }
}
