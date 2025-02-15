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

using System.Xml.Serialization;

/*
 * ReplicationTime class used within ReplicationDestination which has Replication Time Control information.
 * Please refer:
 * https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketReplication.html
 * https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketReplication.html
 * https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketReplication.html
 */

namespace Minio.DataModel.Replication;

[Serializable]
[XmlRoot(ElementName = "ReplicationTime")]
public class ReplicationTime
{
    public ReplicationTime()
    {
    }

    public ReplicationTime(ReplicationTimeValue time, string status)
    {
        if (string.IsNullOrEmpty(status))
            throw new ArgumentException($"'{nameof(status)}' cannot be null or empty.", nameof(status));

        Time = time ?? throw new ArgumentNullException(nameof(time));
        Status = status;
    }

    [XmlElement("Time")] public ReplicationTimeValue Time { get; set; }

    [XmlElement("Status")] public string Status { get; set; }
}