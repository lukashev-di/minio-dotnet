﻿/*
 * MinIO .NET Library for Amazon S3 Compatible Cloud Storage, (C) 2017 MinIO, Inc.
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

namespace Minio.Exceptions;

[Serializable]
public class InvalidContentLengthException : MinioException
{
    private readonly string bucketName;
    private readonly string objectName;

    public InvalidContentLengthException(string bucketName, string objectName, string message) : base(message)
    {
        this.bucketName = bucketName;
        this.objectName = objectName;
    }

    public InvalidContentLengthException(ResponseResult serverResponse) : base(serverResponse)
    {
    }

    public InvalidContentLengthException(string message) : base(message)
    {
    }

    public InvalidContentLengthException(string message, ResponseResult serverResponse) : base(message, serverResponse)
    {
    }

    public InvalidContentLengthException()
    {
    }

    public InvalidContentLengthException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public override string ToString()
    {
        return $"{bucketName} :{objectName}: {base.ToString()}";
    }
}