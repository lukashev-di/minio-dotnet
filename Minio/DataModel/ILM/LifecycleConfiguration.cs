/*
 * MinIO .NET Library for Amazon S3 Compatible Cloud Storage, (C) 2021 MinIO, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.ObjectModel;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

/*
 * Object representation of request XML used in these calls - PutBucketLifecycleConfiguration, GetBucketLifecycleConfiguration.
 * https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketLifecycleConfiguration.html
 * https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketLifecycleConfiguration.html
 *
 */

namespace Minio.DataModel.ILM;

[Serializable]
[XmlRoot(ElementName = "LifecycleConfiguration")]
public class LifecycleConfiguration
{
    public LifecycleConfiguration()
    {
    }

    public LifecycleConfiguration(IList<LifecycleRule> rules)
    {
        if (rules is null || rules.Count <= 0)
            throw new ArgumentNullException(nameof(rules),
                "Rules object cannot be empty. A finite set of Lifecycle Rules are needed for LifecycleConfiguration.");

        Rules = new Collection<LifecycleRule>(rules);
    }

    [XmlElement("Rule")] public Collection<LifecycleRule> Rules { get; set; }

    public string MarshalXML()
    {
        XmlWriter xw = null;

        var str = string.Empty;

        try
        {
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            };
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using var sw = new StringWriter(CultureInfo.InvariantCulture);

            var xs = new XmlSerializer(typeof(LifecycleConfiguration), "");
            using (xw = XmlWriter.Create(sw, settings))
            {
                xs.Serialize(xw, this, ns);
                xw.Flush();
                str = Utils.RemoveNamespaceInXML(sw.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            // throw ex;
        }
        finally
        {
            xw?.Close();
        }

        return str;
    }
}