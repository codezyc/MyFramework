<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CommonLibary
{
    /// <summary>
    /// C#配置文件常用操作
    /// </summary>
    public static class ConfigFileUtils
    {
        /// <summary>
        /// 获取配置文件中指定键对应的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string key)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                return ConfigurationManager.AppSettings[key];
            return string.Empty;
        }

        /// <summary>
        /// 获取配置文件中所有的配置信息
        /// </summary>
        /// <returns>配置信息集合对象</returns>
        public static Dictionary<string, string> GetAllValues()
        {
            var dict = new Dictionary<string, string>();
            foreach (var item in ConfigurationManager.AppSettings.AllKeys)
            {
                dict.Add(item, ConfigurationManager.AppSettings[item]);
            }
            return dict;
        }

        /// <summary>
        /// 向配置文件中写入配置信息
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void WriteConfigValue(string key, object value)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (conf.AppSettings.Settings.AllKeys.Contains(key))
            {
                conf.AppSettings.Settings[key].Value = (string)value;
            }
            else
            {
                conf.AppSettings.Settings.Add(key, (string)value);
            }
            conf.Save(ConfigurationSaveMode.Full);
        }

        /// <summary>
        /// 删除配置文件中的一项配置
        /// </summary>
        /// <param name="key">待删除的配置的键</param>
        public static void DeleteConfigValue(string key)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (conf.AppSettings.Settings.AllKeys.Contains(key))
            {
                conf.AppSettings.Settings.Remove(key);
            }
            conf.Save(ConfigurationSaveMode.Modified);
        }
    }
}
=======
﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CommonLibary
{
    /// <summary>
    /// C#配置文件常用操作
    /// </summary>
    public static class ConfigFileUtils
    {
        /// <summary>
        /// 获取配置文件中指定键对应的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string key)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                return ConfigurationManager.AppSettings[key];
            return string.Empty;
        }

        /// <summary>
        /// 获取配置文件中所有的配置信息
        /// </summary>
        /// <returns>配置信息集合对象</returns>
        public static Dictionary<string, string> GetAllValues()
        {
            var dict = new Dictionary<string, string>();
            foreach (var item in ConfigurationManager.AppSettings.AllKeys)
            {
                dict.Add(item, ConfigurationManager.AppSettings[item]);
            }
            return dict;
        }

        /// <summary>
        /// 向配置文件中写入配置信息
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void WriteConfigValue(string key, object value)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (conf.AppSettings.Settings.AllKeys.Contains(key))
            {
                conf.AppSettings.Settings[key].Value = (string)value;
            }
            else
            {
                conf.AppSettings.Settings.Add(key, (string)value);
            }
            conf.Save(ConfigurationSaveMode.Full);
        }

        /// <summary>
        /// 删除配置文件中的一项配置
        /// </summary>
        /// <param name="key">待删除的配置的键</param>
        public static void DeleteConfigValue(string key)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (conf.AppSettings.Settings.AllKeys.Contains(key))
            {
                conf.AppSettings.Settings.Remove(key);
            }
            conf.Save(ConfigurationSaveMode.Modified);
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CommonLibary
{
    /// <summary>
    /// C#配置文件常用操作
    /// </summary>
    public static class ConfigFileUtils
    {
        /// <summary>
        /// 获取配置文件中指定键对应的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string key)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                return ConfigurationManager.AppSettings[key];
            return string.Empty;
        }

        /// <summary>
        /// 获取配置文件中所有的配置信息
        /// </summary>
        /// <returns>配置信息集合对象</returns>
        public static Dictionary<string, string> GetAllValues()
        {
            var dict = new Dictionary<string, string>();
            foreach (var item in ConfigurationManager.AppSettings.AllKeys)
            {
                dict.Add(item, ConfigurationManager.AppSettings[item]);
            }
            return dict;
        }

        /// <summary>
        /// 向配置文件中写入配置信息
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void WriteConfigValue(string key, object value)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (conf.AppSettings.Settings.AllKeys.Contains(key))
            {
                conf.AppSettings.Settings[key].Value = (string)value;
            }
            else
            {
                conf.AppSettings.Settings.Add(key, (string)value);
            }
            conf.Save(ConfigurationSaveMode.Full);
        }

        /// <summary>
        /// 删除配置文件中的一项配置
        /// </summary>
        /// <param name="key">待删除的配置的键</param>
        public static void DeleteConfigValue(string key)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (conf.AppSettings.Settings.AllKeys.Contains(key))
            {
                conf.AppSettings.Settings.Remove(key);
            }
            conf.Save(ConfigurationSaveMode.Modified);
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CommonLibary
{
    /// <summary>
    /// C#配置文件常用操作
    /// </summary>
    public static class ConfigFileUtils
    {
        /// <summary>
        /// 获取配置文件中指定键对应的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string key)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                return ConfigurationManager.AppSettings[key];
            return string.Empty;
        }

        /// <summary>
        /// 获取配置文件中所有的配置信息
        /// </summary>
        /// <returns>配置信息集合对象</returns>
        public static Dictionary<string, string> GetAllValues()
        {
            var dict = new Dictionary<string, string>();
            foreach (var item in ConfigurationManager.AppSettings.AllKeys)
            {
                dict.Add(item, ConfigurationManager.AppSettings[item]);
            }
            return dict;
        }

        /// <summary>
        /// 向配置文件中写入配置信息
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void WriteConfigValue(string key, object value)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (conf.AppSettings.Settings.AllKeys.Contains(key))
            {
                conf.AppSettings.Settings[key].Value = (string)value;
            }
            else
            {
                conf.AppSettings.Settings.Add(key, (string)value);
            }
            conf.Save(ConfigurationSaveMode.Full);
        }

        /// <summary>
        /// 删除配置文件中的一项配置
        /// </summary>
        /// <param name="key">待删除的配置的键</param>
        public static void DeleteConfigValue(string key)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (conf.AppSettings.Settings.AllKeys.Contains(key))
            {
                conf.AppSettings.Settings.Remove(key);
            }
            conf.Save(ConfigurationSaveMode.Modified);
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
=======
﻿using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace CommonLibary
{
    /// <summary>
    /// C#配置文件常用操作
    /// </summary>
    public static class ConfigFileUtils
    {
        /// <summary>
        /// 获取配置文件中指定键对应的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string key)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(key))
                return ConfigurationManager.AppSettings[key];
            return string.Empty;
        }

        /// <summary>
        /// 获取配置文件中所有的配置信息
        /// </summary>
        /// <returns>配置信息集合对象</returns>
        public static Dictionary<string, string> GetAllValues()
        {
            var dict = new Dictionary<string, string>();
            foreach (var item in ConfigurationManager.AppSettings.AllKeys)
            {
                dict.Add(item, ConfigurationManager.AppSettings[item]);
            }
            return dict;
        }

        /// <summary>
        /// 向配置文件中写入配置信息
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void WriteConfigValue(string key, object value)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (conf.AppSettings.Settings.AllKeys.Contains(key))
            {
                conf.AppSettings.Settings[key].Value = (string)value;
            }
            else
            {
                conf.AppSettings.Settings.Add(key, (string)value);
            }
            conf.Save(ConfigurationSaveMode.Full);
        }

        /// <summary>
        /// 删除配置文件中的一项配置
        /// </summary>
        /// <param name="key">待删除的配置的键</param>
        public static void DeleteConfigValue(string key)
        {
            Configuration conf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (conf.AppSettings.Settings.AllKeys.Contains(key))
            {
                conf.AppSettings.Settings.Remove(key);
            }
            conf.Save(ConfigurationSaveMode.Modified);
        }
    }
}
>>>>>>> 7d87b27e8fbfdc20ac3aab1a5d488a6088fb9fda
