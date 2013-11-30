using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CommonLibary
{
    /// <summary>
    /// XML文件常用操作
    /// </summary>
    public static class XMLUtils
    {
        /// <summary>
        /// 向XML文件中添加一个元素节点
        /// </summary>
        /// <param name="filepath">xml文件路径</param>
        /// <param name="name">元素属性名称</param>
        /// <param name="value">元素属性值</param>
        /// <param name="xmlnamespace">元素属性命名空间</param>
        public static void AddNewSection(string filepath, string name, string value, string xmlnamespace)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            var root = doc.DocumentElement;
            XmlNode node = doc.CreateNode("element", name, xmlnamespace);
            node.InnerText = value;
            root.AppendChild(node);
            doc.Save(filepath);
        }

        /// <summary>
        /// 删除一个元素节点
        /// </summary>
        /// <param name="filepath">xml文件路径</param>
        /// <param name="xpath"></param>
        public static void DeleteSection(string filepath, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            var root = doc.DocumentElement;
            var node = root.SelectSingleNode(xpath);
            if (node != null)
            {
                root.RemoveChild(node);
                doc.Save(filepath);
            }
        }

        /// <summary>
        /// 获取节点元素的值
        /// </summary>
        /// <param name="filepath">xml文件路径</param>
        /// <param name="xpath"></param>
        /// <param name="attributename">属性名称</param>
        /// <returns></returns>
        public static string GetElementAttribute(string filepath, string xpath, string attributename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            var root = doc.DocumentElement;
            var element = (XmlElement)root.SelectSingleNode(xpath);
            return element.GetAttribute(attributename);
        }

        /// <summary>
        /// 删除元素节点某个属性
        /// </summary>
        /// <param name="filepath">xml文件路径</param>
        /// <param name="xpath"></param>
        /// <param name="attributename">元素属性名</param>
        public static void DeleteElementAttribute(string filepath, string xpath, string attributename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            var root = doc.DocumentElement;
            XmlElement element = (XmlElement)doc.SelectSingleNode(xpath);
            if (element != null)
            {
                element.RemoveAttribute(attributename);
                doc.Save(filepath);
            }
        }

        /// <summary>
        /// 修改元素节点属性值
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="xpath"></param>
        /// <param name="attributename"></param>
        /// <param name="attributevalue"></param>
        public static void ModifiedElementAttribute(string filepath, string xpath, string attributename, string attributevalue)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            var root = doc.DocumentElement;
            XmlElement element = (XmlElement)doc.SelectSingleNode(xpath);
            if (element != null)
            {
                element.SetAttribute(attributename, attributevalue);
                doc.Save(filepath);
            }
        }

        /// <summary>
        /// 返回节点集合
        /// </summary>
        /// <param name="filepath">xml文件路径</param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static IEnumerable GetNodeList(string filepath, string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            var root = doc.DocumentElement;
            XmlNodeList nodelist = doc.SelectNodes(xpath);
            return nodelist;
        }

        /// <summary>
        /// 获取xml文件的根元素
        /// </summary>
        /// <param name="filepath">xml文件路径</param>
        /// <returns></returns>
        public static XmlElement GetRootElement(string filepath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            return doc.DocumentElement;
        }

        /// <summary>
        /// JSON字符串转成XML文件
        /// </summary>
        /// <param name="json">json字符串</param>
        /// <param name="filepath">xml文件保存路径</param>
        public static void JsonToXML(string json, string filepath)
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode(json);
            doc.Save(filepath);
        }

        /// <summary>
        /// DataTable转成XML并序列化
        /// </summary>
        /// <param name="dt">DataTable对象</param>
        /// <param name="path">xml文件路径</param>
        public static void SerializeDataTableToXML(DataTable dt, string path)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(DataTable));
            using (StreamWriter sw = new StreamWriter(path))
            {
                xmlser.Serialize(sw, dt);
            }
        }

        /// <summary>
        /// 发序列化XML转成DataTable对象
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static DataTable DeSerializeXMLToDataTable(string filepath)
        {
            DataTable dt;
            XmlSerializer xmlser = new XmlSerializer(typeof(DataTable));
            using (FileStream fs = File.OpenRead(filepath))
            {
                dt = (DataTable)xmlser.Deserialize(fs);
            }
            return dt;
        }
    }
}
